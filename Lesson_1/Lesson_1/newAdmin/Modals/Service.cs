using System;
using System.Collections.Generic;

namespace newAdmin.Modals;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string ServiceDescription { get; set; } = null!;

    public string ServiceIconPath { get; set; } = null!;

    public string ServiceImagePath { get; set; } = null!;
}
