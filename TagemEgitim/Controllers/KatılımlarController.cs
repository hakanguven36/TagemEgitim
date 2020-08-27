using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagemEgitim.Araclar;
using TagemEgitim.Models;

namespace TagemEgitim.Controllers
{
	[Yetki("user")]
	public class KatılımlarController : Controller
    {
		MyContext db;
		public KatılımlarController(MyContext db) => this.db = db;

        public IActionResult Index(int id)
        {
			ViewBag.TheKursID = id;
            return View();
        }
		public IActionResult KatılımGöster(int kursID)
		{
			var ret =
				db.Kurslar
				.Include(k => k.kişikurs).ThenInclude(k => k.kişi).ThenInclude(k => k.ülke)
				.Include(k => k.kişikurs).ThenInclude(k => k.kişi).ThenInclude(k => k.ünvan)
				.Include(k => k.obscures)
				.FirstOrDefault(u => u.ID == kursID);
			return PartialView(ret);
		}

		public IActionResult KisiEklenecek()
		{
			ViewBag.ünvanlar = db.Ünvanlar.ToList();
			ViewBag.ülkeler = db.Ülkeler.ToList();
			return PartialView();
		}

		public IActionResult KisiAraListele(string email, string isim, string soyisim, int ulke)
		{
			try
			{
				var sbt = db.Kişiler.Include(k=>k.ülke).Include(k=>k.ünvan).ToList();
				//email arama
				var ret = sbt.ToList();
				if(!string.IsNullOrWhiteSpace(email))
				{
					var emailsearch = sbt.Where(u => u.email == email).ToList();
					if (emailsearch.Count > 0)
					return PartialView(emailsearch.Take(10).ToList());
				}
				ret = sbt.ToList();
				// Bu noktada email bulunamadı demektir..

				//isim arama (onkeyup)
				var isimarama = new List<Kişi>();
				if (!string.IsNullOrWhiteSpace(isim))
					isimarama = sbt.Where(u => u.isim.tooString().Contains(isim, StringComparison.CurrentCultureIgnoreCase)).ToList();

				//soyisim arama (onkeyup)
				var soyisimarama = new List<Kişi>();
				if (!string.IsNullOrWhiteSpace(soyisim))
					soyisimarama = sbt.Where(u => u.soyisim.tooString().Contains(soyisim, StringComparison.CurrentCultureIgnoreCase)).ToList();

				if (isimarama.Count > 0 && soyisimarama.Count > 0)
					ret = isimarama.Union(soyisimarama, new PersonComparer()).ToList();
				else if (isimarama.Count > 0)
					ret = isimarama;
				else if (soyisimarama.Count > 0)
					ret = soyisimarama;

				// İsim veya soyisim var ise ülkeye göre son bir filtreleme yapar
				// O ülkede benzer isimde insan varsa döndürür..
				// HANDICUP: Benzer isimde esas kişi diğer ülkede ise onu göremeyiz!!
				//			 Bu yüzden ülke seçiminin en son yapılması gerekir..
				if (ulke > 0)
				{
					var retulkeli = ret.Where(u => u.ülkeID == ulke).ToList();
					if (retulkeli.Count > 0)
						return PartialView(retulkeli.Take(10).ToList());
				}

				return PartialView(ret.Take(10).ToList());
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}

		[HttpPost]
		public IActionResult KişiEkle(Kişi kisi, string addedkursID)
		{
			try
			{
				int kursID = Convert.ToInt32(addedkursID);
				var kurs = db.Kurslar.Find(kursID);

				db.Kişiler.Add(kisi);
				db.SaveChanges();
				var kisikurs = new KişiKurs();
				kisikurs.kişi = kisi;
				kisikurs.kurs = kurs;
				kisikurs.katılımŞekli = KATILIMŞEKLİ.Katılımcı;
				db.kişikurs.Add(kisikurs);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}

		public IActionResult GrupEklenecek()
		{
			return PartialView();
		}

		[HttpPost]
		public IActionResult GrupEkle(Obscure obscure, string obsKursID)
		{
			try
			{
				int kursID = Convert.ToInt32(obsKursID);
				var kurs = db.Kurslar.Find(kursID);
				obscure.kurs = kurs;
				db.Obscures.Add(obscure);
				db.SaveChanges();
				return Json("Tamam");

			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}

		}

		[HttpPost]
		public IActionResult KatılımŞekliDeğiştir(int kursID, int kisiID, int katset)
		{
			try
			{
				var kisikurs = db.kişikurs.Where(u => u.kursID == kursID & u.kişiID == kisiID).FirstOrDefault();
				if(kisikurs == null)
					return Json("Hata: kişi yada kurs bulunamadı!");
				
				kisikurs.katılımŞekli = (KATILIMŞEKLİ)katset;
				db.Entry(kisikurs).State = EntityState.Modified;
				db.SaveChanges();
				return Json("Tamam");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}

		[HttpPost]
		public IActionResult KatılımSil(int kisikursID)
		{
			try
			{
				var kisikurs = db.kişikurs.Find(kisikursID);
				db.kişikurs.Remove(kisikurs);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}

		[HttpPost]
		public IActionResult ObscureSil(int obsID)
		{
			try
			{
				var obscure = db.Obscures.Find(obsID);
				db.Obscures.Remove(obscure);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}


		[HttpPost]
		public IActionResult MevcutKişiyiKursaEkle(int kisiID, int kursID)
		{
			try
			{
				var kisi = db.Kişiler.Find(kisiID);
				var kurs = db.Kurslar.Find(kursID);
				if (db.kişikurs.FirstOrDefault(u => u.kişi == kisi & u.kurs == kurs) != null)
					return Json("Bu zaten var");
				var kisikurs = new KişiKurs();
				kisikurs.kişi = kisi;
				kisikurs.kurs = kurs;
				kisikurs.katılımŞekli = KATILIMŞEKLİ.Katılımcı;
				db.kişikurs.Add(kisikurs);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}

	}

	public class PersonComparer : IEqualityComparer<Kişi>
	{
		public bool Equals(Kişi p1, Kişi p2)
		{
			return p1.ID == p2.ID;
		}

		public int GetHashCode(Kişi p)
		{
			return p.ID;
		}
	}
}