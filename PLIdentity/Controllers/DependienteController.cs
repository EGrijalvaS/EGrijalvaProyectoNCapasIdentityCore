using Microsoft.AspNetCore.Mvc;

namespace PLIdentity.Controllers
{
    public class DependienteController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()  // Mostrar todo
        {
            ML.Result result = BL.Dependiente.DependienteGetAll();
            ML.Dependiente dependiente = new ML.Dependiente();

            if (result.Correct)
            {
                dependiente.Dependientes = result.Objects;
                return View(dependiente);
            }
            else
            {
                return View(dependiente);
            }
        }

        public IActionResult Form()
        {

        }
    }
}
