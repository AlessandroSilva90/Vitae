using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core_Providentia_vitae.Services.Admin.Modules;
using Core_Providentia_vitae.DTO.Modules;
using Core_Providentia_vitae.Models.Admin;
using Azure;

namespace Core_Providentia_vitae.Controllers.Modules;


[ApiController]
[Route("api/[controller]")]
public class ModulesController : ControllerBase
{

    private readonly ModulesService _modulesService;

    public ModulesController(ModulesService modulesService)
    {
        _modulesService = modulesService;
    }

    [HttpGet("Modulos")]
    public async Task<ActionResult<CreateModuleDto>> GetModulos(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var (modulos, totalCount, totalPages) = await _modulesService.GetModules(page, pageSize);
        var response = new
        {
            Data = modulos,
            Pagination = new
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = totalPages,
                HasNextPage = page < totalPages,
                HasPreviousPage = page > 1
            }
        };


        return Ok(response);
    }

    [HttpGet("getModulos/{id}")]
    public async Task<ActionResult<CreateModuleDto>> GetModulosId(
    uint id
)
    {
        var modulos = await _modulesService.GetModulesId(id);

        return Ok(modulos);
    }

    [HttpPost("Modulos")]
    public async Task<ActionResult<CreateModuleDto>> CreateModules(CreateModuleDto dto)
    {
        return Ok(await _modulesService.createModule(dto));
    }

    [HttpPatch("Modulos/{id}")]
    public async Task<ActionResult<UpdateModulesDto>> UpdateModules(uint id, UpdateModulesDto dto)
    {
        return Ok(await _modulesService.updateModules(id, dto));
    }

    [HttpDelete("Modulos/{id}")]
    public async Task<ActionResult<Modulo>> DeleteUsuario(uint id)
    {
        try
        {
            var modulo = await _modulesService.deleteModule(id);

            if (modulo)
                return NoContent();

            return NotFound();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // VINCULAR FUNCIONARIO A SEUS MÓDULOS
    [HttpPost("cadastrarUserModule")]
    public async Task<ActionResult<CreateModuleDto>> CreateUserModule(CreateUsuarioModuloDTO dto)
    {
        return Ok(await _modulesService.createUserModule(dto));
    }

    [HttpGet("getUserModule")]
    public async Task<ActionResult<CreateModuleDto>> GetFuncionariosModulos(uint id)
    {
        return Ok(await _modulesService.GetFuncionariosModulos(id));
    }

    [HttpDelete("deleteUserModule")]
    public async Task<ActionResult<CreateModuleDto>> DeleteUserModule(uint idUser, uint idModulo)
    {
        var response = await _modulesService.DeleteUserModule(idUser, idModulo);

        if (response)
        {
            return Ok("Módulo removido!");
        }
        else
        {
            return NotFound("Módulo não encontrado");
        }
    }

    // ROTA PARA CADASTRO DE PERFIL
    [HttpPost("perfil")]
    public async Task<ActionResult<Perfil>> CreatePerfil(Perfil perfil)
    {
        return Ok(await _modulesService.CreatePerfil(perfil));
    }

    [HttpGet("perfil/{id}")]
    public async Task<ActionResult<Perfil>> GetPerfil(uint id)
    {
        return Ok(await _modulesService.GetPerfilById(id));
    }

[HttpGet("perfil")]
    public async Task<ActionResult<Perfil>> GetPerfil(int page = 1,
        [FromQuery] int pageSize = 10
    )
    {
        // return await _modulesService.GetMenusAsync(menus);
        var (perfil, totalCount, totalPages) = await _modulesService.GetPerfilAsync(page, pageSize);
        var response = new
        {
            Data = perfil,
            Pagination = new
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = totalPages,
                HasNextPage = page < totalPages,
                HasPreviousPage = page > 1
            }
        };

        return Ok(response);
    }

    [HttpDelete("perfil/{id}")]
    public async Task<ActionResult<bool>> DeletePerfil(uint id)
    {
        var response = await _modulesService.DeletePerfil(id);
        if (response)
        {
            return Ok("Perfil removido!");
        }
        else
        {
            return NotFound("Perfil não encontrado");
        }
    }

    [HttpPatch("perfil/{id}")]  // 👈 ID na rota
    public async Task<ActionResult<UpdatePerfilDto>> UpdatePerfil(
     uint id,
     [FromBody] UpdatePerfilDto updatePerfilDto)
    {
        try
        {
            if (updatePerfilDto == null)
                return BadRequest("Dados inválidos");

            var perfilAtualizado = await _modulesService.UpdatePerfil(id, updatePerfilDto);

            if (perfilAtualizado == null)
                return NotFound($"Perfil com ID {id} não encontrado");

            return Ok(perfilAtualizado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Erro de banco: {ex.Message}");
            return StatusCode(500, "Erro ao salvar no banco de dados");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
            return StatusCode(500, "Erro interno no servidor");
        }
    }

    // CADASTRO DOS MÓDULOS
    [HttpPost("menus")]
    public async Task<ActionResult<Menu>> CreateMenuAsync(Menu menus)
    {
        try
        {
            if (menus == null)
                return BadRequest("Dados inválidos");

            if (string.IsNullOrEmpty(menus.nmMenu))
                return BadRequest("Nome do menu é obrigatório");

            var menuCriado = await _modulesService.CreateMenus(menus);

            // Retorna 201 Created (mais semântico que 200)
            return CreatedAtAction(nameof(GetMenusId), new { id = menuCriado.Id }, menuCriado);
        }
        catch (Exception ex)
        {
            // Log pra você ver o erro
            Console.WriteLine($"Erro ao criar menu: {ex.Message}");
            return StatusCode(500, "Erro interno ao criar menu");
        }
    }

    [HttpGet("menus")]
    public async Task<ActionResult<GetMenusDto>> GetMenusAsync([FromQuery] int page = 1,
        [FromQuery] int pageSize = 10
    )
    {
        // return await _modulesService.GetMenusAsync(menus);
        var (menu, totalCount, totalPages) = await _modulesService.GetMenusAsync(page, pageSize);
        var response = new
        {
            Data = menu,
            Pagination = new
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalCount,
                TotalPages = totalPages,
                HasNextPage = page < totalPages,
                HasPreviousPage = page > 1
            }
        };

        return Ok(response);
    }

      [HttpGet("menus/{id}")]
    public async Task<ActionResult<GetMenusDto>> GetMenusId(uint id)
    {
        // return await _modulesService.GetMenusAsync(menus);
        var menu = await _modulesService.GetMenusId(id);
    

        return Ok(menu);
    }

    [HttpPatch("menus/{id}")]
    public async Task<ActionResult<CreateMenusDto>> EditMenus(
     uint id,
     [FromBody] UpdateMenuDto updateMenus)
    {
        try
        {
            if (updateMenus == null)
                return BadRequest("Dados inválidos");

            var perfilAtualizado = await _modulesService.EditMenusId(id, updateMenus);

            if (perfilAtualizado == null)
                return NotFound($"Menu com ID {id} não encontrado");

            return Ok(perfilAtualizado);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (DbUpdateException ex)
        {
            Console.WriteLine($"Erro de banco: {ex.Message}");
            return StatusCode(500, "Erro ao salvar no banco de dados");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado: {ex.Message}");
            return StatusCode(500, "Erro interno no servidor");
        }
    }

    // MENUS DA SIDEBAR
        [HttpGet("sidebar")]
    public async Task<ActionResult<GetMenusDto>> GetSidebarMenus()
    {
        var menu = await _modulesService.GetSidebarMenus();
    

        return Ok(menu);    
    }

    // CRIAR VINCULOS MENUS E MODULOS
    [HttpPost("menumodulo")]
    public async Task<ActionResult<MenuModuloDTO>> VinculoMenuModulo(MenuModuloDTO menuModulo)
    {
          try
        {
            if (menuModulo == null)
                return BadRequest("Dados inválidos");

            // if (string.IsNullOrEmpty(menus.nmMenu))
            //     return BadRequest("Nome do menu é obrigatório");

            var vinculo = await _modulesService.VinculoMenuModuloAsync(menuModulo);

            // Retorna 201 Created (mais semântico que 200)
            // return CreatedAtAction(nameof(GetMenusId), new { id = menuCriado.Id }, menuCriado);
            return Ok(vinculo);
        }
        catch (Exception ex)
        {
            // Log pra você ver o erro
            Console.WriteLine($"Erro ao vincular menu: {ex.Message}");
            return StatusCode(500, "Erro interno ao vincular menu");
        }
    }


}
