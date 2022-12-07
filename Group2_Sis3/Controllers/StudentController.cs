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
        public IActionResult Edito(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Studenti studentDb = _konteksti.Studentet.Find(id);
            if (studentDb == null)
            {
                return NotFound();
            }
            ViewBag.Kom = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
            {
                Text = kom.Emri,
                Value = kom.Id.ToString()
            });
            return View(studentDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edito(Studenti stud)
        {
            if (stud.KomunaId == 0)
            {
                ModelState.AddModelError("KomunaId", "Specifiko komunen");
            }
            if (ModelState.IsValid)
            {
                _konteksti.Studentet.Update(stud);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }

            ViewBag.Kom = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
            {
                Text = kom.Emri,
                Value = kom.Id.ToString()
            });
            return View(stud);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fshi(Studenti stud)
        {

                _konteksti.Studentet.Remove(stud);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
        }
        public IActionResult Fshi(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Studenti studentDb = _konteksti.Studentet.Find(id);
            if (studentDb == null)
            {
                return NotFound();
            }
            ViewBag.Kom = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
            {
                Text = kom.Emri,
                Value = kom.Id.ToString()
            });
            return View(studentDb);
        }
        
        public IActionResult Krijo()
        {
            // Studenti stu = new();
            Studenti stu2 = new Studenti();
            // var stud3 = new Studenti();
            ViewBag.Komunat = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
            {
                Text = kom.Emri,
                Value = kom.Id.ToString()
            });
            return View(stu2);
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

            ViewBag.Komunat = _konteksti.Komunat.ToList().Select(kom => new SelectListItem()
            {
                Text = kom.Emri,
                Value = kom.Id.ToString()
            });
            return View(stud);

        }
    }
}
