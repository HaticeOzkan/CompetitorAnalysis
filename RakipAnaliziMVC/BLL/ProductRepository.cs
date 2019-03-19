using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class ProductRepository : BaseRepository<Product>
	{
		CompetitorContext _db;
		public ProductRepository(CompetitorContext db) : base(db)
		{
			_db = db;
		}

		public void CreateWithGroup(Product product, int BrandId, int[] selectedGroups)
		{
			//doğrusu:
			//db dden markayı seçtiğimiz için, mevcut bir kayıt olduğunu biliyor
			product.Brand = _db.Brands.Find(BrandId);

			//yanlışı:
			/* product.Brand = new Brand() { ID = BrandId, BrandName = "name" }; 
			 * aynı bilgiler olsa bile bunu yeni marka zanneder*/

			//eklemeye çalıştığımız instansla veri çektiğimiz instanse aynı olmazsa EF sorun çıkarır. bu yüzden tek bir db ile çalışmamız gerekir. bu yüzden unityofwork yazdık
			product.ProductGroups = _db.ProductGroups.Where(x => selectedGroups.Contains(x.ID)).ToList();
			//veya
			var query = from x in _db.ProductGroups
						where selectedGroups.Contains(x.ID)
						select x;
			product.ProductGroups = query.ToList();

			_db.Products.Add(product);
			_db.SaveChanges();
		}

		public override void Delete(int id)
		{
			//çoka çok ilişkiden dolayı ürünü silmeden önce ürüngrupla olan ilişkiyi kaldırmamız gerekiyor yani ürün gruplarıyla ilgili kayıtları silmeliyiz, yoksa hata veriyor o yüzden Delete metodunu override ettik ve base'e ek olarak bunları yazdık:
			var product = GetOne(id);
			product.ProductGroups = new List<ProductGroup>(); //grupları sıfırladık
			Update(product);

			base.Delete(id); //ürünü sil
		}

		public override void Update(Product newThing)
		{
			var old = GetOne(newThing.ID);

			old.ProductGroups.Clear();

			old.Brand = newThing.Brand;
			old.ProductGroups = newThing.ProductGroups;
			old.ProductName = newThing.ProductName;
			old.SN = newThing.SN;
			old.ModelCode = newThing.ModelCode;
			_db.Entry(old).State = EntityState.Modified;
			_db.SaveChanges();
		}
	}
}
