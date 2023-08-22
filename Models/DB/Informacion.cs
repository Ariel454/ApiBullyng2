using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Informacion
{
    public int IdInformacion { get; set; }

    public int IdInstitucionF { get; set; }

    public string TituloInfo { get; set; } = null!;

    public string? Texto { get; set; }

    public virtual Institucion IdInstitucionFNavigation { get; set; } = null!;
}
