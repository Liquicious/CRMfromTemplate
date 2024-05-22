using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Book
{
    public int IdBook { get; set; }

    public string BookName { get; set; }

    public string Author { get; set; }

    public int YearOfWriting { get; set; }

    public string Country { get; set; }

    public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    public virtual ICollection<BooksAtWarehouse> BooksAtWarehouses { get; set; } = new List<BooksAtWarehouse>();

    public virtual ICollection<BooksInOrder> BooksInOrders { get; set; } = new List<BooksInOrder>();

    public virtual ICollection<BooksInSupply> BooksInSupplies { get; set; } = new List<BooksInSupply>();
}
