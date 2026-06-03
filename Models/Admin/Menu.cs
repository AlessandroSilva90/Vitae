using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Menu
{
    public uint Id { get; set; }

    public string nmMenu { get; set; } = null!;

    public uint CdMenuPai{get;set;}
    public uint Ordem {get;set;}

    public bool? SnAtivo { get; set; }

    public DateTime? DtCreate { get; set; }

    public virtual ICollection<MenuModulo> MenuModulos { get; set; } = new List<MenuModulo>();
}
