using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TagemEgitim.Araclar;
using TagemEgitim.Models;
using TagemEgitim.ViewModels;

namespace TagemEgitim.Controllers
{
	[Yetki("user")]
	public class KişilerController : Controller
    {
        MyContext db;
		IConfiguration configuration;

        public KişilerController(MyContext db, IConfiguration configuration)
		{
			this.db = db;
			this.configuration = configuration;
		}

        public IActionResult Index()
		{
			ViewBag.ülkeList = db.Ülkeler.ToList();
            return View();
		}

        public IActionResult Listele(string search, int ulkeID, string order, bool desc, int pageNo = 1, int kursID = 0)
        {
            var kisiList = db.Kişiler
				.Include(k => k.ülke)
				.Include(k => k.ünvan)
				.Include(k=>k.kişikurs).ThenInclude(k=>k.kurs)
				.OrderByDescending(u=>u.ID).ToList();

            // ULKE
            if(ulkeID > 0)
                kisiList = kisiList.Where(u => u.ülkeID == ulkeID).ToList();

			// SEARCH
			if (!string.IsNullOrWhiteSpace(search))
				kisiList = FiltreSearch(kisiList, search);


            // ORDERBY
            if(!string.IsNullOrWhiteSpace(order))
				kisiList = FiltreOrder(kisiList, order, desc);

			// pageNo
			Pagination<Kişi> p = new Pagination<Kişi>(Convert.ToInt32(configuration.GetSection("PaginationSettings").GetValue(typeof(int), "KisiListPageItem")));
			var paged = p.GetPage(kisiList, pageNo, 0);
			PaginationViewModel pagination = new PaginationViewModel()
			{
				itemCount = p.itemCount,
				totalPage = p.totalPage,
				currentPage = p.currentPage,
				isFirstPage = p.isFirstPage,
				isLastPage = p.isLastPage
			};
			ViewBag.pagination = pagination;
			return PartialView(paged);
        }

		private List<Kişi> FiltreSearch(List<Kişi> kisiList, string search)
		{
			try
			{
			search = search.ToLower();
						var ret = kisiList.Where(u => u.isim.ToLower().Contains(search) ||
													u.soyisim.ToLower().Contains(search) ||
													(u.isim + " " + u.soyisim).ToLower().Contains(search) ||
													u.email.tooString().ToLower().Contains(search) ||
													u.kurum.tooString().ToLower().Contains(search)

													).ToList();
			return ret;
			}
			catch (Exception e)
			{
				string hata = e.Message;
				return kisiList;
			}
			
		}

		private List<Kişi> FiltreOrder(List<Kişi> kisiList, string order, bool desc)
		{
			var quarable = kisiList.AsQueryable();
			if (!desc)
				return DynamicQueryableExtensions.OrderBy(quarable, order).ToList();

			else
				return DynamicQueryableExtensions.OrderBy(quarable, order + " desc").ToList();
		}

		// GET: Kisilers/Details/5
		public IActionResult Detay(int id)
        {
			try
			{
				var kisiler = db.Kişiler
					.Include(k => k.ülke)
					.Include(k => k.ünvan)
					.FirstOrDefault(m => m.ID == id);
				return PartialView(kisiler);
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
        }

		[HttpGet]
        public IActionResult Yarat()
        {
            ViewData["ünvanID"] = new SelectList(db.Ünvanlar, "ID", "isim");
			ViewData["ülkeID"] = new SelectList(db.Ülkeler, "ID", "isim");
			return PartialView();
        }

        [HttpPost]
        public IActionResult Yarat(Kişi kişi)
        {
			try
            {
				db.Add(kişi);
				db.SaveChanges();
				return Json("Tamam");
            }
			catch(Exception e)
			{
				return Json("Hata: " + e.Message);
			}
        }

        [HttpGet]
        public IActionResult Düzenle(int id)
        {
            var kisiler = db.Kişiler.Find(id);
            if (kisiler == null)
                return NotFound();
            ViewData["ülkeID"] = new SelectList(db.Ülkeler, "ID", "isim", kisiler.ülkeID);
            ViewData["ünvanID"] = new SelectList(db.Ünvanlar, "ID", "isim", kisiler.ünvanID);
            return PartialView(kisiler);
        }

        [HttpPost]
        public IActionResult Düzenle(Kişi kişi)
        {
			try
			{
				db.Entry(kişi).State = EntityState.Modified;
				db.SaveChanges();
				return Json("Tamam");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
            }
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
			try
			{
                var kişi = db.Kişiler.Find(id);
                db.Kişiler.Remove(kişi);
                var kisikurs = db.kişikurs.Where(u => u.kişiID == id).ToList();
                db.kişikurs.RemoveRange(kisikurs);
                db.SaveChanges();
                return Json("Tamam");
			}
			catch (Exception e)
			{
                return Json("Hata: " + e.Message);
			}
        }

        private bool KişiExists(int id)
        {
            return db.Kişiler.Any(e => e.ID == id);
        }
	}
}
