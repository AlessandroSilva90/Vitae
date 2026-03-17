using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Perfil
{
    public uint Id { get; set; }

    public string DsPefil { get; set; } = null!;

    public bool? SnAtivo { get; set; }

    public DateTime? DtCreate { get; set; }


    // RELACIONAMENTO COM MENU_MODULO_PERFIL
    public ICollection<MenuModuloPerfil> MenuModuloPerfils { get;} = new List<MenuModuloPerfil>();



}
