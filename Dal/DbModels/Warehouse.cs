using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Warehouse
{
    public int IdWarehouse { get; set; }

    public string AdressWarehouse { get; set; }

    public virtual ICollection<BooksAtWarehouse> BooksAtWarehouses { get; set; } = new List<BooksAtWarehouse>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
