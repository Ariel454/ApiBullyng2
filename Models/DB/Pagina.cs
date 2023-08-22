using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Pagina
{
    public int IdPagina { get; set; }

    public int IdCuentoF { get; set; }

    public string Texto { get; set; } = null!;

    public virtual Cuento IdCuentoFNavigation { get; set; } = null!;
}
