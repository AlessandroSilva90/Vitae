using Core_Providentia_vitae.Data;
using Core_Providentia_vitae.Models.Admin;
using Microsoft.EntityFrameworkCore;
using Core_Providentia_vitae.DTO.Modules;
using Core_Providentia_vitae.Data.Admin;
using AutoMapper;
using Core_Providentia_vitae.Models;
using System.Drawing;

namespace Core_Providentia_vitae.Services.Admin.Modules;


public class ModulesService
{
    private readonly AdminContext _context;
    private readonly MysqlContext _contextMysql;
    private readonly IMapper _mapper;

    public ModulesService(AdminContext context, IMapper mapper, MysqlContext contextMysql)
    {
        _context = context;
        _mapper = mapper;
        _contextMysql = contextMysql;
    }

    public async Task<(List<GetModulesDto> Modulo, int TotalCount, int TotalPages)> GetModules(int page = 1,
    int pageSize = 10)
    {

        var query = _context.Modulos.AsQueryable();

        var totalCount = await _context.Modulos.CountAsync();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        if (page < 1) page = 1;
        if (page > totalPages && totalPages > 0) page = totalPages;

        var skip = (page - 1) * pageSize;

        var modulos = await query.Skip(skip).Take(pageSize)
        .Select(u => new GetModulesDto
        {
            id = u.Id,
            nmModulos = u.NmModulos,
            snAtivo = u.SnAtivo
        }).ToListAsync();

        return (modulos, totalCount, totalPages);


        // return await _context.Modulos
        // .Select(u => new GetModulesDto
        // {
        //     id = u.Id,
        //     nmModulos = u.NmModulos,
        //     snAtivo = u.SnAtivo
        // }).ToListAsync();
    }

    public async Task<Modulo> createModule(CreateModuleDto moduleDto)
    {
        var modulo = new Modulo
        {
            NmModulos = moduleDto.nmModulos
        };

        _context.Add(modulo);

        try
        {
            await _context.SaveChangesAsync();
            return modulo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }

    }


    public async Task<Modulo> updateModules(uint id, UpdateModulesDto updateDTO)
    {
        var modulo = await _context.Modulos.FindAsync(id);

        if (modulo == null)
            throw new Exception("Módulo não encontrado");

        _mapper.Map(updateDTO, modulo);
        await _context.SaveChangesAsync();

        return modulo;
    }

    public async Task<bool> deleteModule(uint id)
    {
        var modulo = await _context.Modulos.FindAsync(id);

        if (modulo == null)
            return false;

        _context.Modulos.Remove(modulo);

        await _context.SaveChangesAsync();
        return true;
    }

    // VINCULAR FUNCIONARIO A SEUS MÓDULOS

    public async Task<List<GetUserModulesDto>> GetFuncionariosModulos(uint usuarioId)
    {
        try
        {
            var modulos = await _context.UsuarioModulos
                             .Where(m => m.CdUsuario == usuarioId)
                             .Where(m => m.Modulo.SnAtivo == true)
                             .Select(m => new GetUserModulesDto
                             {
                                 id = m.CdModulo,
                                 nmModulos = m.Modulo.NmModulos
                             }).ToListAsync();

            return modulos;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar módulos do usuário: {ex.Message}");
            throw;
        }
    }

    public async Task<UsuarioModulo> createUserModule(CreateUsuarioModuloDTO userModuledto)
    {
        var usermodulo = new UsuarioModulo
        {
            CdModulo = userModuledto.cdModulo,
            CdUsuario = userModuledto.cdUsuario
        };


        _context.Add(usermodulo);


        try
        {
            await _context.SaveChangesAsync();
            return usermodulo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteUserModule(uint idUser, uint idModulo)
    {
        try
        {
            var usermodulo = await _context.UsuarioModulos
                .Where(um => um.CdUsuario == idUser && um.CdModulo == idModulo)
                .ExecuteDeleteAsync();

            return usermodulo > 0; // true se deletou, false se não encontrou
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar: {ex.Message}");
            return false;
        }
    }


    // SERVICES PARA OS PERFIS
    public async Task<Perfil> CreatePerfil(Perfil perfil)
    {

        _context.Add(perfil);

        try
        {
            await _context.SaveChangesAsync();
            return perfil;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }

    }

    public async Task<List<Perfil>> GetPerfil()
    {
        return await _context.Perfils.ToListAsync();
    }

    public async Task<bool> DeletePerfil(uint id)
    {
        try
        {
            var perfil = await _context.Perfils.FindAsync(id);
            if (perfil == null)
                return false;

            _context.Perfils.Remove(perfil);

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar: {ex.Message}");
            return false;
        }
    }

public async Task<Perfil> UpdatePerfil(uint id, UpdatePerfilDto updatePerfilDto)
{
    try
    {
        
        var perfil = await _context.Perfils.FindAsync(id);
        
        
        if (perfil == null)
            throw new KeyNotFoundException($"Perfil com ID {id} não encontrado");
        
        
        if (!string.IsNullOrWhiteSpace(updatePerfilDto.dsPerfil))
            perfil.DsPefil = updatePerfilDto.dsPerfil;
            
        if (updatePerfilDto.snAtivo.HasValue)
            perfil.SnAtivo = updatePerfilDto.snAtivo;
        
        
        await _context.SaveChangesAsync();
        
        
        return perfil;
    }
    catch (KeyNotFoundException)
    {
        throw; 
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao atualizar perfil {id}: {ex.Message}");
        throw new Exception("Erro interno ao atualizar perfil", ex);
    }
}



}