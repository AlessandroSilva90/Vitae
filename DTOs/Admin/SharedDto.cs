namespace Core_Providentia_vitae.DTO.Shared;

using System.ComponentModel.DataAnnotations;


public class GetUsuarioDTO
{
    public uint Id { get; set; }
    public string Setor { get; set; } = null!;
}

public class GetFuncionariosDTO
{
    public String Id { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Setor { get;set; } = null!;

}


public class GetSetoresDTO
{
    public uint Id { get; set; }
    public string Nome { get; set; } = null!;
}

public class GetUniIntDTO
{
    public uint Id { get; set; }
    public string NmUniInt { get; set; } = null!;

}

