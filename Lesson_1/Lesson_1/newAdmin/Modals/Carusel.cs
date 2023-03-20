using System;
using System.Collections.Generic;

namespace newAdmin.Modals;

public partial class Carusel
{
    public int CarurelId { get; set; }

    public string? Tirle { get; set; }

    public string? Description { get; set; }

    public string? PictureUrl { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public string? CreateUser { get; set; }
}
