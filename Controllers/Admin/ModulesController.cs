using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core_Providentia_vitae.Services.Admin.Modules;
using Core_Providentia_vitae.DTO.Modules;
using Core_Providentia_vitae.Models.Admin;

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

    [HttpGet("getModulos")]
    public async Task<ActionResult<CreateModuleDto>> GetModulos(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var (modulos, totalCount, totalPages) = await _modulesService.GetModules(page, pageSize);
        var response = new
        {
            Data = modulos,
            Paginationa = new
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

    [HttpPost("cadastrarModulos")]
    public async Task<ActionResult<CreateModuleDto>> CreateModules(CreateModuleDto dto)
    {
        return Ok(await _modulesService.createModule(dto));
    }

    [HttpPut("updateModulos")]
    public async Task<ActionResult<UpdateModulesDto>> UpdateModules(uint id, UpdateModulesDto dto)
    {
        return Ok(await _modulesService.updateModules(id, dto));
    }

    [HttpDelete("deletarModulos")]
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

    [HttpGet("perfil")]
    public async Task<ActionResult<Perfil>> GetPerfil()
    {
        return Ok(await _modulesService.GetPerfil());
    }

    [HttpDelete("perfil")]
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


    // Cadastro de MenuModulo



}
