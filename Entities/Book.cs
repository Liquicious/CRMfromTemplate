using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Book
	{
		public int IdBook { get; set; }
		public string BookName { get; set; }
		public string Author { get; set; }
		public int YearOfWriting { get; set; }
		public string Country { get; set; }

		public Book(int idBook, string bookName, string author, int yearOfWriting, string country)
		{
			IdBook = idBook;
			BookName = bookName;
			Author = author;
			YearOfWriting = yearOfWriting;
			Country = country;
		}
	}
}
