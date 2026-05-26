using Microsoft.AspNetCore.Mvc;
using Core_Providentia_vitae.Models;
using Core_Providentia_vitae.Services;
using Microsoft.EntityFrameworkCore;
using Core_Providentia_vitae.Services.RH;
using Core_Providentia_vitae.DTO.RH;
using Core_Providentia_vitae.Models.RH;
using Core_Providentia_vitae.DTO.Shared;

namespace Core_Providentia_vitae.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RhController : ControllerBase
{
    private readonly RhServices _rhServices;
    private readonly FuncionariosService _funcionariosService;
    private readonly UserService _usuariosService;

    public RhController(FuncionariosService funcionariosService, UserService usuariosService, RhServices rhServices)
    {
        _rhServices = rhServices;
        _funcionariosService = funcionariosService;
        _usuariosService = usuariosService;
    }

    // ROTAS PARA TRAZER TODOS OS FUNCIONÁRIOS
    [HttpGet("funcionarios")]
    public async Task<ActionResult<List<Epg>>> GetFuncionarios(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {


        try
        {
            var (funcionarios, totalCount, totalPages) = await _funcionariosService.GetFuncionariosAsync(page, pageSize);
            var response = new
            {
                Data = funcionarios,
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno", Error = ex.Message });
        }
    }

    [HttpGet("funcionariosTeste")]
    public async Task<ActionResult<GetFuncionariosDTO>> GetFuncionariosTeste()
    {
        var func = await _funcionariosService.GetFuncionariosAsync01();

        return Ok(func);
    }

    [HttpGet("funcionarios/{cracha}")]
    public async Task<ActionResult<GetFuncionariosDTO>> GetFuncionariosCracha(string cracha)
    {
        var funcionarios = await _funcionariosService.GetFuncionariosCrachaAsync(cracha);
        return Ok(funcionarios);
    }

    // ROTA PARA TRAZER OS USUÁRIOS DO SISTEMA
    [HttpGet("usuarios")]
    public async Task<ActionResult<List<UsuarioResponseDto>>> GetUsuarios(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10
    )
    {
        var (usuarios, totalCount, totalPages) = await _usuariosService.GetUsuariosAsync(page, pageSize);
        var response = new
        {
            Data = usuarios,
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

    // ROTAS PARA TRAZER OS CARGOS
    [HttpGet("cargos")]
    public async Task<ActionResult<List<Car>>> GetCargos(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10
    )
    {
        // var cargos = await _rhServices.GetAllCargos();
        // return Ok(cargos);

        try
        {
            var (cargo, totalCount, totalPages) = await _rhServices.GetAllCargos(page, pageSize);
            var response = new
            {
                Data = cargo,
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno", Error = ex.Message });
        }
    }

    // ROTAS PARA TRAZER OS SETORES
    [HttpGet("setores/{nome?}")]
    public async Task<ActionResult<List<Lot>>> GetSetores(
    // [FromQuery] string? codigo = null,
    string? nome = null,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10
     )
    {
        try
        {
            var (setores, totalCount, totalPages) = await _rhServices.GetSetores(nome, page, pageSize);
            var response = new
            {
                Data = setores,
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
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno", Error = ex.Message });
        }

        // var setores = await _rhServices.GetSetores(codigo, nome);
        // return Ok(setores);
    }

    // public async Task<Usuario?> GetUsuariosById(int id)
    // {
    //     return await _usuariosService.GetUsuariosByIdAsync(id);
    // }

    [HttpGet("usuarios/{id}")]
    public async Task<ActionResult<UpdateUsuarioDto>> GetUsuarioById(string id)
    {
        try
        {
            
        var usuario = await _usuariosService.GetUsuariosByIdAsync(id);
        if (usuario == null)
            return NotFound(new { message = "Usuário não encontrado" });
        return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost("cadastrarUsuario")]
    public async Task<ActionResult<UsuarioResponseDto>> CreateUsuario(CreateUsuarioDto dto)
    {
        try
        {
            var usuarioCriado = await _usuariosService.CreateUsuario(dto);

            // Mapear para DTO de resposta (não retornar a entidade)
            var usuarioResponse = new UsuarioResponseDto
            {
                Id = usuarioCriado.Id,
                Nome = usuarioCriado.Nome,
                Email = usuarioCriado.Email,
                DsUsuario = usuarioCriado.Ds_Usuario,
                SnFuncionario = usuarioCriado.Sn_Funcionario ?? false,
                SnAtivo = usuarioCriado.Sn_Ativo ?? false,
                DtCreate = usuarioCriado.Dt_Create,
                Cracha = usuarioCriado.Cracha,
                Senha = usuarioCriado.Senha
                
            };

            return Ok(usuarioResponse);
        }
        catch (InvalidOperationException ex)
        {
            // Usuário já existe - 409 Conflict
            return Conflict(new { message = ex.Message });
        }
        catch (DbUpdateException ex)
        {
            // Erro de banco de dados
            return StatusCode(500, new { message = "Erro ao salvar no banco de dados" });
        }
        catch (Exception ex)
        {
            // Erro genérico
            return StatusCode(500, new { message = "Erro interno no servidor" });
        }
    }

    [HttpPatch("updateUsuario/{id}")]
    public async Task<ActionResult<Usuarios>> UpdateUsuario(uint id, UpdateUsuarioDto dto)
    {
        try
        {
            var usuario = await _usuariosService.UpdateUsuarioAsync(id, dto);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }

    }

    [HttpDelete("deleteUsuario/{id}")]
    public async Task<ActionResult<Usuarios>> DeleteUsuario(uint id)
    {
        try
        {
            var usuario = await _usuariosService.DeleteUserAsync(id);

            if (usuario)
                return NoContent();

            return NotFound();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // TROCA DE PLANTÃO DOS FUNCIONÁRIOS

    [HttpPost("createTrocaPlantao")]
    public async Task<ActionResult<CreateTrocaPlantaoDTO>> CreateTrocaPlantao(
      [FromBody] CreateTrocaPlantaoDTO dto)
    {
        // ✅ VERIFIQUE A VALIDAÇÃO ANTES DE PROCESSAR
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var response = await _funcionariosService.CreateTrocaPlantao(dto);
            return Ok(response);
        }
        catch (Exception)
        {
            // Log do erro
            // _logger.LogError(ex, "Erro ao criar troca de plantão");
            return StatusCode(500, "Erro interno do servidor");
        }
    }

    [HttpGet("getTrocaPlantaoId/{id}")]
    public async Task<ActionResult<List<GetTrocaPlantoesDTO>>> GetTrocaPlantaoId(int id)
    {
        var response = await _funcionariosService.GetPlantaoById(id);
        return Ok(response);
    }


    [HttpPatch("UpdateTrocaPlantaoId/{id}")]
    public async Task<ActionResult<UpdateTrocaPlantaoDTO>> UpdateTrocaPlantao(int id, UpdateTrocaPlantaoDTO updateDto)
    {
        var response = await _funcionariosService.UpdateTrocaPlantaoAsync(id, updateDto);
        return Ok(response);
    }

    [HttpDelete("deleteTrocaPlantao")]
    public async Task<ActionResult<bool>> DeleteTrocaPlantao(int i)
    {
        try
        {
            var troca = await _rhServices.DeleteTrocaPlantao(i);

            if (troca)
                return NoContent();

            return NotFound();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // A PARTIR DAQUI É O VINCULO  DE COORDENADOR A SETOR E COORDENADOR A FUNCIONÁRIOS

   [HttpPost("VincularCoordenadorSetor")]
public async Task<ActionResult<List<CreateVinculoCoordenadorSetorDTO>>> VincularCoordenadorAsync([FromBody] CreateVinculoCoordenadorSetorDTO coord)
{
    try
    {
        var responses = await _rhServices.VincularCoordSetorAsync(coord);
        
        // Mapear os resultados para DTO de resposta
        var result = responses.Select(r => new CreateVinculoCoordenadorSetorDTO
        {
            CdCoordenador = r.CdCoordenador,
            CdSetor = new List<string> { r.CdSetor }
        }).ToList();
        
        return Ok(result);
    }
    catch (InvalidOperationException ex)
    {
        return Conflict(new { message = ex.Message });
    }
    catch (DbUpdateException ex)
    {
        return StatusCode(500, new { message = "Erro ao salvar no banco de dados" });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = "Erro interno no servidor" });
    }
}

    [HttpGet("GetCoordenadorSetor/{crachaCoord}")]
    public async Task<ActionResult<GetVinculoCoordenadorSetorDTO>> GetCoordenadorSetorAsync(int crachaCoord)
    {
        var response = await _rhServices.GetCoordenadorSetorAsync(crachaCoord);
        return Ok(response);
    }

    [HttpDelete("deleteCoordenadorSetor")]
    public async Task<ActionResult<bool>> DeleteCoordenadorSetorAsync(int i)
    {
        try
        {
            var troca = await _rhServices.DeleteCoordenadorSetorAsync(i);

            if (troca)
                return NoContent();

            return NotFound();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }


}