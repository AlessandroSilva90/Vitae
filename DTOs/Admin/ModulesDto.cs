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