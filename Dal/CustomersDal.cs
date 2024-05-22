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
	public class CustomersDal : BaseDal<DefaultDbContext, Customer, Entities.Customer, int, CustomersSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public CustomersDal()
		{
		}

		protected internal CustomersDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Customer entity, Customer dbObject, bool exists)
		{
			dbObject.IdCustomer = entity.IdCustomer;
			dbObject.CustomerName = entity.CustomerName;
			dbObject.CustomerSex = entity.CustomerSex;
			dbObject.CustomerAge = entity.CustomerAge;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Customer>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Customer> dbObjects, CustomersSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Customer>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Customer> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Customer, int>> GetIdByDbObjectExpression()
		{
			return item => item.IdCustomer;
		}

		protected override Expression<Func<Entities.Customer, int>> GetIdByEntityExpression()
		{
			return item => item.IdCustomer;
		}

		internal static Entities.Customer ConvertDbObjectToEntity(Customer dbObject)
		{
			return dbObject == null ? null : new Entities.Customer(dbObject.IdCustomer, dbObject.CustomerName,
				dbObject.CustomerSex, dbObject.CustomerAge);
		}
	}
}
