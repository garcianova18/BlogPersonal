using System;
using System.Collections.Generic;

namespace Dominio.Models;

public partial class Post
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime FechaPublicado { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public int Status { get; set; }

    public int IdCategoria { get; set; }

    public int IdUser { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
