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

    public async Task<GetModulesDto?> GetModulesId(uint id)
    {

        var modulo = await _context.Modulos.FindAsync(id);

        if (modulo == null)
            return null;

        return new GetModulesDto
        {
            nmModulos = modulo.NmModulos,
            snAtivo = modulo.SnAtivo
        };
    }


    public async Task<Modulo> createModule(CreateModuleDto moduleDto)
    {
        var modulo = new Modulo
        {
            NmModulos = moduleDto.nmModulos,
            SnAtivo = moduleDto.snAtivo ?? true
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

    public async Task<Perfil?> GetPerfilById(uint id)
    {
        var perfil = await _context.Perfils.FindAsync(id);

        if (perfil == null)
        {
            return null;
        }

        return perfil;
    }

    public async Task<(List<Perfil> Perfil, int TotalCount, int TotalPages)> GetPerfilAsync(int page = 1,
       int pageSize = 10)
    {
        var query = _context.Perfils.AsQueryable();

        var totalCount = await _context.Menus.CountAsync();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        if (page < 1) page = 1;
        if (page > totalPages && totalPages > 0) page = totalPages;

        var skip = (page - 1) * pageSize;

        var perfil = await query.Skip(skip).Take(pageSize)
        .Select(p => new Perfil
        {
            Id = p.Id,
            DsPerfil = p.DsPerfil,
            SnAtivo = p.SnAtivo
        }).ToListAsync();

        return (perfil, totalCount, totalPages);
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
                perfil.DsPerfil = updatePerfilDto.dsPerfil;

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

    // SERVICE PARA CRIAÇÃO DOS MENUS
    public async Task<Menu> CreateMenus(Menu menus)
    {

        _context.Add(menus);

        try
        {
            await _context.SaveChangesAsync();
            return menus;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }

    }

    public async Task<(List<GetMenusDto> Modulo, int TotalCount, int TotalPages)> GetMenusAsync(int page = 1,
    int pageSize = 10)
    {

        var query = _context.Menus.AsQueryable();

        var totalCount = await _context.Menus.CountAsync();

        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        if (page < 1) page = 1;
        if (page > totalPages && totalPages > 0) page = totalPages;

        var skip = (page - 1) * pageSize;

        var menus = await query.Skip(skip).Take(pageSize)
        .Select(u => new GetMenusDto
        {
            id = u.Id,
            NmMenu = u.nmMenu,
            SnAtivo = u.SnAtivo,
            CdMenuPai = u.CdMenuPai,
            Ordem = u.Ordem
        }).ToListAsync();

        return (menus, totalCount, totalPages);
    }

    public async Task<GetMenusDto?> GetMenusId(uint id)
    {
        var menus = await _context.Menus.FindAsync(id);

        if (menus == null)
            return null;

        return new GetMenusDto
        {
            id = menus.Id,
            NmMenu = menus.nmMenu,
            SnAtivo = menus.SnAtivo,
            CdMenuPai = menus.CdMenuPai,
            Ordem = menus.Ordem

        };
    }

    public async Task<Menu> EditMenusId(uint id, UpdateMenuDto menusDto)
    {
        try
        {

            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
                throw new KeyNotFoundException($"Menu com ID {id} não encontrado");

            if (!string.IsNullOrWhiteSpace(menusDto.NmMenu))
                menu.nmMenu = menusDto.NmMenu;

            if (menusDto.SnAtivo.HasValue)
                menu.SnAtivo = menusDto.SnAtivo;

            if (menusDto.CdMenuPai.HasValue && menusDto.CdMenuPai.Value > 0)
                menu.CdMenuPai = menusDto.CdMenuPai.Value;

            if (menusDto.Ordem.HasValue && menusDto.Ordem.Value > 0)
                menu.Ordem = menusDto.Ordem.Value;

            await _context.SaveChangesAsync();


            return menu;
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

    public async Task<List<GetMenusDto>> GetSidebarMenus()
    {

        //         SELECT * FROM menu m  
        //  left join menu m1 on m1.cdMenuPai = m.id
        //  where m.cdMenuPai = 0
        //  order by m.ordem, m1.ordem

        try
{
    // 1. Busca todos os menus ativos
    var todosMenus = await _context.Menus
        .Where(m => m.SnAtivo == true)
        .OrderBy(m => m.Ordem)
        .ToListAsync();

    // 2. Separa principais e submenus
    var menusPrincipais = todosMenus
        .Where(m => m.CdMenuPai == 0 || m.CdMenuPai == null)
        .OrderBy(m => m.Ordem);

    // 3. Monta a estrutura hierárquica
    var resultado = menusPrincipais.Select(menu => new GetMenusDto
    {
        id = menu.Id,
        NmMenu = menu.nmMenu,
        SnAtivo = menu.SnAtivo,
        CdMenuPai = menu.CdMenuPai,
        Ordem = menu.Ordem,
        Submenus = todosMenus
            .Where(sub => sub.CdMenuPai == menu.Id)
            .OrderBy(sub => sub.Ordem)
            .Select(sub => new GetMenusSubmenuDto
            {
                id = sub.Id,
                NmMenu = sub.nmMenu,
                Ordem = sub.Ordem
            }).ToList()
    }).ToList();

    return resultado;
}
catch (Exception ex)
{
    Console.WriteLine($"Erro ao buscar menus: {ex.Message}");
    throw;
}
    }

    // CRIAR VINCULOS MENUS E MODULOS
    public async Task<MenuModulo> VinculoMenuModuloAsync(MenuModuloDTO menuModulo)
    {
        var menuModulo1 = new MenuModulo
        {
            cd_Menu = menuModulo.cd_menu,
            cd_Modulo = menuModulo.cd_modulo
        };

        _context.Add(menuModulo1);

        try
        {
            await _context.SaveChangesAsync();
            return menuModulo1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            throw;
        }

    }


}