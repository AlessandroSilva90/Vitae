using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.RH;

public partial class CoordenadorSetor
{
    public int Id { get; set; }

    public String? CdCoordenador { get; set; }

    public string? CdSetor { get; set; }

    public DateOnly? DtInicio { get; set; }

    public DateOnly? DtFim { get; set; }

    public DateTime DtCreate { get; set; }

// RELACIONAMENTO COM USUARIOS
    // public ICollection<Usuario> Usuario { get; } = new List<Usuario>();
}

