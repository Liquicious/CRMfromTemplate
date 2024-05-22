using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Customer
	{
		public int IdCustomer { get; set; }
		public string CustomerName { get; set; }
		public string CustomerSex { get; set; }
		public int CustomerAge { get; set; }

		public Customer(int idCustomer, string customerName, string customerSex, int customerAge)
		{
			IdCustomer = idCustomer;
			CustomerName = customerName;
			CustomerSex = customerSex;
			CustomerAge = customerAge;
		}
	}
}
