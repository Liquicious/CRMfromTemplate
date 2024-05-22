using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Warehouse
	{
		public int IdWarehouse { get; set; }
		public string AdressWarehouse { get; set; }

		public Warehouse(int idWarehouse, string adressWarehouse)
		{
			IdWarehouse = idWarehouse;
			AdressWarehouse = adressWarehouse;
		}
	}
}
