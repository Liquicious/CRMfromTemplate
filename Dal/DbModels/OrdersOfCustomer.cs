using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class OrdersOfCustomer
{
    public int IdCustomer { get; set; }

    public DateTime DateOfOrder { get; set; }

    public double OrderCost { get; set; }
}
