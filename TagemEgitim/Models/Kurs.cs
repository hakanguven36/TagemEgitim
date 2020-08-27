using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.Models
{
	[Table("Kurs")]
	public class Kurs
	{
		public int ID { get; set; }

		[DisplayName("Yıl")]
		[ScaffoldColumn(true)]
		public int yıl { get { return tarihBasla.Year; } }

		[Required]
		[StringLength(500)]
		[DisplayName("Eğitim Adı")]
		public string isim { get; set; }

		[StringLength(500)]
		[DisplayName("Eğitim Adı(İngilizce)")]
		public string isimEN { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayName("Başlama Tarihi")]
		public DateTime tarihBasla { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[DisplayName("Bitiş Tarihi")]
		public DateTime tarihBitis { get; set; }

		[DisplayName("Gün")]
		[ScaffoldColumn(true)]
		public int kursSuresi { get { return Convert.ToInt32((tarihBitis - tarihBasla).TotalDays); } }

		[DisplayName("Ulus Türü")]
		public ULUSTÜRÜ ulustürü { get; set; }

		[DisplayName("Organizasyon Türü")]
		public EVTÜRÜ evtürü { get; set; }

		[DisplayName("Toplantı Türü")]
		public TOPLANTITÜRÜ toplantıtürü { get; set; }

		[StringLength(500)]
		[DataType(DataType.MultilineText)]
		public string notlar { get; set; }

		public List<KişiKurs> kişikurs { get; set; }

		public List<Obscure> obscures { get; set; }

	}
}

public enum ULUSTÜRÜ
{
	Ulusal,
	Uluslararası
}

public enum EVTÜRÜ
{
	EvSahipliği,
	Organizasyon
}

public enum TOPLANTITÜRÜ
{
	Çalıştay,
	Eğitim,
	Toplantı
}
