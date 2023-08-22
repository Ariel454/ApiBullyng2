using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Test
{
    public int IdTest { get; set; }

    public string NombreTest { get; set; } = null!;

    public int? IdUsuarioF { get; set; }

    public virtual Usuario? IdUsuarioFNavigation { get; set; }

    public virtual ICollection<Preguntum> Pregunta { get; set; } = new List<Preguntum>();
}
