using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
	public class CompetitorAnalysisController : Controller
	{
		// GET: CompetitorAnalysis
		UnitOfWork _uw = new UnitOfWork();
		public ActionResult Index()
		{
			return View(_uw.CompetitorAnalysisRep.GetAll());
		}

		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Products = _uw.ProductRep.GetAll();
			return View();
		}

		[HttpPost]
		public ActionResult Create(Registry newR, int ProductId)
		{
			if (ModelState.IsValid)
			{
				int currentMonth = DateTime.Today.Month;
				int currentYear = DateTime.Today.Year;
				CompetitorAnalysis c = _uw.CompetitorAnalysisRep.Search(x => x.Month == currentMonth && x.Year == currentYear).FirstOrDefault();
				if (c == null)
					CreateNewCompetitorAnalysis(newR, ProductId);
				else
					UpdateToExistAnalysis(newR, c, ProductId);

			}

			ViewBag.Products = _uw.ProductRep.GetAll();
			return View();
		}

		private void UpdateToExistAnalysis(Registry newR, CompetitorAnalysis c, int ProductId)
		{
			if (c.Registries == null)
				c.Registries = new List<Registry>();

			c.Registries.Add(newR);
			newR.Product = _uw.ProductRep.GetOne(ProductId);

			_uw.CompetitorAnalysisRep.Update(c);
		}

		private void CreateNewCompetitorAnalysis(Registry newR, int ProductId)
		{
			var c = new CompetitorAnalysis()
			{
				Month = DateTime.Today.Month,
				Year = DateTime.Today.Year,
				Registries = new List<Registry>()
			};

			newR.Product = _uw.ProductRep.GetOne(ProductId);

			c.Registries.Add(newR);
			_uw.CompetitorAnalysisRep.Create(c); ;
		}
	}
}
