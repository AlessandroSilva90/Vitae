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
    public async Task<(List<UsuarioResponseDto> Usuarios, int TotalCount, int TotalPages)> GetUsuariosAsync(
        int page = 1,
        int pageSize = 10
    )
    {
        var totalCount = await _context.Usuarios.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        if (page < 1) page = 1;
        if (page > totalPages && totalPages > 0) page = totalPages;
        var skip = (page - 1) * pageSize;

        var usuario = await _context.Usuarios
            .Select(u => new UsuarioResponseDto
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email,
                Cracha = u.Cracha,
                SnFuncionario = u.Sn_Funcionario,
                SnAtivo = u.Sn_Ativo,
                DsUsuario = u.Ds_Usuario
            }).Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        return (usuario, totalCount, totalPages);
    }

    public async Task<List<UsuarioResponseDto>?> GetUsuariosByIdAsync(string termo)
    {
        var query = _context.Usuarios.AsQueryable();

        // Tenta converter para número (int ou uint)
        if (int.TryParse(termo, out int numero))
        {
            // Se for número, busca por ID OU Crachá
            query = query.Where(u =>
                u.Id == numero ||  // ID é string, converte número para string
                u.Cracha == numero);          // Crachá é numérico
        }
        else if (termo.Contains('@'))
        {
            // Se tem @, busca por email
            query = query.Where(u => u.Email.Contains(termo));
        }
        else
        {
            // Senão, busca por nome
            query = query.Where(u => u.Nome.Contains(termo));
        }

        // Pega o PRIMEIRO usuário encontrado (ou null se não achar)
        var usuario = await query.ToListAsync();

        if (usuario == null)
            return null;
            
        // return usuario;
        return usuario.Select(u => new UsuarioResponseDto
    {
        Id = u.Id,
        Cracha = u.Cracha,
        DsUsuario = u.Ds_Usuario,
        Email = u.Email,
        Nome = u.Nome,
        SnAtivo = u.Sn_Ativo,
        SnFuncionario = u.Sn_Funcionario
    }).ToList();
    
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

    public async Task<Usuarios> CreateUsuario(CreateUsuarioDto usuarioDto)
    {
        // Criar o usuário manualmente
        var usuario = new Usuarios
        {
            Nome = usuarioDto.Nome,
            Email = usuarioDto.Email,
            Sn_Funcionario = usuarioDto.SnFuncionario,
            Ds_Usuario = usuarioDto.DsUsuario,
            Senha = usuarioDto.Senha,
            Dt_Create = DateTime.Now,
            Cracha = usuarioDto.Cracha
            
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

    public async Task<Usuarios> UpdateUsuarioAsync(uint id, UpdateUsuarioDto updateDto)
    {
        var usuarioExistente = await _context.Usuarios.FindAsync(id);

        if (usuarioExistente == null)
            throw new Exception("Usuário não encontrado");

        _mapper.Map(updateDto, usuarioExistente);

        usuarioExistente.Dt_Update = DateTime.Now;

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
