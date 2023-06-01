using System;
using System.Collections.Generic;

namespace Dominio.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
