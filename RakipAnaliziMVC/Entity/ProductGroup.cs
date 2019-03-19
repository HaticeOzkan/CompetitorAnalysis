using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class ProductGroup : IEntity
	{
		[Key]
		public int ID { get; set; }
		public string GroupName { get; set; }
		[ForeignKey("TopProductGroup")]
		public int? TopGroupId { get; set; }
		public virtual ProductGroup TopProductGroup { get; set; } //alt grup olsun diye üst grup ekledik. çünkü kaç tane alt grubu olacağını bilmiyoruz
		public virtual List<ProductGroup> BottomGroups { get; set; }
		public virtual List<Product> Products { get; set; } //bir ürün grubunun bir sürü ürünü olabilir
	}
}
