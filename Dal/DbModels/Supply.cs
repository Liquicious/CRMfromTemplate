using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Supply
{
    public int IdSupply { get; set; }

    public int IdSupplier { get; set; }

    public int IdWarehouse { get; set; }

    public DateTime DateOfDelivery { get; set; }

    public virtual ICollection<BooksInOrder> BooksInOrders { get; set; } = new List<BooksInOrder>();

    public virtual ICollection<BooksInSupply> BooksInSupplies { get; set; } = new List<BooksInSupply>();

    public virtual Supplier IdSupplierNavigation { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; }
}
