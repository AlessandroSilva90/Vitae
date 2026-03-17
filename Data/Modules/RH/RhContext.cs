using System;
using System.Collections.Generic;
using Core_Providentia_vitae.Models.RH;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Core_Providentia_vitae.Data.RH;

public partial class RhContext : DbContext
{
    public RhContext()
    {
    }

    public RhContext(DbContextOptions<RhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrocaPlantao> TrocaPlantaos { get; set; }
    public virtual DbSet<CoordenadorSetor> CoordenadorSetors { get; set; }
    public virtual DbSet<CoordenadorUsuario> CoordenadorUsuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
         .UseCollation("utf8mb4_0900_ai_ci")
         .HasCharSet("utf8mb4");

        modelBuilder.Entity<TrocaPlantao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("troca_plantao");

            entity.HasIndex(e => e.DtPlantaoOriginal, "idx_dt_plantao_original");
            entity.HasIndex(e => e.CdSolicitante, "idx_solicitante");
            entity.HasIndex(e => e.CdSubstituto, "idx_substituto");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.CdSolicitante)
                .HasMaxLength(20)
                .HasColumnName("cd_solicitante");

            entity.Property(e => e.CdSubstituto)
                .HasMaxLength(20)
                .HasColumnName("cd_substituto");

            entity.Property(e => e.DtPlantaoOriginal).HasColumnName("dt_plantao_original");
            entity.Property(e => e.DtPlantaoTroca).HasColumnName("dt_plantao_troca");

            entity.Property(e => e.DtResposta)
                .HasColumnType("datetime")
                .HasColumnName("dt_resposta");

            entity.Property(e => e.DtSolicitacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_solicitacao");

            // ADICIONE ESTAS CONVERSÕES PARA TimeOnly:
            entity.Property(e => e.HrEntradaPlantaoOriginal)
                .HasConversion(
                    v => v.ToTimeSpan(), // Converte TimeOnly para TimeSpan ao salvar
                    v => TimeOnly.FromTimeSpan(v) // Converte TimeSpan para TimeOnly ao ler
                )
                .HasColumnType("time")
                .HasColumnName("hr_entrada_plantao_original");

            entity.Property(e => e.HrSaidaPlantaoOriginal)
                .HasConversion(
                    v => v.ToTimeSpan(),
                    v => TimeOnly.FromTimeSpan(v)
                )
                .HasColumnType("time")
                .HasColumnName("hr_saida_plantao_original");

            entity.Property(e => e.HrEntradaPlantaoTroca)
                .HasConversion(
                    v => v.ToTimeSpan(),
                    v => TimeOnly.FromTimeSpan(v)
                )
                .HasColumnType("time")
                .HasColumnName("hr_entrada_plantao_troca");

            entity.Property(e => e.HrSaidaPlantaoTroca)
                .HasConversion(
                    v => v.ToTimeSpan(),
                    v => TimeOnly.FromTimeSpan(v)
                )
                .HasColumnType("time")
                .HasColumnName("hr_saida_plantao_troca");

            entity.Property(e => e.MotivoTroca)
                .HasColumnType("text")
                .HasColumnName("motivo_troca");

            entity.Property(e => e.SnAceito)
                .HasDefaultValueSql("'P'")
                .HasColumnType("enum('S','N','P')")
                .HasColumnName("sn_aceito");
        });


        // A PARTIR DAQUI É A TABELA DE VINCUALR COODENADOR AO SETOR

        modelBuilder.Entity<CoordenadorSetor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("coordenador_setor");

            entity.HasIndex(e => e.CdCoordenador, "cd_coordenador");

            entity.HasIndex(e => e.CdSetor, "setor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CdCoordenador)
                .HasColumnType("varchar(50)") 
                .HasDefaultValueSql("'0'")
                .HasColumnName("cd_coordenador");
            entity.Property(e => e.CdSetor)
                .HasColumnType("varchar(50)") 
                .HasDefaultValueSql("'0'")
                .HasColumnName("cd_setor");
            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("dt_create");
            entity.Property(e => e.DtFim).HasColumnName("dt_fim");
            entity.Property(e => e.DtInicio).HasColumnName("dt_inicio");
        });

        // A PARTIR DAQUI É A TABELA DE VINCUALR COODENADOR AO USUÁRIO
        modelBuilder.Entity<CoordenadorUsuario>(entity =>
                {
                    entity.HasKey(e => e.Id).HasName("PRIMARY");

                    entity.ToTable("coordenador_usuario");

                    entity.HasIndex(e => e.CdCoordenador, "cd_coordenador");

                    entity.HasIndex(e => e.CdFuncionario, "cd_funcionario");

                    entity.Property(e => e.Id).HasColumnName("id");
                    entity.Property(e => e.CdCoordenador).HasColumnName("cd_coordenador");
                    entity.Property(e => e.CdFuncionario).HasColumnName("cd_funcionario");
                    entity.Property(e => e.DtCreate)
                        .HasDefaultValueSql("CURRENT_TIMESTAMP")
                        .HasColumnType("datetime")
                        .HasColumnName("dt_create");
                    entity.Property(e => e.DtFim).HasColumnName("dt_fim");
                    entity.Property(e => e.DtInicio).HasColumnName("dt_inicio");
                });

    }

    // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

