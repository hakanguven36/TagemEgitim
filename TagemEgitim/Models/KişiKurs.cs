using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.Models
{
	public class KişiKurs
	{
		public int ID { get; set; }

		public int kişiID { get; set; }
		public Kişi kişi { get; set; }

		public int kursID { get; set; }
		public Kurs kurs { get; set; }

		[DisplayName("Katılım Şekli")]
		public KATILIMŞEKLİ katılımŞekli { get; set; }
	}
}

public enum KATILIMŞEKLİ
{
	Katılımcı,
	Eğitmen,
	Tercüman,
	Diğer
}
