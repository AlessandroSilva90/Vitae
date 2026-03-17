using System;
using System.Collections.Generic;
using Core_Providentia_vitae.Models.Admin;

namespace Core_Providentia_vitae.Models.Admin;

public partial class UsuarioModulo
{
    public uint Id { get; set; }

    public uint CdUsuario { get; set; }

    public uint CdModulo { get; set; }

    // RELACIONAMENTO
    public virtual Usuario Usuario { get; set; } = null!;
    
    public virtual Modulo Modulo { get; set; } = null!;
}
