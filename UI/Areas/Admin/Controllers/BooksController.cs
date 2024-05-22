﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Enums;
using Common.Search;
using BL;
using UI.Areas.Admin.Models;
using UI.Areas.Admin.Models.ViewModels;
using UI.Other;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = nameof(UserRole.Admin))]
	public class BooksController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResult = await new BooksBL().GetAsync(new BooksSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModel = new SearchResultViewModel<BookModel>(BookModel.FromEntitiesList(searchResult.Objects), 
				searchResult.Total, searchResult.RequestedStartIndex, searchResult.RequestedObjectsCount, 5);
			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			var model = new BookModel();
			if (id != null)
			{
				model = BookModel.FromEntity(await new BooksBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(BookModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new BooksBL().AddOrUpdateAsync(BookModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await new BooksBL().DeleteAsync(id);
			if (result)
				TempData[OperationResultType.Success.ToString()] = "Объект удален";
			else
				TempData[OperationResultType.Error.ToString()] = "Объект не найден";
			return RedirectToAction("Index");
		}
	}
}
