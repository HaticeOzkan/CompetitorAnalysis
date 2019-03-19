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
	public class CompetitorAnalysisRepository : BaseRepository<CompetitorAnalysis>
	{
		CompetitorContext _db;
		//buraya gelen db'yi base ile ctor'a aktarcaz:
		public CompetitorAnalysisRepository(CompetitorContext db) : base(db)
		{
			_db = db;
		}

		public override void Update(CompetitorAnalysis newThing)
		{
			var n = newThing; //var n = newThing as CompetitorAnalysis;
			var old = _db.CompetitorAnalyses.Find(newThing.ID);
			old.Registries = n.Registries;
			_db.Entry(old).State = EntityState.Modified;
			_db.SaveChanges();
		}
	}
}
