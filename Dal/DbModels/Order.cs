using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Order
{
    public int IdOrder { get; set; }

    public DateTime DateOfOrder { get; set; }

    public double OrderCost { get; set; }

    public int IdCustomer { get; set; }

    public int IdWarehouse { get; set; }

    public TimeSpan OrderAssemblyTime { get; set; }

    public virtual ICollection<BooksInOrder> BooksInOrders { get; set; } = new List<BooksInOrder>();

    public virtual Customer IdCustomerNavigation { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; }
}
