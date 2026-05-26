using System;
using System.Collections.Generic;
using Core_Providentia_vitae.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Providentia_vitae.Data;

public partial class MssqlContext : DbContext
{
    public MssqlContext()
    {
    }

    public MssqlContext(DbContextOptions<MssqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Epg> Epg { get; set; }
    public virtual DbSet<Sep> Sep { get; set; }
    public virtual DbSet<Lot> Setores { get; set; }
    public virtual DbSet<Car> Cargos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Epg>(entity =>
        {
            entity.HasKey(e => new { e.Codigo }).HasName("pk_EPG");

            entity.ToTable("EPG");

            entity.HasIndex(e => e.Cpf, "I_EPG_CPF").HasFillFactor(70);

            entity.Property(e => e.EmpCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("EMP_Codigo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Acao).HasDefaultValue(1);
            entity.Property(e => e.AdmissaoData).HasColumnType("datetime");
            entity.Property(e => e.AdmissaoIndicativo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmissaoNatureza)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.AdmissaoTipo)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.AdmissaoTipoEsocial)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("AdmissaoTipoESocial");
            entity.Property(e => e.AdmissaoVinculo)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.AgeBanCodigo)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("AGE_BAN_Codigo");
            entity.Property(e => e.AgeCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("AGE_Codigo");
            entity.Property(e => e.AlvaraPajCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Alvara_PAJ_Codigo");
            entity.Property(e => e.Ano1emprego)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("ANO1EMPREGO");
            entity.Property(e => e.AnoCtrSindical)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Aposentadoria).HasColumnName("APOSENTADORIA");
            entity.Property(e => e.Bairro)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.CategOrigCedido)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CategOrigMandElet)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.CategOrigSindical)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Categoria)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Cep)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("CEP");
            entity.Property(e => e.Cipa)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CIPA");
            entity.Property(e => e.ClausulaAssecuratoria)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Cmcategoria)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CMCategoria");
            entity.Property(e => e.CmcsmOam)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CMCSM_OAM");
            entity.Property(e => e.Cmnumero)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CMNumero");
            entity.Property(e => e.CmrmDnComar)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CMRM_DN_COMAR");
            entity.Property(e => e.Cmserie)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("CMSerie");
            entity.Property(e => e.Cmtipo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("CMTipo");
            entity.Property(e => e.CnpjOrigMandElet)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.CnpjcpfempContratanteTrabTemp)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJCPFEmpContratanteTrabTemp");
            entity.Property(e => e.CnpjcpfempMenorApren)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJCPFEmpMenorApren");
            entity.Property(e => e.CnpjcpfestContratanteTrabTemp)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJCPFEstContratanteTrabTemp");
            entity.Property(e => e.CnpjempregadorAnterior)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJEmpregadorAnterior");
            entity.Property(e => e.CnpjorigCedido)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJOrigCedido");
            entity.Property(e => e.CnpjorigSindical)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJOrigSindical");
            entity.Property(e => e.Cnpjsucessora)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("CNPJSUCESSORA");
            entity.Property(e => e.CodMotivoDesligTsv)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CodMotivoDesligTSV");
            entity.Property(e => e.CodigoEvento)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CODIGO_EVENTO");
            entity.Property(e => e.ConjugeCpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("ConjugeCPF");
            entity.Property(e => e.ConjugeDtNascimento).HasColumnType("datetime");
            entity.Property(e => e.ConjugeNome)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.ContaCorrente)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ContaCorrenteNumero)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.CpftrabalhadorSubstTrabTemp)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPFTrabalhadorSubstTrabTemp");
            entity.Property(e => e.CtpsdtExpedicao)
                .HasColumnType("datetime")
                .HasColumnName("CTPSDtExpedicao");
            entity.Property(e => e.Ctpsdv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("CTPSDV");
            entity.Property(e => e.Ctpsnumero)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CTPSNumero");
            entity.Property(e => e.Ctpsserie)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("CTPSSerie");
            entity.Property(e => e.DataAdmissaoAnt).HasColumnType("datetime");
            entity.Property(e => e.DataExercicio).HasColumnType("datetime");
            entity.Property(e => e.DataGeracaoCaged)
                .HasColumnType("datetime")
                .HasColumnName("DataGeracaoCAGED");
            entity.Property(e => e.DataNomeacao).HasColumnType("datetime");
            entity.Property(e => e.DataPosse).HasColumnType("datetime");
            entity.Property(e => e.Ddd)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("DDD");
            entity.Property(e => e.Dddalternativo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("DDDAlternativo");
            entity.Property(e => e.DeficienciaObservacoes).HasColumnType("text");
            entity.Property(e => e.DeficienteFisico)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.DtAdmCedido).HasColumnType("datetime");
            entity.Property(e => e.DtAdmOrigSindical).HasColumnType("datetime");
            entity.Property(e => e.DtAposentadoria).HasColumnType("datetime");
            entity.Property(e => e.DtExercOrigMandElet).HasColumnType("datetime");
            entity.Property(e => e.DtExoneracao).HasColumnType("datetime");
            entity.Property(e => e.DtFalecimento).HasColumnType("datetime");
            entity.Property(e => e.DtFimRemunAposDesligTsv)
                .HasColumnType("datetime")
                .HasColumnName("DtFimRemunAposDesligTSV");
            entity.Property(e => e.DtIniAfastAnterior).HasColumnType("datetime");
            entity.Property(e => e.DtNascimento).HasColumnType("datetime");
            entity.Property(e => e.DtRescisao).HasColumnType("datetime");
            entity.Property(e => e.DtTransferencia).HasColumnType("datetime");
            entity.Property(e => e.DtValidadeCtps)
                .HasColumnType("datetime")
                .HasColumnName("DtValidadeCTPS");
            entity.Property(e => e.DtValidadeRg)
                .HasColumnType("datetime")
                .HasColumnName("DtValidadeRG");
            entity.Property(e => e.Dtpagamentofgtstsv)
                .HasColumnType("datetime")
                .HasColumnName("DTPAGAMENTOFGTSTSV");
            entity.Property(e => e.EMail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eMail");
            entity.Property(e => e.EMailAlternativo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eMailAlternativo");
            entity.Property(e => e.EndComplemento)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EndLogradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndNumero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.EstrangeiroClassificacao)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.EstrangeiroDtChegada).HasColumnType("datetime");
            entity.Property(e => e.ExameMedicoDtUltimo).HasColumnType("datetime");
            entity.Property(e => e.ExcluiSomenteEsocial).HasColumnName("ExcluiSomenteESocial");
            entity.Property(e => e.ExpRadiacao)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ExteriorBairro)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.ExteriorCidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ExteriorCodigoPostal)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.ExteriorComplemento)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ExteriorLogradouro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ExteriorNumero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FatorRh)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FatorRH");
            entity.Property(e => e.FeriasDtPrevisao).HasColumnType("datetime");
            entity.Property(e => e.Fgts)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("FGTS");
            entity.Property(e => e.FgtscodCef)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("FGTSCodCEF");
            entity.Property(e => e.FgtsdtOpcao)
                .HasColumnType("datetime")
                .HasColumnName("FGTSDtOpcao");
            entity.Property(e => e.Fone)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.Foto)
                .HasColumnType("image")
                .HasColumnName("foto");
            entity.Property(e => e.GrauInstrucao)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.HabilitacaoCategoria)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.HabilitacaoDataPrimeira).HasColumnType("datetime");
            entity.Property(e => e.HabilitacaoEmissao).HasColumnType("datetime");
            entity.Property(e => e.HabilitacaoNumero)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.HabilitacaoUf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("HabilitacaoUF");
            entity.Property(e => e.HabilitacaoVencimento).HasColumnType("datetime");
            entity.Property(e => e.HorarioPonto).HasColumnType("text");
            entity.Property(e => e.IdCepg).HasColumnName("ID_CEPG");
            entity.Property(e => e.IdExterno).HasColumnName("ID_Externo");
            entity.Property(e => e.IdentidadeDtExpedicao).HasColumnType("datetime");
            entity.Property(e => e.IdentidadeNumero)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.IdentidadeOrgaoExpedidor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.IndRemunAposDesligTsv).HasColumnName("IndRemunAposDesligTSV");
            entity.Property(e => e.IndRemunMandElet)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.JustificativaTrabTemp).HasColumnType("text");
            entity.Property(e => e.MaeNome)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.MatricOrigCedido)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MatricOrigMandElet)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MatricOrigSindical)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MatriculaAnterior)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.MatriculaEsocial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MatriculaESocial");
            entity.Property(e => e.Matriculajudicial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("MATRICULAJUDICIAL");
            entity.Property(e => e.MensagemQualificacao).HasColumnType("text");
            entity.Property(e => e.MunCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MUN_Codigo");
            entity.Property(e => e.MunCodigoNaturalidade)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MUN_Codigo_Naturalidade");
            entity.Property(e => e.MunUfdSigla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("MUN_UFD_Sigla");
            entity.Property(e => e.MunUfdSiglaIdentorgaoexped)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("MUN_UFD_SIGLA_IDENTORGAOEXPED");
            entity.Property(e => e.MunUfdSiglaNaturalidade)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("MUN_UFD_Sigla_Naturalidade");
            entity.Property(e => e.Nacionalidade)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.NacionalidadeNis)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("NACIONALIDADE_NIS");
            entity.Property(e => e.Nome)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.NomeSocial)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Nomecomercial)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMECOMERCIAL");
            entity.Property(e => e.Numeroalvara)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NUMEROALVARA");
            entity.Property(e => e.ObservacaoVinculoAnterior).HasColumnType("text");
            entity.Property(e => e.OrgaoClasseDtExpedicao).HasColumnType("datetime");
            entity.Property(e => e.OrgaoClasseDtValidade).HasColumnType("datetime");
            entity.Property(e => e.OrgaoClasseNumero)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.OrgaoClasseOrgaoExpedidor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OrgaoClasseUf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("OrgaoClasseUF");
            entity.Property(e => e.PaiNome)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.PaisNacionalidade)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.PaisNascimento)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.PaisResidencia)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ParticipaPat).HasColumnName("ParticipaPAT");
            entity.Property(e => e.Pis)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("PIS");
            entity.Property(e => e.ProcJudPajCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ProcJud_PAJ_Codigo");
            entity.Property(e => e.ProcTrabDesligTsvPjuCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ProcTrabDesligTSV_PJU_Codigo");
            entity.Property(e => e.ProcessoTrabPjuCodigo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("ProcessoTrab_PJU_Codigo");
            entity.Property(e => e.QualificacaoDetalhe).HasColumnType("text");
            entity.Property(e => e.Qualificado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N");
            entity.Property(e => e.RacaCor)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RegPrevOrigSindical)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RegTrabOrigSindical)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.RegistroLivro)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.RegistroNumero)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.RicdtExpedicao)
                .HasColumnType("datetime")
                .HasColumnName("RICDtExpedicao");
            entity.Property(e => e.Ricnumero)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("RICNumero");
            entity.Property(e => e.RicorgaoExpedidor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RICOrgaoExpedidor");
            entity.Property(e => e.Ricuf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("RICUF");
            entity.Property(e => e.RnedtExpedicao)
                .HasColumnType("datetime")
                .HasColumnName("RNEDtExpedicao");
            entity.Property(e => e.Rnenumero)
                .HasMaxLength(14)
                .IsUnicode(false)
                .HasColumnName("RNENumero");
            entity.Property(e => e.RneorgaoExpedidor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("RNEOrgaoExpedidor");
            entity.Property(e => e.Rneuf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("RNEUF");
            entity.Property(e => e.SalarioContratual)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Secao)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.SenhaWeb)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.SituacaoSeguroDesemprego).HasDefaultValue(3);
            entity.Property(e => e.Status).HasDefaultValue(99);
            entity.Property(e => e.StatusCaged).HasColumnName("StatusCAGED");
            entity.Property(e => e.TemRic).HasColumnName("TemRIC");
            entity.Property(e => e.TipoSanguineo)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.TipoVisto)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.Tipoinstituicaopag).HasColumnName("TIPOINSTITUICAOPAG");
            entity.Property(e => e.Titulo)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.TliCodigoAfastAnterior)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("TLI_CodigoAfastAnterior");
            entity.Property(e => e.TpInscAnt).HasColumnName("tpInscAnt");
            entity.Property(e => e.UfdSiglaCtps)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("UFD_Sigla_CTPS");
            entity.Property(e => e.VinId).HasColumnName("VIN_ID");
            entity.Property(e => e.Zona)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Sep>(entity =>
            {
                entity.HasKey(e => new { e.EmpCodigo, e.EpgCodigo, e.Data }).HasName("pk_SEP");

                entity.ToTable("SEP");

                entity.HasIndex(e => new { e.EmpCodigo, e.EpgCodigo, e.Data, e.CategoriaEsocial }, "I_SEP_CATEGORIAESOCIAL").HasFillFactor(70);

                entity.Property(e => e.EmpCodigo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("EMP_Codigo");
                entity.Property(e => e.EpgCodigo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("EPG_Codigo");
                entity.Property(e => e.Data).HasColumnType("datetime");
                entity.Property(e => e.Acao).HasDefaultValue(1);
                entity.Property(e => e.AdiantTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("P");
                entity.Property(e => e.Adiantamento)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.AinCodigo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("AIN_Codigo");
                entity.Property(e => e.AreaEstagio)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.BairroTrab)
                    .HasMaxLength(90)
                    .IsUnicode(false);
                entity.Property(e => e.BatePonto).HasDefaultValue(1);
                entity.Property(e => e.CarCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CAR_codigo");
                entity.Property(e => e.CategoriaEsocial)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CategoriaESocial");
                entity.Property(e => e.Ceptrab)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CEPTrab");
                entity.Property(e => e.CesCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CES_Codigo");
                entity.Property(e => e.CodigoEvento)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_EVENTO");
                entity.Property(e => e.CpbCodigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CPB_Codigo");
                entity.Property(e => e.CpfsupervisorEstagio)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPFSupervisorEstagio");
                entity.Property(e => e.DataCarreiraPub).HasColumnType("datetime");
                entity.Property(e => e.DescAltContratual)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.DescComplLocalTrabalho)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                entity.Property(e => e.DescContribSindical).HasDefaultValue(1);
                entity.Property(e => e.DescSalVariavel)
                    .HasMaxLength(90)
                    .IsUnicode(false);
                entity.Property(e => e.DescontoVale)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.DhorOrdemDia).HasColumnName("DHOR_OrdemDia");
                entity.Property(e => e.DsrporOcorrencia).HasColumnName("DSRPorOcorrencia");
                entity.Property(e => e.DtTerminoEstagio).HasColumnType("datetime");
                entity.Property(e => e.DtTerminoPrazo).HasColumnType("datetime");
                entity.Property(e => e.Dtretroativa)
                    .HasColumnType("datetime")
                    .HasColumnName("DTRETROATIVA");
                entity.Property(e => e.EduCodigo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("EDU_Codigo");
                entity.Property(e => e.EduCodigoAprendiz)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("EDU_CODIGO_APRENDIZ");
                entity.Property(e => e.EeaCodigoEfetivacao)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("EEA_CODIGO_EFETIVACAO");
                entity.Property(e => e.EeaCodigoPratica)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("EEA_CODIGO_PRATICA");
                entity.Property(e => e.EndComplementoTrab)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.EndLogradouroTrab)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.EndNumeroTrab)
                    .HasMaxLength(10)
                    .IsUnicode(false);
                entity.Property(e => e.EstCodigo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("EST_Codigo");
                entity.Property(e => e.ExpAgeNociv)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.FunCodigo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("FUN_CODIGO");
                entity.Property(e => e.HorCodigo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("HOR_Codigo");
                entity.Property(e => e.HorarioIntervalo)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.IndCodigoSalario)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("IND_Codigo_Salario");
                entity.Property(e => e.IndRemunMandElet)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Indcontrataaprendiz).HasColumnName("INDCONTRATAAPRENDIZ");
                entity.Property(e => e.IpsId).HasColumnName("IPS_ID");
                entity.Property(e => e.JustifProrrogTrabTemp).HasColumnType("text");
                entity.Property(e => e.LotCodigo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LOT_Codigo");
                entity.Property(e => e.MseCodigo)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("MSE_Codigo");
                entity.Property(e => e.MslId).HasColumnName("MSL_Id");
                entity.Property(e => e.MunCodigoTrab)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MUN_CodigoTrab");
                entity.Property(e => e.MunUfdSiglaTrab)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("MUN_UFD_SiglaTrab");
                entity.Property(e => e.NaturezaAtividade)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.NaturezaEstagio)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.NomeSupervisorEstagio)
                    .HasMaxLength(70)
                    .IsUnicode(false);
                entity.Property(e => e.NumeroApolice)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Objdet)
                    .HasColumnType("text")
                    .HasColumnName("OBJDET");
                entity.Property(e => e.Origem).HasColumnName("ORIGEM");
                entity.Property(e => e.OutrosVinculos)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.PrazoDeterminado)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Prorrogautomatica)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("N")
                    .HasColumnName("PRORROGAUTOMATICA");
                entity.Property(e => e.Qtddiasprazo).HasColumnName("qtddiasprazo");
                entity.Property(e => e.Qtddiasprazoprorrogacao).HasColumnName("qtddiasprazoprorrogacao");
                entity.Property(e => e.RegimeJornada)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.RegimePrevidenciario)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.RegimeTrabalho)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Retroativa).HasColumnName("RETROATIVA");
                entity.Property(e => e.RhSepId).HasColumnName("RH_SEP_ID");
                entity.Property(e => e.SalContratual)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.SalTipo)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.SinCodigo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SIN_Codigo");
                entity.Property(e => e.Status).HasDefaultValue(99);
                entity.Property(e => e.TipoPagamento)
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.TipoSalario)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.TomCodigo)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("TOM_Codigo");
                entity.Property(e => e.ValeTransporte)
                    .HasMaxLength(1)
                    .IsUnicode(false);
                entity.Property(e => e.Vintipo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValue("0")
                    .HasColumnName("VINTIPO");
                entity.Property(e => e.VrfTipo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("VRF_Tipo");
            });

        modelBuilder.Entity<Car>(entity =>
                {
                    entity.HasKey(e => new { e.Codigo }).HasName("pk_CAR");

                    entity.ToTable("CAR");

                    entity.HasIndex(e => new { e.Nome }, "UK_CAR_NOME").IsUnique();

                    entity.Property(e => e.EmpCodigo)
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnName("EMP_Codigo");
                    entity.Property(e => e.Codigo)
                        .HasMaxLength(3)
                        .IsUnicode(false);
                    entity.Property(e => e.Cbo2009Codigo)
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnName("CBO2009_Codigo");
                    entity.Property(e => e.CboCodigo)
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnName("CBO_Codigo");
                    entity.Property(e => e.CodigoEsocial)
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnName("CODIGO_ESOCIAL");
                    entity.Property(e => e.IdExterno)
                        .HasDefaultValueSql("(NULL)")
                        .HasColumnName("ID_EXTERNO");
                    entity.Property(e => e.Nome)
                        .HasMaxLength(100)
                        .IsUnicode(false);
                    entity.Property(e => e.NomeFaixaRh)
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnName("NOME_FAIXA_RH");
                    entity.Property(e => e.ObbCodigo)
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnName("OBB_Codigo");
                    entity.Property(e => e.ObrCodigo)
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnName("OBR_Codigo");
                    entity.Property(e => e.RhCar)
                        .HasDefaultValue(0)
                        .HasColumnName("RH_CAR");
                    entity.Property(e => e.SincronizadoConecta)
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasDefaultValue("N");
                });

        modelBuilder.Entity<Lot>(entity =>
        {
            entity.HasKey(e => new { e.Codigo }).HasName("pk_LOT");

            entity.ToTable("LOT", tb =>
                {
                    tb.HasTrigger("t_LOT_BeforeInsert");
                    tb.HasTrigger("t_LOT_BeforeUpdate");
                });

            entity.Property(e => e.EmpCodigo)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("EMP_Codigo");
            entity.Property(e => e.Codigo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CrsCodigo)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CRS_CODIGO");
            entity.Property(e => e.IdExterno)
                .HasDefaultValueSql("(NULL)")
                .HasColumnName("ID_EXTERNO");
            entity.Property(e => e.LotCodigoMae)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOT_Codigo_Mae");
            entity.Property(e => e.Nome)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.RhLot)
                .HasDefaultValue(0)
                .HasColumnName("RH_LOT");
            entity.Property(e => e.SincronizadoConecta)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("N");
        });


        OnModelCreatingPartial(modelBuilder);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
