using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.Admin;

public partial class MenuModuloPerfil
{
    public uint Id { get; set; }

    public uint cdMenuModulo { get; set; }
    public uint cdPerfil { get; set; }


    // RELACIONAMENTO

    public virtual Perfil Perfil { get; set; } = null!;
    public virtual MenuModulo MenuModulo { get; set; } = null!;



}
