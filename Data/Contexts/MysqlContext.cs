using Core_Providentia_vitae.Models;
using Microsoft.EntityFrameworkCore;

namespace Core_Providentia_vitae.Data;

public partial class MysqlContext : DbContext
{
    public MysqlContext(DbContextOptions<MysqlContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Suas configurações de modelo aqui (se tiver)
        modelBuilder.Entity<Usuario>(entity =>
   {
       entity.HasKey(e => e.Id);

       entity.Property(e => e.Id)
           .ValueGeneratedOnAdd()
           .HasColumnName("id") // 👈 ADICIONE ESTA LINHA
           .IsRequired(); // 👈 E ESTA

       entity.Property(e => e.Sn_Ativo)
           .HasDefaultValue(true)
           .HasColumnName("sn_ativo"); // 👈 E PARA TODAS AS PROPRIEDADES

       entity.Property(e => e.Nome)
           .HasColumnName("nome");

       entity.Property(e => e.Email)
           .HasColumnName("email");

        entity.Property(e => e.Cracha)
        .HasColumnName("cracha");

       entity.Property(e => e.Sn_Funcionario)
           .HasColumnName("sn_funcionario");

       entity.Property(e => e.Ds_Usuario)
           .HasColumnName("ds_usuario");

       entity.Property(e => e.Senha)
           .HasColumnName("senha");

       entity.Property(e => e.Dt_Create)
           .HasDefaultValueSql("CURRENT_TIMESTAMP")
           .HasColumnName("dt_create");

       entity.Property(e => e.Dt_Update)
           .HasColumnName("dt_update");

       entity.Property(e => e.Dt_Log)
           .HasColumnName("dt_log");

       entity.Property(e => e.Dt_Ult_Log)
           .HasColumnName("dt_ult_log");

       // Configure a tabela também
       entity.ToTable("usuarios"); // 👈 Nome exato da tabela no banco
   });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}