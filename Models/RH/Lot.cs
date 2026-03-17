using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models;

public partial class Lot
{
    public string EmpCodigo { get; set; } = null!;

    public string? Codigo { get; set; } 

    public string Nome { get; set; } = null!;

    public string? LotCodigoMae { get; set; }

    public int? RhLot { get; set; }

    public string? CrsCodigo { get; set; }

    public int? IdExterno { get; set; }

    public string? SincronizadoConecta { get; set; }


    // RELACIONAMENTO 
    public ICollection<Sep> Sep { get; } = new List<Sep>();
}
