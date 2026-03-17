using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models;

public partial class Car
{
    public string EmpCodigo { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? CboCodigo { get; set; }

    public string? ObbCodigo { get; set; }

    public string? ObrCodigo { get; set; }

    public int? RhCar { get; set; }

    public string? Cbo2009Codigo { get; set; }

    public string? NomeFaixaRh { get; set; }

    public string? CodigoEsocial { get; set; }

    public int? IdExterno { get; set; }

    public string? SincronizadoConecta { get; set; }
}
