using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TagemEgitim.Models
{
	[Table("Kisi")]
	public class Kişi
	{
		public int ID { get; set; }

		[StringLength(100)]
		[DisplayName("İsim")]
		[Required]
		public string isim { get; set; }

		[StringLength(100)]
		[DisplayName("Soyisim")]
		[Required]
		public string soyisim { get; set; }

		[DisplayName("Tamİsim")]
		[ScaffoldColumn(true)]
		public string tamisim { get { return isim + " " + soyisim; } }

		[StringLength(100)]
		[DisplayName("E-posta")]
		[DataType(DataType.EmailAddress)]
		public string email { get; set; }

		[StringLength(100)]
		[DisplayName("E-posta2")]
		[DataType(DataType.EmailAddress)]
		public string email2 { get; set; }

		[DisplayName("Cinsiyet")]
		public CİNSİYET cinsiyet { get; set; }

		[DisplayName("Doğum Tarihi")]
		[DataType(DataType.Date)]
		public DateTime doğumTarihi { get; set; }

		[DisplayName("Ülke")]
		public virtual int ülkeID { get; set; }
		[DisplayName("Ülke")]
		public Ülke ülke { get; set; }

		[DisplayName("Ünvan")]
		public virtual int ünvanID { get; set; }
		[DisplayName("Ünvan")]
		public Ünvan ünvan { get; set; }

		[StringLength(500)]
		[DisplayName("Kurum")]
		public string kurum { get; set; }

		[StringLength(100)]
		[DisplayName("Görevi")]
		public string görev { get; set; }

		[StringLength(500)]
		[DisplayName("Adres")]
		[DataType(DataType.MultilineText)]
		public string adres { get; set; }

		[StringLength(30)]
		[DisplayName("Telefon")]
		public string telefon { get; set; }

		[StringLength(30)]
		[DisplayName("Telefon2")]
		public string telefon2 { get; set; }

		public List<KişiKurs> kişikurs { get; set; }
	}
}
public enum CİNSİYET
{
	Belirtilmemiş,
	Kadın,
	Erkek
}