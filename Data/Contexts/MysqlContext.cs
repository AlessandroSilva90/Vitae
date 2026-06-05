using Core_Providentia_vitae.Models;
using Core_Providentia_vitae.Models.Admin; // Adicione este using
using Core_Providentia_vitae.Models.RH;
using Microsoft.EntityFrameworkCore;

namespace Core_Providentia_vitae.Data;

public partial class MysqlContext : DbContext
{
    public MysqlContext(DbContextOptions<MysqlContext> options)
        : base(options)
    {
    }

    // DbSets existentes
    public virtual DbSet<Usuarios> Usuarios { get; set; }
    public virtual DbSet<CoordenadorSetor> CoordenadorSetor { get; set; }
    public virtual DbSet<CoordenadorUsuario> CoordenadorUsuario { get; set; }

    // DbSets do Admin (movidos do AdminContext)
    public virtual DbSet<UsuarioModulo> UsuarioModulos { get; set; }
    public virtual DbSet<Modulo> Modulos { get; set; }
    public virtual DbSet<Perfil> Perfils { get; set; }
    public virtual DbSet<Menu> Menus { get; set; }
    public virtual DbSet<MenuModulo> MenuModulos { get; set; }
    public virtual DbSet<MenuModuloPerfil> MenuModuloPerfils { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure TODAS as entidades aqui, incluindo as do Admin
        ConfigurarUsuarios(modelBuilder);
        ConfigurarCoordenadorSetor(modelBuilder);
        ConfigurarCoordenadorUsuario(modelBuilder);
        ConfigurarEntidadesAdmin(modelBuilder);
        
        OnModelCreatingPartial(modelBuilder);
    }

    private void ConfigurarUsuarios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            entity.Property(e => e.Sn_Ativo)
                .HasDefaultValue(true)
                .HasColumnName("sn_ativo");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Cracha).HasColumnName("cracha");
            entity.Property(e => e.Sn_Funcionario).HasColumnName("sn_funcionario");
            entity.Property(e => e.Ds_Usuario).HasColumnName("ds_usuario");
            entity.Property(e => e.Senha).HasColumnName("senha");
            entity.Property(e => e.Dt_Create)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("dt_create");
            entity.Property(e => e.Dt_Update).HasColumnName("dt_update");
            entity.Property(e => e.Dt_Log).HasColumnName("dt_log");
            entity.Property(e => e.Dt_Ult_Log).HasColumnName("dt_ult_log");
            entity.ToTable("usuarios");
        });
    }

    private void ConfigurarCoordenadorSetor(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoordenadorSetor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            entity.Property(e => e.CdSetor).HasColumnName("cd_setor");
            entity.Property(e => e.CdCoordenador).HasColumnName("cd_coordenador");
            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("dt_create");
            entity.Property(e => e.DtInicio).HasColumnName("dt_inicio");
            entity.Property(e => e.DtFim).HasColumnName("dt_fim");
            entity.ToTable("coordenador_setor");
        });
    }

    private void ConfigurarCoordenadorUsuario(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoordenadorUsuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id")
                .IsRequired();
            entity.Property(e => e.CdFuncionario).HasColumnName("cd_funcionario");
            entity.Property(e => e.CdCoordenador).HasColumnName("cd_coordenador");
            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("dt_create");
            entity.ToTable("coordenador_usuario");
        });
    }

    private void ConfigurarEntidadesAdmin(ModelBuilder modelBuilder)
    {
        // Collation e charset
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        // Configuração do UsuarioModulo
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
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.CdModulo).HasColumnName("cd_modulo");
            entity.Property(e => e.CdUsuario).HasColumnName("cd_usuario");
        });

        // Configuração do Modulo
        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            entity.ToTable("modulos");
            entity.Property(e => e.NmModulos).HasColumnName("nmModulos");
            entity.Property(e => e.SnAtivo)
                .HasDefaultValue(true)
                .HasColumnName("snAtivo");
            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("DtCreate");
        });

        // Configuração do Perfil
        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("perfil");
            entity.Property(e => e.DsPerfil)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("ds_perfil");
            entity.Property(e => e.SnAtivo)
                .HasDefaultValue(true)
                .HasColumnName("sn_ativo");
            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("dt_create");
        });

        // Configuração do Menu
        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("menu");
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            entity.Property(e => e.nmMenu)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("nmMenu");
            entity.Property(e => e.CdMenuPai)
                .IsRequired()
                .HasColumnName("cdMenuPai");
            entity.Property(e => e.Ordem).HasColumnName("ordem");
            entity.Property(e => e.SnAtivo)
                .HasDefaultValue(true)
                .HasColumnName("sn_ativo");
            entity.Property(e => e.DtCreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(6)")
                .HasColumnName("dt_create");
        });

        // Configuração do MenuModulo
        modelBuilder.Entity<MenuModulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("menu_modulos");
            entity.HasIndex(e => e.cd_Menu, "cd_menu");
            entity.HasIndex(e => e.cd_Modulo, "cd_modulo");
            entity.HasIndex(e => e.cd_Menu, "IX_menu_modulos_cd_menu");
            entity.HasIndex(e => e.cd_Modulo, "IX_menu_modulos_cd_modulo");

            entity.HasOne(mm => mm.Menu)
                .WithMany(u => u.MenuModulos)
                .HasForeignKey(mm => mm.cd_Menu);

            entity.HasOne(um => um.Modulo)
                .WithMany(m => m.MenuModulos)
                .HasForeignKey(um => um.cd_Modulo);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.cd_Menu).HasColumnName("cd_menu");
            entity.Property(e => e.cd_Modulo).HasColumnName("cd_modulo");
        });

        // Configuração do MenuModuloPerfil
        modelBuilder.Entity<MenuModuloPerfil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
            entity.ToTable("menu_modulo_perfils");
            entity.HasIndex(e => e.cdMenuModulo, "cd_menu_modulo");
            entity.HasIndex(e => e.cdPerfil, "cd_perfil");
            entity.HasIndex(e => e.cdPerfil, "IX_menu_modulos_cd_perfil");
            entity.HasIndex(e => e.cdMenuModulo, "IX_menu_modulos_cd_menu_modulo");

            entity.HasOne(mm => mm.MenuModulo)
                .WithMany(u => u.MenuModuloPerfils)
                .HasForeignKey(mm => mm.cdMenuModulo);

            entity.HasOne(um => um.Perfil)
                .WithMany(m => m.MenuModuloPerfils)
                .HasForeignKey(um => um.cdPerfil);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.cdMenuModulo).HasColumnName("cd_menu_modulo");
            entity.Property(e => e.cdPerfil).HasColumnName("cd_perfil");
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}