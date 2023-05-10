using System;
using System.Collections.Generic;

namespace Dominio.Models;

public partial class Categoria
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
