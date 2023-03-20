using System;
using System.Collections.Generic;

namespace newAdmin.Modals;

public partial class Room
{
    public int RoomId { get; set; }

    public int RoomTypeId { get; set; }

    public decimal? Square { get; set; }

    public int? MaxPersons { get; set; }

    public bool IsFreeWifi { get; set; }

    public bool IsPrivateBalcony { get; set; }

    public bool IsFullAc { get; set; }

    public int Floor { get; set; }

    public bool HasTv { get; set; }

    public bool IsBeachView { get; set; }

    public virtual RoomType RoomType { get; set; } = null!;
}
