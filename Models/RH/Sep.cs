using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models;

public partial class Sep
{
    public string EmpCodigo { get; set; } = null!;

    public string EpgCodigo { get; set; } = null!;

    public DateTime Data { get; set; }

    public string CarCodigo { get; set; } = null!;

    public string? IndCodigoSalario { get; set; }

    public string EstCodigo { get; set; } = null!;

    public string HorCodigo { get; set; } = null!;

    public string LotCodigo { get; set; } = null!;

    public string? SinCodigo { get; set; }

    public string? TomCodigo { get; set; }

    public string SalContratual { get; set; } = null!;

    public string SalTipo { get; set; } = null!;

    public string ExpAgeNociv { get; set; } = null!;

    public double Valor { get; set; }

    public double IndQtde { get; set; }

    public double ValeTransporteAliq { get; set; }

    public string TipoPagamento { get; set; } = null!;

    public string? ValeTransporte { get; set; }

    public string? DescontoVale { get; set; }

    public string? HorarioIntervalo { get; set; }

    public string? OutrosVinculos { get; set; }

    public double? RemunerOutrosVinculos { get; set; }

    public double? DescOutrosVinculos { get; set; }

    public int ValeRefeicao { get; set; }

    public string? VrfTipo { get; set; }

    public string? Adiantamento { get; set; }

    public double? PercentualAdiant { get; set; }

    public int BatePonto { get; set; }

    public int? MslId { get; set; }

    public string AdiantTipo { get; set; } = null!;

    public double? ValorAdiant { get; set; }

    public int? RhSepId { get; set; }

    public string? CesCodigo { get; set; }

    public int? IpsId { get; set; }

    public int DsrporOcorrencia { get; set; }

    public int Retroativa { get; set; }

    public DateTime? Dtretroativa { get; set; }

    public string Vintipo { get; set; } = null!;

    public string? TipoSalario { get; set; }

    public int Comissionado { get; set; }

    public string? MseCodigo { get; set; }

    public int Acao { get; set; }

    public int? DhorOrdemDia { get; set; }

    public string? FunCodigo { get; set; }

    public int? Origem { get; set; }

    public string? RegimeJornada { get; set; }

    public string? RegimePrevidenciario { get; set; }

    public string? CategoriaEsocial { get; set; }

    public string? RegimeTrabalho { get; set; }

    public string? NaturezaAtividade { get; set; }

    public string? EndLogradouroTrab { get; set; }

    public string? EndNumeroTrab { get; set; }

    public string? EndComplementoTrab { get; set; }

    public string? BairroTrab { get; set; }

    public string? Ceptrab { get; set; }

    public string? MunUfdSiglaTrab { get; set; }

    public string? MunCodigoTrab { get; set; }

    public string? DescSalVariavel { get; set; }

    public string? PrazoDeterminado { get; set; }

    public int? Qtddiasprazo { get; set; }

    public int? Qtddiasprazoprorrogacao { get; set; }

    public DateTime? DtTerminoPrazo { get; set; }

    public string? CpbCodigo { get; set; }

    public string? NaturezaEstagio { get; set; }

    public int? NivelEstagio { get; set; }

    public string? AreaEstagio { get; set; }

    public string? NumeroApolice { get; set; }

    public DateTime? DtTerminoEstagio { get; set; }

    public string? CpfsupervisorEstagio { get; set; }

    public string? NomeSupervisorEstagio { get; set; }

    public string? EduCodigo { get; set; }

    public string? AinCodigo { get; set; }

    public int? TipoPlanoSegregacao { get; set; }

    public string? JustifProrrogTrabTemp { get; set; }

    public DateTime? DataCarreiraPub { get; set; }

    public int? MotAltServidor { get; set; }

    public string? DescAltContratual { get; set; }

    public string? DescComplLocalTrabalho { get; set; }

    public int Status { get; set; }

    public string? CodigoEvento { get; set; }

    public int DescContribSindical { get; set; }

    public string? Objdet { get; set; }

    public double HorasMes { get; set; }

    public double HorasSemana { get; set; }

    public string? IndRemunMandElet { get; set; }

    public int? TipRegimPrevMandElet { get; set; }

    public int? Indcontrataaprendiz { get; set; }

    public string? EduCodigoAprendiz { get; set; }

    public string? EeaCodigoEfetivacao { get; set; }

    public string? EeaCodigoPratica { get; set; }

    public string Prorrogautomatica { get; set; } = null!;


    // RELACIONAMENTO
    public Epg Epg { get; set; } = null!;
    public Lot Lot { get; set; } = null!;
}
