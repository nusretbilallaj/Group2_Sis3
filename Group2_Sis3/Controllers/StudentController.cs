using Group2_Sis3.Data;
using Group2_Sis3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Group2_Sis3.Controllers
{
    public class StudentController : Controller
    {
        private Konteksti _konteksti;
        public StudentController(Konteksti kon)
        {
            _konteksti = kon;
        }
        public IActionResult Listo()
        {
            List<Studenti> lista = _konteksti.Studentet.ToList();
            return View(lista);
        }
        public IActionResult Krijo()
        {
            Studenti stu = new Studenti();
            ViewBag.Komunat = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
            {
                Text = kom.Emri,
                Value = kom.Id.ToString()
            });
            return View(stu);
        }
        [HttpPost]
        public IActionResult Krijo(Studenti stud)
        {
            if (stud.KomunaId==0)
            {
                ModelState.AddModelError("KomunaId","Specifiko komunen");
            }
            if (ModelState.IsValid)
            {
                _konteksti.Add(stud);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            else
            {
                ViewBag.Komunat = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
                {
                    Text = kom.Emri,
                    Value = kom.Id.ToString()
                });
                return View(stud);
            }
        }
    }
}
