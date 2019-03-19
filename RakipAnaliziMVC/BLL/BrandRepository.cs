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
	//BASEREPOSITORY HARİÇ YAZDIĞIMIZ TÜM REPOSITORYLERİ SİLMEMİZ GEREKİYOR ÇÜNKÜ UNITYOFWORK YAZDIK. SİLMEZSEK CONSOLEDA FAİLED HATASI VERİR

	//Business Logic Layer - BLL
	//Repository pattern: ADO ile çalışırken çok iyi! 
	//Entity framwork varken repository kullanmalı mıyız? / kullanmamalı mıyız? Makale oku!
	//Birden fazla verikaynağından veri geliyorsa ya da gelmesi muhtemelse kullanmak daha mantıklı
	//Repository kullandığımızda 3 numaralı controllerı ekleyemeyiz!

	//Repository patternde her bir model için CRUD(ekle-sil-güncelle) (+ find da olabilir) işlemlerinden sorumlu bir class üretilir.
	//BrandRepo - BrandRepository - BrandManager - BrandController isimleriyle karşımıza gelebilir.
	/*public class BrandRepository : BaseRepository<Brand>
	//{
	//	CompetitorContext db = new CompetitorContext();
		
	//	//public void Update(Brand newBrand)
	//	//{
	//	//	var old = db.Brands.Find(newBrand.ID);
	//	//	//old.BrandName = newBrand.BrandName; bunun yerine:
	//	//	db.Entry(old).CurrentValues.SetValues(newBrand); //bütün değişiklik olan propertyleri yukarıdaki gibi tek tek güncellemek yerine tek seferde bu şekilde alabiliriz
	//	//	db.Entry(old).State = EntityState.Modified;
	//	//	db.SaveChanges();
	//	//}
	}*/
}
