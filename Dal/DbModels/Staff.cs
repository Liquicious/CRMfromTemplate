using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Staff
{
    public int IdEmployee { get; set; }

    public string EmployeeName { get; set; }

    public string EmployeeSex { get; set; }

    public string JobTitle { get; set; }

    public int Experience { get; set; }

    public int IdWarehouse { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; }
}
