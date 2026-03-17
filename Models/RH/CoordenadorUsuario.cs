using System;
using System.Collections.Generic;

namespace Core_Providentia_vitae.Models.RH;

public partial class CoordenadorUsuario
{
    public int Id { get; set; }

    public int CdCoordenador { get; set; }

    public int CdFuncionario { get; set; }

    public DateOnly? DtInicio { get; set; }

    public DateOnly? DtFim { get; set; }

    public DateTime DtCreate { get; set; }
}
