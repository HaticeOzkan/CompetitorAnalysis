using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Modelden ürettiğimiz nesneler -> entity: varlık (domain ya da business domain de denir)
namespace Entity
{
	//classların default access modifierı : internal
    public class Brand : IEntity
	{
		[Key]
		public int ID { get; set; }
		[Required]
		[MaxLength(100)]
		public string BrandName { get; set; }
		public virtual List<Product> Products { get; set; } //her markanın bir sürü ürünü olabilir

    }
}
