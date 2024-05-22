using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class CustomerBook
{
    public int Customer { get; set; }

    public int Order { get; set; }

    public string Book { get; set; }

    public int Quantity { get; set; }

    public int Price { get; set; }

    public int? Total { get; set; }
}
