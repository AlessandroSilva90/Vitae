using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core_Providentia_vitae.Models.Admin;

namespace Core_Providentia_vitae.Models;

public partial class Usuario
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // DEVE TER ISSO
    [Column("id")] // ADICIONE ESTA LINHA!
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;
    public int Cracha { get; set; }

    public bool? Sn_Ativo { get; set; } = true;

    public bool? Sn_Funcionario { get; set; }

    public string Ds_Usuario { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime? Dt_Log { get; set; }

    public DateTime? Dt_Ult_Log { get; set; }

    public DateTime? Dt_Create { get; set; }

    public DateTime? Dt_Update { get; set; }

    // RELACIONAMENTO COM MODULOS
    public ICollection<UsuarioModulo> UsuarioModulos { get; } = new List<UsuarioModulo>();
}
