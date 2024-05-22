using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class StoredBook
{
    public int Warehouse { get; set; }

    public int BookId { get; set; }

    public string Book { get; set; }

    public int Quantity { get; set; }
}
