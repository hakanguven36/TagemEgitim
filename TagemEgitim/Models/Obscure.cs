using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.Models
{
	[Table("Obscure")]
	public class Obscure
	{
		public int ID { get; set; }

		[StringLength(200)]
		public string isim { get; set; }

		public int sayı { get; set; }

		public int kursID { get; set; }
		public Kurs kurs { get; set; }
	}
}
