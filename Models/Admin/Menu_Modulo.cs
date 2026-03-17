using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class MenuModulo
{
    public uint Id { get; set; }

    public uint cd_Menu { get; set; }
    public uint cd_Modulo { get; set; }


    // RELACIONAMENTO

    public virtual Menu Menu { get; set; } = null!;
    public virtual Modulo Modulo { get; set; } = null!;

    public ICollection<MenuModuloPerfil> MenuModuloPerfils { get; set;} = new List<MenuModuloPerfil>();



}
