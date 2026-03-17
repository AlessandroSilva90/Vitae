using Core_Providentia_vitae.Data;
using Core_Providentia_vitae.Models;
using Microsoft.EntityFrameworkCore;
using Core_Providentia_vitae.DTO.RH;
using AutoMapper;

namespace Core_Providentia_vitae.Services;

public class UserService
{

    // CONTEXTO DE CONEXÃO COM O BANCO DE DADOS
    private readonly MysqlContext _context;
    private readonly IMapper _mapper;
    public UserService(MysqlContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // FIM


    // FORMA ANTIGA DE RETORONO DOS DADOS. CHAMADA DIRETO DA MODEL COM TODOS OS CAMPOS
    // public async Task<List<Usuario>> GetUsuariosAsync()
    // {
    //     return await _context.Usuarios.ToListAsync();
    // }

    // MANEIRA NOVA COM USO DE DTO PARA DADOS ESPECÍFICOS
    public async Task<List<UsuarioResponseDto>> GetUsuariosAsync()
    {
        return await _context.Usuarios
            .Select(u => new UsuarioResponseDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Cracha = u.Cracha,
                Snfuncionario = u.Sn_Funcionario,
                Snativo = u.Sn_Ativo,
                DsUsuario = u.Ds_Usuario
            })
            .ToListAsync();
    }

    public async Task<Usuario?> GetUsuariosByIdAsync(uint id)
    {
        return await _context.Usuarios.FindAsync(id);
    }

    //     public async Task<Usuario> CreateUsuario(CreateUsuarioDto dto)
    // {
    //     var usuario = new Usuario
    //     {
    //         Nome = dto.Nome,
    //         Email = dto.Email,
    //         Sn_Funcionario = dto.Snfuncionario ?? true,
    //         Ds_Usuario = dto.DsUsuario,
    //         Senha = dto.Senha,

    //     };

    //     _context.Usuarios.Add(usuario);
    //     await _context.SaveChangesAsync();

    //     return usuario;
    // }

    public async Task<Usuario> CreateUsuario(CreateUsuarioDto usuarioDto)
    {
        // Criar o usuário manualmente
        var usuario = new Usuario
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Sn_Funcionario = usuarioDto.Snfuncionario,
            Ds_Usuario = usuarioDto.DsUsuario,
            Senha = usuarioDto.Senha,
            Dt_Create = DateTime.Now
        };

        _context.Usuarios.Add(usuario);

        try
        {
            await _context.SaveChangesAsync();
            return usuario;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }
    }

    public async Task<Usuario> UpdateUsuarioAsync(uint id, UpdateUsuarioDto updateDto)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(id);

        if (usuarioExistente == null)
            throw new Exception("Usuário não encontrado");

        _mapper.Map(updateDto, usuarioExistente);

        usuarioExistente.Dt_Update = DateTime.Now; // Atualiza data de modificação

        await _context.SaveChangesAsync();
        return usuarioExistente;
    }



    public async Task<bool> DeleteUserAsync(uint id)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(id);

        if (usuarioExistente == null)
            return false;

        _context.Usuarios.Remove(usuarioExistente);

        //  Deleção lógica (marca como inativo)
        // usuario.Sn_Ativo = false;
        // usuario.Dt_Update = DateTime.Now;


        await _context.SaveChangesAsync();
        return true;
    }
}
