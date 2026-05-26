using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Perfil
{
    public uint Id { get; set; }

    public string DsPerfil { get; set; } = null!;

    public bool? SnAtivo { get; set; }

    public DateTime? DtCreate { get; set; }

    public virtual ICollection<MenuModuloPerfil> MenuModuloPerfils { get; set; } = new List<MenuModuloPerfil>();
}
