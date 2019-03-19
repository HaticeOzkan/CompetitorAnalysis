using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class CompetitorAnalysis : IEntity //rakipanalizi
	{
		public int ID { get; set; }
		public int Month { get; set; }
		public int Year { get; set; }
		public virtual List<Registry> Registries { get; set; } //kayıt
	}
	
}
