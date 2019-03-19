using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	//new project eklerken class library(.net framework) seçiyoruz
	//Data Access Layer - DAL
	public class CompetitorContext : DbContext
	{
		public CompetitorContext() : base("CompetitorConnection")
		{

		}

		public virtual DbSet<Brand> Brands { get; set; }
		public virtual DbSet<ProductGroup> ProductGroups { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<CompetitorAnalysis> CompetitorAnalyses { get; set; }
		public virtual DbSet<Registry> Registries { get; set; }
    }
}
