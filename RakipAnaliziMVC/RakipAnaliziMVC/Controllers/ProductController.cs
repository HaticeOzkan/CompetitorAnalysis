using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class ProductController : Controller
    {
		// {controller}/{action}/{id}
		//
		UnitOfWork _uw = new UnitOfWork();
        public ActionResult Index(int? delete)
        {
			if (delete.HasValue)
			{
				_uw.ProductRep.Delete(delete.Value);
				return RedirectToAction("Index");
			}

            return View(_uw.ProductRep.GetAll());
        }

		public ActionResult Create() //formu göstermek için burası çalışır
		{
			ViewBag.Brands = _uw.BrandRep.GetAll();
			ViewBag.ProductGroups = _uw.ProductGroupRep.GetAll();

			return View();
		}

		[HttpPost]
		public ActionResult Create(Product newProduct, int BrandId, int[] groups) //formu kayıt etmek içn burası çalışır
		{
			//model binding: uygun parametreler gelirse modele çevirme
			//bir ürünün birden fazla kategorisi olabilir dediğimiz için int dizisi ile grupları aldık
			if (ModelState.IsValid)
			{
				_uw.ProductRep.CreateWithGroup(newProduct, BrandId, groups); //brandid'yi göndermemizin sebebi ürün modelimizde brandid isimli bi property olmaması. ama ben fk ile brandid eklediğim için yazmasaydım da olurdu ;) :D
				return RedirectToAction("Index", "Product"); //ürünün indexine git demek.
			}

			//burdan sonrası get ile aynı. if çalışmazsa get gibi çalışıp formu gösterebilsin diye!
			ViewBag.Brands = _uw.BrandRep.GetAll();
			ViewBag.ProductGroups = _uw.ProductGroupRep.GetAll();
			//bikaç grup seçip formu gönderdikten sonra hata alırsak seçtiklerimiz kaybolmasın diye get e ekstra olarak bunu ekledik:
			ViewBag.SelectedGroups = groups;
			return View(newProduct);
		}

		public ActionResult Edit(int id)
		{
			ViewBag.Brands = _uw.BrandRep.GetAll();
			ViewBag.ProductGroups = _uw.ProductGroupRep.GetAll();
			return View(_uw.ProductRep.GetOne(id));
		}

		[HttpPost]
		public ActionResult Edit(Product product, int BrandId, int[] groups)
		{
			if (ModelState.IsValid)
			{
				product.Brand = _uw.BrandRep.GetOne(BrandId);
				product.ProductGroups = _uw.ProductGroupRep.Search(x => groups.Contains(x.ID));
				_uw.ProductRep.Update(product);
				return RedirectToAction("Index");
			}
			ViewBag.Brands = _uw.BrandRep.GetAll();
			ViewBag.ProductGroups = _uw.ProductGroupRep.GetAll();
			return View(product);
		}
	}
}