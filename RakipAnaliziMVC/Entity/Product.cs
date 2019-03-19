using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Product : IEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		[MaxLength(200)]
		public string ProductName { get; set; }
		[MaxLength(100)]
		public string SN { get; set; } //serino
		[MaxLength(50)]
		public string ModelCode { get; set; }
		[ForeignKey("Brand")]
		public int BrandId { get; set; }
		public virtual Brand Brand { get; set; } //fk tanımlamadık ama ama o kendi tanımlıyor sadece veri eklerken fk yı kontrol etmiyor
		public virtual List<ProductGroup> ProductGroups { get; set; }
		public virtual List<Registry> Registries { get; set; }
	}
}
