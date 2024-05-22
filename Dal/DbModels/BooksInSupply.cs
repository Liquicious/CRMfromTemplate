using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BooksInSupply
{
    public int IdSupply { get; set; }

    public int IdBook { get; set; }

    public int QuantityInSupply { get; set; }

    public int BookPrice { get; set; }

    public virtual Book IdBookNavigation { get; set; }

    public virtual Supply IdSupplyNavigation { get; set; }
}
