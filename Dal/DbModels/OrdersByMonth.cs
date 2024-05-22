using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class OrdersByMonth
{
    public int? Year { get; set; }

    public int? Month { get; set; }

    public double? Profit { get; set; }

    public int? Orders { get; set; }
}
