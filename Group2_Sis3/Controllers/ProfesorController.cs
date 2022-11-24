using Group2_Sis3.Data;
using Group2_Sis3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Group2_Sis3.Controllers
{
    public class ProfesorController : Controller
    {
        private Konteksti _konteksti;
        public ProfesorController(Konteksti kon)
        {
            _konteksti = kon;
        }
        public IActionResult Listo()
        {
            List<Profesori> lista = _konteksti.Profesoret.ToList();
            return View(lista);
        }
    }
}
