using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BooksInOrder
{
    public int IdOrder { get; set; }

    public int IdBook { get; set; }

    public int QuantityInOrder { get; set; }

    public int IdSupply { get; set; }

    public virtual Book IdBookNavigation { get; set; }

    public virtual Order IdOrderNavigation { get; set; }

    public virtual Supply IdSupplyNavigation { get; set; }
}
