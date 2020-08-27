using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TagemEgitim.Araclar;
using TagemEgitim.Models;

namespace TagemEgitim.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Yetki("admin")]
    public class KullanıcılarController : Controller
    {
        MyContext db;
        public KullanıcılarController(MyContext db) => this.db = db;

        // GET: Admin/Kullanıcılar
        public async Task<IActionResult> Index()
        {
            return View(await db.Kullar.ToListAsync());
        }

        // GET: Admin/Kullanıcılar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullar = await db.Kullar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kullar == null)
            {
                return NotFound();
            }

            return View(kullar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Kullar kullar)
        {
            if (ModelState.IsValid)
            {
				if(db.Kullar.FirstOrDefault(u=>u.kulname == kullar.kulname) != null)
				{
					ModelState.AddModelError("", "Bu isimde bir kişi zaten var!");
					return View(kullar);
				}

                db.Add(kullar);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullar);
        }

        // GET: Admin/Kullanıcılar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullar = await db.Kullar.FindAsync(id);
            if (kullar == null)
            {
                return NotFound();
            }
            return View(kullar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,kulname,kulpass,kulpassEnc,hatirla,cerez,cerezEnc,hatali,kilitliTarih,admin,adminCode")] Kullar kullar)
        {
            if (id != kullar.ID)
            {
                return NotFound();
            }

			if(db.Kullar.Find(id).kulname == "oguz" & kullar.kulname != "oguz")
			{
				ModelState.AddModelError("", "Bu kişinin ismi değiştirilemez");
				return View(kullar);
			}

			if (db.Kullar.Find(id).kulname == "oguz" & kullar.admin != true)
			{
				ModelState.AddModelError("", "Bu kişinin adminliği sorgulanamaz!");
				return View(kullar);				
			}

			if (ModelState.IsValid)
            {
                try
                {
					db.Update(kullar);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullarExists(kullar.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kullar);
        }

        // GET: Admin/Kullanıcılar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var kullar = await db.Kullar
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kullar == null)
            {
                return NotFound();
            }
			if(db.Kullar.Find(id).kulname == "oguz")
			{
				return Json("Bu kişi silinemez!!!");
			}

            return View(kullar);
        }

        // POST: Admin/Kullanıcılar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullar = await db.Kullar.FindAsync(id);
            db.Kullar.Remove(kullar);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullarExists(int id)
        {
            return db.Kullar.Any(e => e.ID == id);
        }
    }
}
