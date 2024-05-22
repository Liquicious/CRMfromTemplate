using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CustomerModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "IdCustomer")]
		public int IdCustomer { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "CustomerName")]
		public string CustomerName { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "CustomerSex")]
		public string CustomerSex { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "CustomerAge")]
		public int CustomerAge { get; set; }

		public static CustomerModel FromEntity(Customer obj)
		{
			return obj == null ? null : new CustomerModel
			{
				IdCustomer = obj.IdCustomer,
				CustomerName = obj.CustomerName,
				CustomerSex = obj.CustomerSex,
				CustomerAge = obj.CustomerAge,
			};
		}

		public static Customer ToEntity(CustomerModel obj)
		{
			return obj == null ? null : new Customer(obj.IdCustomer, obj.CustomerName, obj.CustomerSex,
				obj.CustomerAge);
		}

		public static List<CustomerModel> FromEntitiesList(IEnumerable<Customer> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Customer> ToEntitiesList(IEnumerable<CustomerModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
