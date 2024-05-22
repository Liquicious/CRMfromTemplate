using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class BooksDal : BaseDal<DefaultDbContext, Book, Entities.Book, int, BooksSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BooksDal()
		{
		}

		protected internal BooksDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Book entity, Book dbObject, bool exists)
		{
			dbObject.IdBook = entity.IdBook;
			dbObject.BookName = entity.BookName;
			dbObject.Author = entity.Author;
			dbObject.YearOfWriting = entity.YearOfWriting;
			dbObject.Country = entity.Country;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Book>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Book> dbObjects, BooksSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Book>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Book> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Book, int>> GetIdByDbObjectExpression()
		{
			return item => item.IdBook;
		}

		protected override Expression<Func<Entities.Book, int>> GetIdByEntityExpression()
		{
			return item => item.IdBook;
		}

		internal static Entities.Book ConvertDbObjectToEntity(Book dbObject)
		{
			return dbObject == null ? null : new Entities.Book(dbObject.IdBook, dbObject.BookName, dbObject.Author,
				dbObject.YearOfWriting, dbObject.Country);
		}
	}
}
