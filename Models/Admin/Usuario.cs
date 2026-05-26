using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Usuario
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Cracha { get; set; }

    public bool? SnAtivo { get; set; }

    public bool? SnFuncionario { get; set; }

    public string DsUsuario { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime? DtLog { get; set; }

    public DateTime? DtUltLog { get; set; }

    public DateTime? DtCreate { get; set; }

    public DateTime? DtUpdate { get; set; }
}
