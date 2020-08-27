using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagemEgitim.Araclar;
using TagemEgitim.Models;

namespace TagemEgitim.Controllers
{
	[Yetki("user")]
	public class DeğişkenlerController : Controller
    {
		MyContext db;
		public DeğişkenlerController(MyContext db) => this.db = db;

		public IActionResult Index()
		{
			return View();
		}

		#region Ulke Ayarları
		public IActionResult ListeleUlke()
		{
			return PartialView(db.Ülkeler.ToList());
		}

		[HttpGet]
		public IActionResult YaratUlke() =>
			PartialView();
		[HttpPost]
		public IActionResult YaratUlke(Ülke ulke)
		{
			try
			{
				db.Ülkeler.Add(ulke);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch
			{
				return Json("Hata oluştu!");
			}
		}
		[HttpGet]
		public IActionResult DüzenleUlke(int id) =>
			PartialView(db.Ülkeler.Find(id));
		[HttpPost]
		public IActionResult DüzenleUlke(Ülke ulke)
		{
			try
			{
				db.Entry(ulke).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();
				return Json("Tamam");
			}
			catch
			{
				return Json("Hata oluştu!");
			}
		}

		[HttpPost]
		public IActionResult SilUlke(int id)
		{
			try
			{
				var ülke = db.Ülkeler.Find(id);
				if (db.Kişiler.FirstOrDefault(u => u.ülke == ülke) != null)
					return Json("SİLİNEMEZ! Bu ülke'ye bağlı kişiler var. Önce onları siliniz.");
				db.Ülkeler.Remove(ülke);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch
			{
				return Json("Hata oluştu!");
			}
		}
		#endregion

		#region Unvan Ayarları
		public IActionResult ListeleUnvan()
		{
			return PartialView(db.Ünvanlar.ToList());
		}

		[HttpGet]
		public IActionResult YaratUnvan() =>
		PartialView();
		[HttpPost]
		public IActionResult YaratUnvan(Ünvan ünvan)
		{
			try
			{
				db.Ünvanlar.Add(ünvan);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch
			{
				return Json("Hata oluştu!");
			}
		}
		[HttpGet]
		public IActionResult DüzenleUnvan(int id) =>
			PartialView(db.Ünvanlar.Find(id));
		[HttpPost]
		public IActionResult DüzenleUnvan(Ünvan ünvan)
		{
			try
			{
				db.Entry(ünvan).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				db.SaveChanges();
				return Json("Tamam");
			}
			catch
			{
				return Json("Hata oluştu!");
			}
		}

		[HttpPost]
		public IActionResult SilUnvan(int id)
		{
			try
			{
				var ünvan = db.Ünvanlar.Find(id);
				if (db.Kişiler.FirstOrDefault(u => u.ünvan == ünvan) != null)
					return Json("SİLİNEMEZ! Bu ünvan'a bağlı kişiler var. Önce onları siliniz.");
				db.Ünvanlar.Remove(ünvan);
				db.SaveChanges();
				return Json("Tamam");
			}
			catch
			{
				return Json("Hata oluştu!");
			}
		}
		#endregion
	}
}