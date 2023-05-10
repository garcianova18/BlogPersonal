using System;
using System.Collections.Generic;

namespace BlogPersonal.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public virtual ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
