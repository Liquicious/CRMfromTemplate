using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string CustomerName { get; set; }

    public string CustomerSex { get; set; }

    public int CustomerAge { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
