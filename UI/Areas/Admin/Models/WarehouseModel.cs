using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class WarehouseModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "IdWarehouse")]
		public int IdWarehouse { get; set; }

		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "AdressWarehouse")]
		public string AdressWarehouse { get; set; }

		public static WarehouseModel FromEntity(Warehouse obj)
		{
			return obj == null ? null : new WarehouseModel
			{
				IdWarehouse = obj.IdWarehouse,
				AdressWarehouse = obj.AdressWarehouse,
			};
		}

		public static Warehouse ToEntity(WarehouseModel obj)
		{
			return obj == null ? null : new Warehouse(obj.IdWarehouse, obj.AdressWarehouse);
		}

		public static List<WarehouseModel> FromEntitiesList(IEnumerable<Warehouse> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Warehouse> ToEntitiesList(IEnumerable<WarehouseModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}
