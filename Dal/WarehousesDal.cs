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
	public class WarehousesDal : BaseDal<DefaultDbContext, Warehouse, Entities.Warehouse, int, WarehousesSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public WarehousesDal()
		{
		}

		protected internal WarehousesDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Warehouse entity, Warehouse dbObject, bool exists)
		{
			dbObject.IdWarehouse = entity.IdWarehouse;
			dbObject.AdressWarehouse = entity.AdressWarehouse;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Warehouse>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Warehouse> dbObjects, WarehousesSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Warehouse>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Warehouse> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Warehouse, int>> GetIdByDbObjectExpression()
		{
			return item => item.IdWarehouse;
		}

		protected override Expression<Func<Entities.Warehouse, int>> GetIdByEntityExpression()
		{
			return item => item.IdWarehouse;
		}

		internal static Entities.Warehouse ConvertDbObjectToEntity(Warehouse dbObject)
		{
			return dbObject == null ? null : new Entities.Warehouse(dbObject.IdWarehouse, dbObject.AdressWarehouse);
		}
	}
}
