using Group2_Sis3.Data;
using Group2_Sis3.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
