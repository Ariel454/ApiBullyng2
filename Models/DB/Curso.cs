using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Curso
{
    public int IdCurso { get; set; }

    public int IdInstitucionF { get; set; }

    public int Nivel { get; set; }

    public string? Paralelo { get; set; }

    public virtual Institucion IdInstitucionFNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
