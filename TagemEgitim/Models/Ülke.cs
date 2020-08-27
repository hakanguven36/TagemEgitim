using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.Models
{
	[Table("Ulke")]
	public class Ülke
	{
		public int ID { get; set; }

		[StringLength(50)]
		public string isim { get; set; }
	}
}
