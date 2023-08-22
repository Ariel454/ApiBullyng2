using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Formulario
{
    public int IdFormulario { get; set; }

    public int? IdUsuarioF { get; set; }

    public string TituloCaso { get; set; } = null!;

    public string? Detalle { get; set; }

    public string? Fecha { get; set; }

    public virtual Usuario? IdUsuarioFNavigation { get; set; }
}
