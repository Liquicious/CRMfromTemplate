using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BooksAtWarehouse
{
    public int IdWarehouse { get; set; }

    public int IdBook { get; set; }

    public int QuantityInStock { get; set; }

    public virtual Book IdBookNavigation { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; }
}
