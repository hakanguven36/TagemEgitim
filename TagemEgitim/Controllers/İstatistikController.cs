using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TagemEgitim.Araclar;
using TagemEgitim.Models;
using TagemEgitim.ViewModels;

namespace TagemEgitim.Controllers
{
	[Yetki("user")]
	public class İstatistikController : Controller
    {
		MyContext db;
		public İstatistikController(MyContext db) => this.db = db;

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Listele(DateTime? tarihStart, DateTime? tarihEnd)
		{
			var ret = db.Kurslar
				.Include(k => k.kişikurs)
				.Include(k => k.obscures)
				.Where(u => u.tarihBitis > tarihStart & u.tarihBasla < tarihEnd).ToList();
			return PartialView(ret);
		}

		public IActionResult GelismisFiltreleme()
		{
			return PartialView();
		}

		public IActionResult GelişmişGetir(GelismisİstatistikViewModel model)
		{
			var ret = db.Kurslar
				.Include(k => k.kişikurs)
				.Include(k => k.obscures)
				.Where(u => u.tarihBitis > model.tarihStart& u.tarihBasla < model.tarihEnd).ToList();

			if (!model.ulus_a & !model.ulus_u)
				return Json("Hata: Ulus türlerinden en az biri seçilmeli");
			if (!model.ulus_u)
				ret = ret.Where(u => u.ulustürü != ULUSTÜRÜ.Ulusal).ToList();
			if (!model.ulus_a)
				ret = ret.Where(u => u.ulustürü != ULUSTÜRÜ.Uluslararası).ToList();


			if (!model.ev_s & !model.ev_o)
				return Json("Hata: Ev türlerinden en az biri seçilmeli");
			if (!model.ev_s)
				ret = ret.Where(u => u.evtürü != EVTÜRÜ.EvSahipliği).ToList();
			if (!model.ev_o)
				ret = ret.Where(u => u.evtürü != EVTÜRÜ.Organizasyon).ToList();


			if (!model.topl_c & !model.topl_e & !model.topl_t)
				return Json("Hata: Toplantı türlerinden en az biri seçilmeli");
			if (!model.topl_c)
				ret = ret.Where(u => u.toplantıtürü != TOPLANTITÜRÜ.Çalıştay).ToList();
			if (!model.topl_e)
				ret = ret.Where(u => u.toplantıtürü != TOPLANTITÜRÜ.Eğitim).ToList();
			if (!model.topl_t)
				ret = ret.Where(u => u.toplantıtürü != TOPLANTITÜRÜ.Toplantı).ToList();

			return PartialView(ret);
		}
    }
}