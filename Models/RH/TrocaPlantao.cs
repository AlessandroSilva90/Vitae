using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.RH;

public partial class TrocaPlantao
{
    public int Id { get; set; }

    public int CdSolicitante { get; set; } 

    public int CdSubstituto { get; set; }

    public DateOnly DtPlantaoOriginal { get; set; }

    public TimeOnly HrEntradaPlantaoOriginal { get; set; }

    public TimeOnly HrSaidaPlantaoOriginal { get; set; }

    public DateOnly DtPlantaoTroca { get; set; }

    public TimeOnly HrEntradaPlantaoTroca { get; set; }

    public TimeOnly HrSaidaPlantaoTroca { get; set; }

    public string MotivoTroca { get; set; } = null!;

    public string? SnAceito { get; set; }

    public DateTime? DtSolicitacao { get; set; }

    public DateTime? DtResposta { get; set; }
}
