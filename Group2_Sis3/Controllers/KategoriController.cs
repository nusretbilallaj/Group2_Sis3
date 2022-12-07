using Group2_Sis3.Data;
using Group2_Sis3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Group2_Sis3.Controllers
{
    public class KategoriController : Controller
    {
        private Konteksti _konteksti;
        public KategoriController(Konteksti kon)
        {
            _konteksti = kon;
        }
        public IActionResult Listo()
        {
           
            List<Kategoria> lista = _konteksti.Kategorite.ToList();
            return View(lista);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edito(Kategoria x)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Update(x);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }

            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fshi(Kategoria kat)
        {

                _konteksti.Kategorite.Remove(kat);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
        }
        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Kategoria kat = _konteksti.Kategorite.Find(id);
            if (kat == null)
            {
                return NotFound();
            }
            return View(kat);
        }
        public IActionResult Edito(int? id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }

            Kategoria kat = _konteksti.Kategorite.Find(id);
            if (kat == null)
            {
                return NotFound();
            }
            return View(kat);
        }
        public IActionResult Krijo()
        {
            // Studenti stu = new();
            Kategoria kat = new Kategoria();
            // var stud3 = new Studenti();
            return View(kat);
        }
        [HttpPost]
        public IActionResult Krijo(Kategoria kat)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Kategorite.Add(kat);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }

            return View(kat);
        }
    }
}
