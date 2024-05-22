using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Customer = Entities.Customer;

namespace BL
{
	public class CustomersBL
	{
		public async Task<int> AddOrUpdateAsync(Customer entity)
		{
			entity.IdCustomer = await new CustomersDal().AddOrUpdateAsync(entity);
			return entity.IdCustomer;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new CustomersDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(CustomersSearchParams searchParams)
		{
			return new CustomersDal().ExistsAsync(searchParams);
		}

		public Task<Customer> GetAsync(int id)
		{
			return new CustomersDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new CustomersDal().DeleteAsync(id);
		}

		public Task<SearchResult<Customer>> GetAsync(CustomersSearchParams searchParams)
		{
			return new CustomersDal().GetAsync(searchParams);
		}
	}
}

