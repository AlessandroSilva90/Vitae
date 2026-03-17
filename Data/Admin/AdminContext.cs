using System;
using System.Collections.Generic;
using Core_Providentia_vitae.Models.Admin;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Core_Providentia_vitae.Data.Admin;

public partial class AdminContext : DbContext
{
    public AdminContext()
    {
    }

    public AdminContext(DbContextOptions<AdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UsuarioModulo> UsuarioModulos { get; set; }
    public virtual DbSet<Modulo> Modulos { get; set; }
    public virtual DbSet<Perfil> Perfils { get; set; }
    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<MenuModulo> MenuModulos { get; set; }
    public virtual DbSet<MenuModuloPerfil> MenuModuloPerfils { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<UsuarioModulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario_modulos");


            entity.HasIndex(e => e.CdModulo, "cd_modulo");

            entity.HasIndex(e => e.CdUsuario, "cd_usuario");

            entity.HasOne(um => um.Usuario)
            .WithMany(u => u.UsuarioModulos)
            .HasForeignKey(um => um.CdUsuario);


            entity.HasOne(um => um.Modulo)
                .WithMany(m => m.UsuarioModulos)
                .HasForeignKey(um => um.CdModulo);


            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CdModulo).HasColumnName("cd_modulo");
            entity.Property(e => e.CdUsuario).HasColumnName("cd_usuario");
        });


        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modulos");

            entity.Property(e => e.NmModulos)
            .HasColumnName("nmModulos");

            entity.Property(e => e.SnAtivo)
            .HasDefaultValue(true)
            .HasColumnName("snAtivo");


            entity.Property(e => e.DtCreate)
           .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
           .HasColumnName("DtCreate");

        });

        modelBuilder.Entity<Perfil>(entity =>
    {
        entity.HasKey(e => e.Id).HasName("PRIMARY");

        entity.ToTable("perfil");  // Nome da tabela no banco

        entity.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();  // Auto-increment

        entity.Property(e => e.DsPefil)
            .IsRequired()
            .HasMaxLength(255)  // Defina um tamanho adequado
            .HasColumnName("ds_perfil");

        entity.Property(e => e.SnAtivo)
            .HasDefaultValue(true)
            .HasColumnName("sn_ativo");

        entity.Property(e => e.DtCreate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
            .HasColumnName("dt_create");
    });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("menu");  // Nome da tabela no banco

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();  // Auto-increment

            entity.Property(e => e.nmMenu)
                .IsRequired()
                .HasMaxLength(255)  // Defina um tamanho adequado
                .HasColumnName("nmMenu");

            entity.Property(e => e.SnAtivo)
                .HasDefaultValue(true)
                .HasColumnName("sn_ativo");

            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("dt_create");
        });

        modelBuilder.Entity<MenuModulo>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PRIMARY");

              entity.ToTable("menu_modulos");

              entity.HasIndex(e => e.cd_Menu, "cd_menu");

              entity.HasIndex(e => e.cd_Modulo, "cd_modulo");

              entity.HasOne(mm => mm.Menu)
              .WithMany(u => u.MenuModulos)
              .HasForeignKey(mm => mm.cd_Menu);


              entity.HasOne(um => um.Modulo)
                  .WithMany(m => m.MenuModulos)
                  .HasForeignKey(um => um.cd_Modulo);

              // Índices para melhor performance
              entity.HasIndex(e => e.cd_Menu, "IX_menu_modulos_cd_menu");
              entity.HasIndex(e => e.cd_Modulo, "IX_menu_modulos_cd_modulo");


              entity.Property(e => e.Id)
                  .ValueGeneratedNever()
                  .HasColumnName("id");
              entity.Property(e => e.cd_Menu).HasColumnName("cd_menu");
              entity.Property(e => e.cd_Modulo).HasColumnName("cd_modulo");
          });

        modelBuilder.Entity<MenuModuloPerfil>(entity =>
          {
              entity.HasKey(e => e.Id).HasName("PRIMARY");

              entity.ToTable("menu_modulo_perfils");

              entity.HasIndex(e => e.cdMenuModulo, "cd_menu_modulo");

              entity.HasIndex(e => e.cdPerfil, "cd_perfil");

              entity.HasOne(mm => mm.MenuModulo)
              .WithMany(u => u.MenuModuloPerfils)
              .HasForeignKey(mm => mm.cdMenuModulo);


              entity.HasOne(um => um.Perfil)
                  .WithMany(m => m.MenuModuloPerfils)
                  .HasForeignKey(um => um.cdPerfil);

              // Índices para melhor performance
              entity.HasIndex(e => e.cdPerfil, "IX_menu_modulos_cd_perfil");
              entity.HasIndex(e => e.cdMenuModulo, "IX_menu_modulos_cd_menu_modulo");


              entity.Property(e => e.Id)
                  .ValueGeneratedNever()
                  .HasColumnName("id");
              entity.Property(e => e.cdMenuModulo).HasColumnName("cd_menu_modulo");
              entity.Property(e => e.cdPerfil).HasColumnName("cd_perfil");
          });




















        OnModelCreatingPartial(modelBuilder);
    }




    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
