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
	public class BaseRepository<T> where T : class, IEntity //T'nin referans tipli olduğu söyledik. yoksa int de alabileceği için db.Set'de hata verir. T şu an yalnızca bir class olabilir, kısıtladık.
	{
		CompetitorContext db;

		public BaseRepository(CompetitorContext cameDb)
		{
			db = cameDb;
		}

		public List<T> GetAll()
		{
			return db.Set<T>().ToList();
		}

		public List<T> Search(Func<T,bool> conditions) //şartlar
		{
			//predicate ve func araştır! delege ile alakalı
			//Func<T,bool> conditions yerine Predicate<T> conditions de yazılabilirdi ama program yazdırmadı. aynı anlamdalar
			return db.Set<T>().Where(conditions).ToList();
		}

		public T GetOne(int id)
		{
			return db.Set<T>().Find(id); //db.Set<>() demek db.Brands demek gibi, aynı şeyleri yapabiliriz
		}

		public void Create(T newThing)
		{
			db.Set<T>().Add(newThing);
			db.SaveChanges();
		}

		public virtual void Delete(int id)
		{
			var beDeleted = db.Set<T>().Find(id);
			db.Set<T>().Remove(beDeleted);
			db.SaveChanges();
		}

		public virtual void Update(T newThing)
		{
			var old = db.Set<T>().Find(newThing.ID);
			db.Entry(old).CurrentValues.SetValues(newThing); //bu navigation propertyleri güncellemez! bunu bizim yapmamız gerekir
			db.Entry(old).State = EntityState.Modified;
			db.SaveChanges();
		}
		
	}
	
}
