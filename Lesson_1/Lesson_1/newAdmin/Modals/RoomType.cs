using System;
using System.Collections.Generic;

namespace newAdmin.Modals;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string? Name { get; set; }

    public string? RoomTypeDescription { get; set; }

    public int? Price { get; set; }

    public string? Imagepath { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
