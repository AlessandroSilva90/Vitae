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
            var (funcionarios, totalCount, totalPages) = await _funcionariosService.GetFuncionariosAsync(page,pageSize);
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
    public async Task<ActionResult<GetFuncionariosDTO>> GetFuncionariosTeste(){
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
    public async Task<ActionResult<List<UsuarioResponseDto>>> GetUsuarios()
    {
        var funcionarios = await _usuariosService.GetUsuariosAsync();
        return Ok(funcionarios);
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
    [HttpGet("setores")]
    public async Task<ActionResult<List<Lot>>> GetSetores(
    [FromQuery] string? codigo = null,
    [FromQuery] string? nome = null,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10
     )
    {
         try
        {
            var (setores, totalCount, totalPages) = await _rhServices.GetSetores(codigo,nome,page, pageSize);
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
    public async Task<ActionResult<Usuario>> GetUsuarioById(uint id)
    {
        var usuario = await _usuariosService.GetUsuariosByIdAsync(id);
        if (usuario == null)
            return NotFound("Usuário não encontrado");

        return Ok(usuario);
    }

    [HttpPost("cadastrarUsuario")]
    public async Task<ActionResult<CreateUsuarioDto>> CreateUsuario(CreateUsuarioDto dto)
    {
        var usuarioCriado = await _usuariosService.CreateUsuario(dto);
        return Ok(usuarioCriado);

    }

    [HttpPut("updateUsuario")]
    public async Task<ActionResult<Usuario>> UpdateUsuario(uint id, UpdateUsuarioDto dto)
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

    [HttpDelete("deleteUsuario")]
    public async Task<ActionResult<Usuario>> DeleteUsuario(uint id)
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
    public async Task<ActionResult<CoordenadorSetor>> VincularCoordenadorAsync(CoordenadorSetor coord)
    {
        var response = await _rhServices.VincularCoordSetorAsync(coord);
        return Ok(response);
    }

    [HttpGet("GetCoordenadorSetor")]
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