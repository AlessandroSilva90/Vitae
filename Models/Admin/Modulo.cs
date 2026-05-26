using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Modulo
{
    public uint Id { get; set; }

    public string NmModulos { get; set; } = null!;

    public bool? SnAtivo { get; set; }

    public DateTime? DtCreate { get; set; }

    public virtual ICollection<MenuModulo> MenuModulos { get; set; } = new List<MenuModulo>();

    public virtual ICollection<UsuarioModulo> UsuarioModulos { get; set; } = new List<UsuarioModulo>();
}
