using System;
using System.Collections.Generic;

namespace ApiBullyng2.Models.DB;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdCursoF { get; set; }

    public int Rol { get; set; }

    public string Nombre { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;

    public int Genero { get; set; }

    public string Correo { get; set; } = null!;

    public virtual ICollection<Formulario> Formularios { get; set; } = new List<Formulario>();

    public virtual Curso IdCursoFNavigation { get; set; } = null!;

    public virtual ICollection<Mensaje> Mensajes { get; set; } = new List<Mensaje>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
