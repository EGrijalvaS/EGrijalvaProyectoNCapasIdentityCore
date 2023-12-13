using Microsoft.AspNetCore.Mvc;

namespace PLIdentity.Controllers
{
    public class EmpresaController : Controller
    {
        [HttpGet] // Método Get para traer todos los datos de la table Empresa
        public IActionResult GetAll()
        {
            ML.Result result = BL.Empresa.EmpresaGetAll();
            ML.Empresa empresa = new ML.Empresa();

            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
                return View(empresa);
            }
            else
            {
                return View(empresa);
            }           
        }

        [HttpGet]
        public IActionResult Form(int IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();

                if (IdEmpresa == 0)
                {
                   return View(empresa);
                }
            else
            {
                ML.Result result = BL.Empresa.EmpresaGetById(empresa);

                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Object;

                    return View(empresa);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error";
                    return View(empresa);
                }
            }
        }

        [HttpPost]
        public IActionResult Form(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            
            if (empresa.IdEmpresa == 0)
            {
                result = BL.Empresa.EmpresaAdd(empresa);  // Agregar Empresa 
                
                if (result.Correct)
                {
                    ViewBag.Message = "El Registro de la Empresa se ha Agregado Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Agregar el Registro";
                }

                return View();
            }
            else
            {
                result = BL.Empresa.EmpresaUpdate(empresa);

                if (result.Correct)
                {
                    ViewBag.Message = "La Empresa se actualizo correctamente";
                }
                else
                {
                    ViewBag.Message = " Ocurrio un Error al Actualizar el Registro";
                }
                return View("Modal");
            }
        }
    }
}
