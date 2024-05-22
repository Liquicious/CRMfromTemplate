using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class WarehouseStaff
{
    public int Warehouse { get; set; }

    public int Employee { get; set; }
}
