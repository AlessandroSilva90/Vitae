namespace Core_Providentia_vitae.DTO.Modules;

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging.Abstractions;

public class CreateModuleDto
{
    [Required] public string nmModulos { get; set; } = null!;

    [Required] public bool? snAtivo { get; set; } = true;
}

public class GetModulesDto
{
    public uint id { get; set; }
    public string? nmModulos { get; set; } = null!;
    public bool? snAtivo { get; set; } = true;
}

public class GetUserModulesDto
{
    public uint id { get; set; }
    public string? nmModulos { get; set; } = null!;
    // Nome do usuario
    public string? Nome { get; set; } = null!;
}

public class UpdateModulesDto
{
    public string? nmModulos { get; set; } = null!;
    public bool? snAtivo { get; set; } = true;
}

public class CreateUsuarioModuloDTO
{
    public uint cdModulo { get; set; }
    public uint cdUsuario { get; set; }
}

public class UpdatePerfilDto
{
    public string? dsPerfil {get;set;} = null!;
    public bool? snAtivo {get;set;} = null!;
}

// DTO PARA OS MENUS

// DTO para o menu principal (com submenus)
public class GetMenusDto
{
    public uint id { get; set; }
    public string NmMenu { get; set; } = null!;
    public bool? SnAtivo {get;set;} = true;
    public uint? CdMenuPai { get; set; }
    public uint Ordem { get; set; }
    public List<GetMenusSubmenuDto> Submenus { get; set; } = new List<GetMenusSubmenuDto>();
}

// DTO para submenu (simplificado)
public class GetMenusSubmenuDto
{
    public uint id { get; set; }
    public string NmMenu { get; set; } = null!;
    public uint Ordem { get; set; }
}

public class CreateMenusDto
{
    public string NmMenu {get;set;} = null!;
    public bool? SnAtivo {get;set;} = true;
    public uint? CdMenuPai {get;set;}
    public uint? Ordem {get;set;}

}

public class EditMenusDto
{
    public string NmMenu {get;set;} = null!;
    public bool? SnAtivo {get;set;} = true;
    public uint? CdMenuPai {get;set;}
    public uint? Ordem {get;set;}

}

  public class UpdateMenuDto
{
    public string? NmMenu { get; set; }     
    public bool? SnAtivo { get; set; }      
    public uint? CdMenuPai { get; set; }    
    public uint? Ordem { get; set; }        
}

// VINCULO MENU MODULO
public class MenuModuloDTO
{
    public uint cd_menu {get;set;}
    public uint cd_modulo{get;set;}
}