using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class ProductGroupController : Controller
    {
		// GET: ProductGroup
		UnitOfWork _uw = new UnitOfWork();
		public ActionResult Index(int? delete)
        {
			if (delete.HasValue)
			{
				_uw.ProductGroupRep.Delete(delete.Value);
				RedirectToAction("Index");
			}
			return View(_uw.ProductGroupRep.GetAll());
        }

		public ActionResult Create()
		{
			ViewBag.Groups = _uw.ProductGroupRep.GetAll();
			return View();
		}

		[HttpPost]
		public ActionResult Create(ProductGroup pg)
		{
			if (ModelState.IsValid)
			{
				_uw.ProductGroupRep.Create(pg);
				return RedirectToAction("Index");
			}
			//Hem Get hem POST için ViewBag.Groups gönderilmeli. Çünkü eğer problem varsa POST içinde de View gösteriyoruz
			return View(pg);
		}

		public ActionResult Edit(int id)
		{
			ViewBag.Groups = _uw.ProductGroupRep.GetAll();
			return View(_uw.ProductGroupRep.GetOne(id));
		}

		[HttpPost]
		public ActionResult Edit(ProductGroup productGroup)
		{
			if (ModelState.IsValid)
			{
				_uw.ProductGroupRep.Update(productGroup);
				return RedirectToAction("Index");
			}
			ViewBag.Groups = _uw.ProductGroupRep.GetAll();
			return View(productGroup);
		}
	}
}