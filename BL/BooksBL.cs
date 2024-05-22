using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Book = Entities.Book;

namespace BL
{
	public class BooksBL
	{
		public async Task<int> AddOrUpdateAsync(Book entity)
		{
			entity.IdBook = await new BooksDal().AddOrUpdateAsync(entity);
			return entity.IdBook;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BooksDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BooksSearchParams searchParams)
		{
			return new BooksDal().ExistsAsync(searchParams);
		}

		public Task<Book> GetAsync(int id)
		{
			return new BooksDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BooksDal().DeleteAsync(id);
		}

		public Task<SearchResult<Book>> GetAsync(BooksSearchParams searchParams)
		{
			return new BooksDal().GetAsync(searchParams);
		}
	}
}

