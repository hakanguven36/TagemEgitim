using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagemEgitim.Models;
using System.Globalization;
using TagemEgitim.Araclar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TagemEgitim.Controllers
{
	[Yetki("user")]
	public class KurslarController : Controller
    {
		MyContext db;
		IConfiguration configuration;
		public KurslarController(MyContext db, IConfiguration configuration)
		{
			this.db = db;
			this.configuration = configuration;
		}

        public IActionResult Index(int id = 0)
        {
			ViewBag.buKursaDön = id;
            return View();
        }

		public IActionResult Listele(int yıl, string aranan, ULUSTÜRÜ? ulustürü, EVTÜRÜ? evtürü, TOPLANTITÜRÜ? toplantıtürü, int pageNo = 1, int selectedKurs= 0)
		{
			
			var ret = db.Kurslar.Include(k=>k.kişikurs).Include(k=>k.obscures).OrderByDescending(u=>u.tarihBasla).ToList();

			if (yıl > 0) ret = ret.Where(u => u.yıl == yıl).ToList();
			if (ulustürü != null) ret = ret.Where(u => u.ulustürü == ulustürü).ToList();
			if (evtürü != null) ret = ret.Where(u => u.evtürü == evtürü).ToList();
			if (toplantıtürü != null) ret = ret.Where(u => u.toplantıtürü == toplantıtürü).ToList();
			if (!string.IsNullOrWhiteSpace(aranan))
			{
				ret = ret.Where(u =>
					u.isim.tooString().ToString().Contains(aranan) |
					u.isimEN.tooString().ToLower().Contains(aranan))
					.ToList();
			}

			Pagination<Kurs> pagination = new Pagination<Kurs>(Convert.ToInt32( configuration.GetSection("PaginationSettings").GetValue(typeof(int) , "KursListPageItem")));
			int indexofSelected = 0;
			if (selectedKurs > 0)
				indexofSelected = ret.IndexOf(ret.FirstOrDefault(u => u.ID == selectedKurs));  

			ret = pagination.GetPage(ret, pageNo, indexofSelected);
			ViewBag.pagination = pagination;

			return PartialView(ret);
		}

		public IActionResult KatılımListesi(int kursID)
		{
			var ret = 
				db.Kurslar
				.Include(k => k.kişikurs).ThenInclude(k => k.kişi).ThenInclude(k => k.ülke)
				.Include(k => k.kişikurs).ThenInclude(k => k.kişi).ThenInclude(k => k.ünvan)
				.Include(k => k.obscures)
				.FirstOrDefault(u => u.ID == kursID);
			return PartialView(ret);
		}

		public IActionResult KursDetay(int id)
		{
			var ret = db.Kurslar.Include(k => k.kişikurs).Include(k => k.obscures).FirstOrDefault(u => u.ID == id);
			return PartialView(ret);
		}

		[HttpGet]
		public IActionResult KursYarat()
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult KursYarat(Kurs kurs)
		{
			db.Kurslar.Add(kurs);
			db.SaveChanges();
			return Json(new { kursID = kurs.ID });
		}

		[HttpGet]
		public IActionResult KursDüzenle(int id)
		{
			return PartialView(db.Kurslar.Find(id));
		}
		[HttpPost]
		public IActionResult KursDüzenle(Kurs kurs)
		{
			try
			{

				db.Entry(kurs).State = EntityState.Modified;
				db.SaveChanges();
				return Json("Tamam");
			}
			catch(Exception e)
			{
				return Json("Hata: "+e.Message);
			}
		}

		[HttpPost]
		public IActionResult KursSil(int id)
		{
			try
			{
				var kurs = db.Kurslar.Find(id);
				foreach (var item in db.kişikurs.Where(u=>u.kursID == kurs.ID))
				{
					db.Remove(item);
				}
				foreach (var item in db.Obscures.Where(u => u.kursID == kurs.ID))
				{
					db.Remove(item);
				}
				db.Remove(kurs);
				db.SaveChanges();
				return Json("Silindi.");
			}
			catch(Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}


	}
}