using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string SupplierName { get; set; }

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
