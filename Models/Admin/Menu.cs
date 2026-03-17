using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Menu
{
    public uint Id { get; set; }

    public string nmMenu { get; set; } = null!;

    public bool? SnAtivo { get; set; }

    public DateTime? DtCreate { get; set; }


    // RELACIONAMENTO COM MODULO
    public ICollection<MenuModulo> MenuModulos { get; } = new List<MenuModulo>();



}
