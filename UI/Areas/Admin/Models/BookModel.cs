using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BookModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "IdBook")]
		public int IdBook { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "BookName")]
		public string BookName { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Author")]
		public string Author { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "YearOfWriting")]
		public int YearOfWriting { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Country")]
		public string Country { get; set; }

		public static BookModel FromEntity(Book obj)
		{
			return obj == null ? null : new BookModel
			{
				IdBook = obj.IdBook,
				BookName = obj.BookName,
				Author = obj.Author,
				YearOfWriting = obj.YearOfWriting,
				Country = obj.Country,
			};
		}

		public static Book ToEntity(BookModel obj)
		{
			return obj == null ? null : new Book(obj.IdBook, obj.BookName, obj.Author, obj.YearOfWriting, obj.Country);
		}

		public static List<BookModel> FromEntitiesList(IEnumerable<Book> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Book> ToEntitiesList(IEnumerable<BookModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
