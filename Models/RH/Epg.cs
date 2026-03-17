using System;
using System.Collections.Generic;
using Core_Providentia_vitae.Models;

namespace Core_Providentia_vitae.Models;

public partial class Epg
{
    public string EmpCodigo { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public DateTime? DtNascimento { get; set; }

    public string? Nacionalidade { get; set; }

    public int? AnoChegada { get; set; }

    public string? TipoVisto { get; set; }

    public DateTime? DtValidadeRg { get; set; }

    public DateTime? DtValidadeCtps { get; set; }

    public string? MunUfdSiglaNaturalidade { get; set; }

    public string? MunCodigoNaturalidade { get; set; }

    public string? GrauInstrucao { get; set; }

    public string? RacaCor { get; set; }

    public string? Sexo { get; set; }

    public string? MaeNome { get; set; }

    public string? PaiNome { get; set; }

    public string? EstadoCivil { get; set; }

    public string? ConjugeNome { get; set; }

    public string? ConjugeCpf { get; set; }

    public DateTime? ConjugeDtNascimento { get; set; }

    public string? ContaCorrente { get; set; }

    public string? AgeBanCodigo { get; set; }

    public string? AgeCodigo { get; set; }

    public string? ContaCorrenteNumero { get; set; }

    public int ContaSalario { get; set; }

    public string? Ddd { get; set; }

    public string? Fone { get; set; }

    public string? Celular { get; set; }

    public string? EMail { get; set; }

    public string? EndLogradouro { get; set; }

    public string? EndNumero { get; set; }

    public string? EndComplemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public string? MunUfdSigla { get; set; }

    public string? MunCodigo { get; set; }

    public string? Ctpsnumero { get; set; }

    public string? Ctpsserie { get; set; }

    public string? Ctpsdv { get; set; }

    public string? UfdSiglaCtps { get; set; }

    public DateTime? CtpsdtExpedicao { get; set; }

    public string? Pis { get; set; }

    public string? Cpf { get; set; }

    public string? Titulo { get; set; }

    public string? Zona { get; set; }

    public string? Secao { get; set; }

    public string? IdentidadeNumero { get; set; }

    public string? IdentidadeOrgaoExpedidor { get; set; }

    public DateTime? IdentidadeDtExpedicao { get; set; }

    public string? Cmtipo { get; set; }

    public string? Cmnumero { get; set; }

    public string? Cmserie { get; set; }

    public string? Cmcategoria { get; set; }

    public string? CmcsmOam { get; set; }

    public string? CmrmDnComar { get; set; }

    public string? RegistroLivro { get; set; }

    public string? RegistroNumero { get; set; }

    public DateTime? AdmissaoData { get; set; }

    public string? AdmissaoTipo { get; set; }

    public string? AdmissaoNatureza { get; set; }

    public string? AdmissaoVinculo { get; set; }

    public string? Fgts { get; set; }

    public DateTime? FgtsdtOpcao { get; set; }

    public string? FgtscodCef { get; set; }

    public DateTime? ExameMedicoDtUltimo { get; set; }

    public int? ExameMedicoValidade { get; set; }

    public DateTime? FeriasDtPrevisao { get; set; }

    public DateTime? DtRescisao { get; set; }

    public string? AnoCtrSindical { get; set; }

    public string? DeficienteFisico { get; set; }

    public string? Categoria { get; set; }

    public string? Cipa { get; set; }

    public DateTime? DtAposentadoria { get; set; }

    public string? HabilitacaoNumero { get; set; }

    public DateTime? HabilitacaoEmissao { get; set; }

    public DateTime? HabilitacaoVencimento { get; set; }

    public string? HabilitacaoCategoria { get; set; }

    public int ParticipaPat { get; set; }

    public int Alvara { get; set; }

    public DateTime? DtTransferencia { get; set; }

    public byte[]? Foto { get; set; }

    public string? ExpRadiacao { get; set; }

    public string? TipoSanguineo { get; set; }

    public string? FatorRh { get; set; }

    public string? SenhaWeb { get; set; }

    public string? MunUfdSiglaIdentorgaoexped { get; set; }

    public DateTime? DtFalecimento { get; set; }

    public DateTime? DtExoneracao { get; set; }

    public string? SalarioContratual { get; set; }

    public string? HorarioPonto { get; set; }

    public string? Ano1emprego { get; set; }

    public string? Nomecomercial { get; set; }

    public string? ClausulaAssecuratoria { get; set; }

    public int? VinId { get; set; }

    public int? QualificacaoStatus { get; set; }

    public string? QualificacaoDetalhe { get; set; }

    public int SituacaoSeguroDesemprego { get; set; }

    public DateTime? DataGeracaoCaged { get; set; }

    public int? StatusCaged { get; set; }

    public string? NacionalidadeNis { get; set; }

    public string? Qualificado { get; set; }

    public string? MensagemQualificacao { get; set; }

    public string? PaisNascimento { get; set; }

    public string? PaisNacionalidade { get; set; }

    public int TemDeficiencia { get; set; }

    public int DeficienciaFisica { get; set; }

    public int DeficienciaVisual { get; set; }

    public int DeficienciaAuditiva { get; set; }

    public int DeficienciaMental { get; set; }

    public int DeficienciaIntelectual { get; set; }

    public int DeficienciaReabilitado { get; set; }

    public string? DeficienciaObservacoes { get; set; }

    public DateTime? EstrangeiroDtChegada { get; set; }

    public string? EstrangeiroClassificacao { get; set; }

    public int EstrangeiroCasadoBr { get; set; }

    public int EstrangeiroFilhosBr { get; set; }

    public string? PaisResidencia { get; set; }

    public string? ExteriorCidade { get; set; }

    public string? ExteriorLogradouro { get; set; }

    public string? ExteriorNumero { get; set; }

    public string? ExteriorComplemento { get; set; }

    public string? ExteriorBairro { get; set; }

    public string? ExteriorCodigoPostal { get; set; }

    public int TemHabilitacao { get; set; }

    public int TemRic { get; set; }

    public string? Ricnumero { get; set; }

    public string? RicorgaoExpedidor { get; set; }

    public DateTime? RicdtExpedicao { get; set; }

    public string? Rnenumero { get; set; }

    public string? RneorgaoExpedidor { get; set; }

    public DateTime? RnedtExpedicao { get; set; }

    public int TemOrgaoClasse { get; set; }

    public string? OrgaoClasseNumero { get; set; }

    public string? OrgaoClasseOrgaoExpedidor { get; set; }

    public DateTime? OrgaoClasseDtExpedicao { get; set; }

    public DateTime? OrgaoClasseDtValidade { get; set; }

    public string? AdmissaoIndicativo { get; set; }

    public string? AdmissaoTipoEsocial { get; set; }

    public string? EMailAlternativo { get; set; }

    public DateTime? HabilitacaoDataPrimeira { get; set; }

    public string? HabilitacaoUf { get; set; }

    public int? IdExterno { get; set; }

    public string? AlvaraPajCodigo { get; set; }

    public int? HipoteseLegalTrabTemp { get; set; }

    public string? JustificativaTrabTemp { get; set; }

    public int? InclusaoContratoTrabTemp { get; set; }

    public string? NomeSocial { get; set; }

    public string? Dddalternativo { get; set; }

    public int PreencheCotaDeficiencia { get; set; }

    public int? IndicativoProvimento { get; set; }

    public int? TipoProvimento { get; set; }

    public DateTime? DataNomeacao { get; set; }

    public DateTime? DataPosse { get; set; }

    public DateTime? DataExercicio { get; set; }

    public string? ProcJudPajCodigo { get; set; }

    public string? CnpjempregadorAnterior { get; set; }

    public string? MatriculaAnterior { get; set; }

    public string? ObservacaoVinculoAnterior { get; set; }

    public string? CategOrigSindical { get; set; }

    public string? CnpjorigSindical { get; set; }

    public DateTime? DtAdmOrigSindical { get; set; }

    public string? MatricOrigSindical { get; set; }

    public string? CategOrigCedido { get; set; }

    public string? CnpjorigCedido { get; set; }

    public string? MatricOrigCedido { get; set; }

    public DateTime? DtAdmCedido { get; set; }

    public int? TipRegimTrabCedido { get; set; }

    public int? TipRegimPrevCedido { get; set; }

    public int? OnusCedido { get; set; }

    public string? CnpjcpfempContratanteTrabTemp { get; set; }

    public string? CnpjcpfestContratanteTrabTemp { get; set; }

    public string? CpftrabalhadorSubstTrabTemp { get; set; }

    public int? IdCepg { get; set; }

    public int Acao { get; set; }

    public int Status { get; set; }

    public string? CodigoEvento { get; set; }

    public string? CnpjcpfempMenorApren { get; set; }

    public DateTime? DtIniAfastAnterior { get; set; }

    public string? TliCodigoAfastAnterior { get; set; }

    public int? ExcluiSomenteEsocial { get; set; }

    public string? Cnpjsucessora { get; set; }

    public string? OrgaoClasseUf { get; set; }

    public string? Ricuf { get; set; }

    public string? Rneuf { get; set; }

    public string? CodMotivoDesligTsv { get; set; }

    public string? MatriculaEsocial { get; set; }

    public int? Aposentadoria { get; set; }

    public int? TpInscAnt { get; set; }

    public string? RegTrabOrigSindical { get; set; }

    public string? RegPrevOrigSindical { get; set; }

    public string? CategOrigMandElet { get; set; }

    public string? CnpjOrigMandElet { get; set; }

    public string? MatricOrigMandElet { get; set; }

    public DateTime? DtExercOrigMandElet { get; set; }

    public string? IndRemunMandElet { get; set; }

    public int? TipRegimTrabMandElet { get; set; }

    public int? TipRegimPrevMandElet { get; set; }

    public int? Tipoinstituicaopag { get; set; }

    public string? Numeroalvara { get; set; }

    public string? ProcTrabDesligTsvPjuCodigo { get; set; }

    public string? ProcessoTrabPjuCodigo { get; set; }

    public DateTime? DataAdmissaoAnt { get; set; }

    public int? IndRemunAposDesligTsv { get; set; }

    public DateTime? DtFimRemunAposDesligTsv { get; set; }

    public DateTime? Dtpagamentofgtstsv { get; set; }

    public string? Matriculajudicial { get; set; }

    // RELACIONAMENTO

    public ICollection<Sep> Sep { get; } = new List<Sep>();

}
