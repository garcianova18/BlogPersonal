using System;
using System.Collections.Generic;

namespace Dominio.Models;

public partial class Comentario
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaPublicado { get; set; }

    public int IdPost { get; set; }

    public int Status { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual Post IdPostNavigation { get; set; } = null!;
}
