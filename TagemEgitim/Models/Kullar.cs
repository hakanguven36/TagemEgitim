using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TagemEgitim.Araclar;

namespace TagemEgitim.Models
{
	[Table("Kullar")]
	public class Kullar
	{
		public int ID { get; set; }

		[Required]
		[StringLength(120, MinimumLength = 4, ErrorMessage = "4-120 Karakter olmalı!")]
		public string kulname { get; set; }

		[StringLength(12, MinimumLength = 4, ErrorMessage = "4-12 Karakter olmalı!")]
		[ScaffoldColumn(true)]
		public string kulpass { get { return kulpassEnc.encout(); } set { kulpassEnc = value.encin(); } }

		[StringLength(600)]
		public string kulpassEnc { get; set; }

		public bool hatirla { get; set; }

		[StringLength(60)]
		[ScaffoldColumn(true)]
		public string cerez { get { return cerezEnc.encout(); } set { cerezEnc = value.encin(); } }

		[StringLength(600)]
		public string cerezEnc { get; set; }

		public int hatali { get; set; }

		public DateTime kilitliTarih { get; set; }

		[ScaffoldColumn(true)]
		public bool admin { get { return kulname.encin() == adminCode; } set { if (value) adminCode = kulname.encin(); else adminCode = ""; } }

		[StringLength(600)]
		public string adminCode { get; set; }
	}
}