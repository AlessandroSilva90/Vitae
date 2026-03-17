using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class Modulo
{
    public uint Id { get; set; }

    public string NmModulos { get; set; } = null!;

    public bool? SnAtivo { get; set; }

    public DateTime? DtCreate { get; set; }


    // RELACIONAMENTO COM USUARIO MODULO
    public ICollection<UsuarioModulo> UsuarioModulos { get; } = new List<UsuarioModulo>();
    public virtual ICollection<MenuModulo> MenuModulos { get;} = new List<MenuModulo>();
        


}
