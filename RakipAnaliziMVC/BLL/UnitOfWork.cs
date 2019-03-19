using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
	public class UnitOfWork
	{
		//Unit of Work: bütün repolarımız aynı db ile çalışsın diye yazcaz. hata yapma ihtimalini azaltır
		CompetitorContext db = new CompetitorContext();

		public BaseRepository<Brand> BrandRep;
		public BaseRepository<ProductGroup> ProductGroupRep;
		public ProductRepository ProductRep;
		public BaseRepository<Registry> RegistryRep;
		public BaseRepository<CompetitorAnalysis> CompetitorAnalysisRep;

		public UnitOfWork()
		{
			BrandRep = new BaseRepository<Brand>(db);
			ProductGroupRep = new BaseRepository<ProductGroup>(db);
			ProductRep = new ProductRepository(db);
			RegistryRep = new BaseRepository<Registry>(db);
			CompetitorAnalysisRep = new BaseRepository<CompetitorAnalysis>(db);
		}
	}
}
