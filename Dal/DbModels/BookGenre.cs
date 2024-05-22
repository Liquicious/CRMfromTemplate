using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BookGenre
{
    public int IdBook { get; set; }

    public string Genre { get; set; }

    public virtual Book IdBookNavigation { get; set; }
}
