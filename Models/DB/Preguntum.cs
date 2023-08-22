using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Preguntum
{
    public int IdPregunta { get; set; }

    public string? TextoPregunta { get; set; }

    public int? IdTestF { get; set; }

    public virtual Test? IdTestFNavigation { get; set; }

    public virtual ICollection<Respuestum> Respuesta { get; set; } = new List<Respuestum>();
}
