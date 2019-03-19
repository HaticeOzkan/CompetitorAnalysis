using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RakipAnaliziMVC.Controllers
{
    public class BrandController : Controller
    {
		//Uygulamamız katmanlı olduğu için migration yaparken consoleda defaultproject combobox'tan contextimizin olduğu projeyi seçmemiz gerekiyor.
		UnitOfWork _uw = new UnitOfWork();

        // GET: Brand
        public ActionResult Index(int? delete)
        {
			// Brand referans eklemek için yazıp yorum satırı yaptık

			//Markaları <table> içerisinde listeleyelim:
			//Marka Adı		İşlemler
			//..			Sil	| Düzenle
			if (delete.HasValue)
			{
				_uw.BrandRep.Delete(delete.Value); //nullable olduğu için delete.value dedik. çünkü değeri var mı yok mu bilmiyoruz
				RedirectToAction("Index");
			}
            return View(_uw.BrandRep.GetAll());
        }

		[HttpGet]
		public ActionResult New()
		{
			return View();
		}

		[HttpPost]
		public ActionResult New(Brand b)
		{
			//parametre olarak Brand b almayıp inputun ismini alabilirdik. inputun name'ini 'isim' şeyolarak ya da herhangi bi şey verebilirdik. Böyle yapsaydık metodun içinde Brand b = new Brand(); diye nesne oluşturmamız gerekirdi. Ama burada brand b nesnesini alıyorsak b'nin içinde BrandName olduğu için inputun name'ini BrandName vermek zorundayız. Ayrıca new Brand diye nesne oluşturmamıza gerek kalmıyor.
			if (ModelState.IsValid)
			{
				_uw.BrandRep.Create(b);
				return RedirectToAction("Index");
			}
			return View(b); //eğer yazdığı şey modele uymuyorsa yazdığı şeyi tekrar görüp düzeltsin diye genelde geri gönderilir
		}

		//Brand/Edit/5
		//RouteConfig'de -> {controller}/{action}/{id} -> parametre buradaki id ismiyle aynı olmak zorunda. ama eğer a href'te Brand/Edit/?sayi= yazsaydık o zaman id değil sayi karşılardı. İkisi arasında bir fark yok.
		public ActionResult Edit(int id)
		{
			return View(_uw.BrandRep.GetOne(id));
		}

		[HttpPost]
		public ActionResult Edit(Brand b)
		{
			if (ModelState.IsValid)
			{
				_uw.BrandRep.Update(b);
				return RedirectToAction("Index");
			}
			return View(b);
		}

	}
}