using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Mensaje
{
    public int IdMensaje { get; set; }

    public int? IdUsuarioF { get; set; }

    public string Texto { get; set; } = null!;

    public string? Foto { get; set; }

    public string? Video { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }

    public virtual Usuario? IdUsuarioFNavigation { get; set; }
}
