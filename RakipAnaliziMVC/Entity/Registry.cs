using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Registry : IEntity
	{
		public int ID { get; set; }
		public int SalesCount { get; set; } //kaç satış
		public DateTime Date { get; set; }
		public virtual Product Product { get; set; } //hangi üründen
		public virtual CompetitorAnalysis CompetitorAnalysis { get; set; } //hangi ayda

		public Registry()
		{
			Date = DateTime.Now;
		}
	}
}
