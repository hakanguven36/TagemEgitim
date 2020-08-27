using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TagemEgitim.Araclar;
using TagemEgitim.Models;

namespace TagemEgitim.Areas.Admin.Controllers
{
	
	[Area("Admin")]
	public class HomeController : Controller
	{
		MyContext db;
		public HomeController(MyContext db) => this.db = db;

		public IActionResult Index()
		{
			return RedirectToAction("Index","Kullanıcılar",new { area = "Admin" });
		}
		public IActionResult Kurulum()
		{
			try
			{
				if(db.Kullar.FirstOrDefault(u=>u.admin == true) == null)
				{
					Kullar kul = new Kullar();
					kul.admin = true;
					kul.adminCode = "oguz".encin();
					kul.kulname = "oguz";
					kul.kulpass = "oz1184";
					db.Kullar.Add(kul);
					db.SaveChanges();
				}
				return Json("Kurulum Tamamlandı.");
			}
			catch (Exception e)
			{
				return Json("Hata: " + e.Message);
			}
		}
	}
}