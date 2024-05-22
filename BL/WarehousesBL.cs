using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Warehouse = Entities.Warehouse;

namespace BL
{
	public class WarehousesBL
	{
		public async Task<int> AddOrUpdateAsync(Warehouse entity)
		{
			entity.IdWarehouse = await new WarehousesDal().AddOrUpdateAsync(entity);
			return entity.IdWarehouse;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new WarehousesDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(WarehousesSearchParams searchParams)
		{
			return new WarehousesDal().ExistsAsync(searchParams);
		}

		public Task<Warehouse> GetAsync(int id)
		{
			return new WarehousesDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new WarehousesDal().DeleteAsync(id);
		}

		public Task<SearchResult<Warehouse>> GetAsync(WarehousesSearchParams searchParams)
		{
			return new WarehousesDal().GetAsync(searchParams);
		}
	}
}

