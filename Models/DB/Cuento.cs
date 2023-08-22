using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Cuento
{
    public int IdCuento { get; set; }

    public string TituloCuento { get; set; } = null!;

    public int IdInstitucionF { get; set; }

    public virtual Institucion IdInstitucionFNavigation { get; set; } = null!;

    public virtual ICollection<Pagina> Paginas { get; set; } = new List<Pagina>();
}
