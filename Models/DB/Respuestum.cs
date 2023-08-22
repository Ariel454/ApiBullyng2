using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Respuestum
{
    public int IdRespuesta { get; set; }

    public string? TextoRespuesta { get; set; }

    public int? IdPreguntaF { get; set; }

    public virtual Preguntum? IdPreguntaFNavigation { get; set; }
}
