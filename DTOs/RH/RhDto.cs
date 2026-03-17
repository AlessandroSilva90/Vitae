namespace Core_Providentia_vitae.DTO.RH;

using System.ComponentModel.DataAnnotations;
// CREATE
public class CreateUsuarioDto
{
    [Required(ErrorMessage = "Nome é obrigatório")] public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
    [Required] public bool? Snfuncionario { get; set; } = true;
    [Required] public string DsUsuario { get; set; } = null!;
    [Required] public string Senha { get; set; } = null!;
}

// UPDATE  
public class UpdateUsuarioDto
{
    // public uint? Id { get; set; }
    public string? Nome { get; set; } = null!;
    public string? Ds_Usuario { get; set; } = null!;
    public int? Cracha { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Senha { get; set; } = null!;
    public bool? Snativo { get; set; } = null!;
}

// RESPONSE
public class UsuarioResponseDto
{
    public uint Id { get; set; }
    public string Nome { get; set; } = null!;
    public int Cracha { get; set; }
    public string Email { get; set; } = null!;
    public string DsUsuario { get; set; } = null!;
    public bool? Snfuncionario { get; set; }
    public bool? Snativo { get; set; }
}

// FILTER (para busca)
public class UsuarioFilterDto
{
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public bool? Snativo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

// SIMPLE (para selects/dropdowns)
public class UsuarioSimpleDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Email { get; set; } = null!;
}


// TROCA DE PLANTÕES

public class CreateTrocaPlantaoDTO
{
    [Required(ErrorMessage = "ID do solicitante é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "ID do solicitante inválido")]
    public int Solicitante { get; set; }

    [Required(ErrorMessage = "ID do substituto é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "ID do substituto inválido")]
    public int Substituto { get; set; }

    [Required(ErrorMessage = "Data do plantão original é obrigatória")]
    public DateOnly PlantaoOriginal { get; set; }

    [Required(ErrorMessage = "Horário de entrada é obrigatório")]
    public TimeOnly EntradaPlantaoOriginal { get; set; }

    [Required(ErrorMessage = "Horário de saída é obrigatório")]
    public TimeOnly SaidaPlantaoOriginal { get; set; }

    [Required(ErrorMessage = "Data do plantão de troca é obrigatória")]
    public DateOnly PlantaoTroca { get; set; }

    [Required(ErrorMessage = "Horário de entrada da troca é obrigatório")]
    public TimeOnly EntradaPlantaoTroca { get; set; }

    [Required(ErrorMessage = "Horário de saída da troca é obrigatório")]
    public TimeOnly SaidaPlantaoTroca { get; set; }

    [Required(ErrorMessage = "Motivo da troca é obrigatório")]
    [MinLength(10, ErrorMessage = "Motivo deve ter no mínimo 10 caracteres")]
    public string MotivoTroca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Status é obrigatório")]
    [RegularExpression("^[SNP]$", ErrorMessage = "Status deve ser S, N ou P")]
    public string Status { get; set; } = "P";
}



public class GetTrocaPlantoesDTO()
{
    public int Id { get; set; }
    public int CdSolicitante { get; set; }
    public int CdSubstituto { get; set; }

    public DateOnly DtSolicitacao { get; set; }
    public TimeOnly EntradaPlantaoOriginal { get; set; }
    public TimeOnly SaidaPlantaoOriginal { get; set; }

    public DateOnly DtSubstituicao { get; set; }
    public TimeOnly EntradaPlantaoTroca { get; set; }
    public TimeOnly SaidaPlantaoTroca { get; set; }

    public string? NomeSolicitante { get; set; }
    public string? SetorSolicitante { get; set; }
    public string? NomeSubstituto { get; set; }
    public string? SetorSubstituto { get; set; }
}


public class UpdateTrocaPlantaoDTO
{
    public int? CdSolicitante { get; set; }

    public int? CdSubstituto { get; set; }

    public DateOnly? DtPlantaoOriginal { get; set; }

    public TimeOnly? HrEntradaPlantaoOriginal { get; set; }

    public TimeOnly? HrSaidaPlantaoOriginal { get; set; }

    public DateOnly? DtPlantaoTroca { get; set; }

    public TimeOnly? HrEntradaPlantaoTroca { get; set; }

    public TimeOnly? HrSaidaPlantaoTroca { get; set; }

    public string? MotivoTroca { get; set; }

    public string? SnAceito { get; set; }

}


// CLASSES PARA AS OPERAÇÕES DE VINCULAR COORDENADORES
public class GetVinculoCoordenadorSetorDTO
{
    public int Id { get; set; }
    public String? CdCoordenador { get; set; }

    public String? CdSetor { get; set; }

    // AQUI EU VOU ASSOCIAR POR OUTRO COTEXTO OU CHAMADA
    public string? NmCoordenador { get; set; }
    public string? NmSetor { get; set; }


}