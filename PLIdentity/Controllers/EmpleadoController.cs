using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace PLIdentity.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()   // Controlador para Mostrar todo
        {
            ML.Result result = BL.Empleado.EmpleadoGetAll();
            ML.Empleado empleado = new ML.Empleado();
            
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }

        }

        // [Authorize(Roles = "Administrador, Usuario")]
        [HttpGet]
        public ActionResult Form(string NumeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();

            if (NumeroEmpleado == null)
            {
                return View(empleado);
            }
            else          //getById
            {
                ML.Result result = BL.Empleado.EmpleadoGetById(empleado);

                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object;   //Unboxing                 

                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al Consultar la Información del Empleado";
                    return View("Modal");
                }

            }


        }

        // [Authorize(Roles = "Administrador, Usuario")]
        [HttpPost]
        public ActionResult Form(ML.Empleado empleado)
        {

            ML.Result result = new ML.Result();

            if (empleado.NumeroEmpleado == null)
            {
                //add 
                result = BL.Empleado.EmpleadoAdd(empleado);

                if (result.Correct)
                {
                    ViewBag.Message = "Se Completo el Registro Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Agregar el Registro";
                }

                return View();
            }
            else         // UPDATE
            {
                result = BL.Empleado.EmpleadoUpdate(empleado);

                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo el Empleado Correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un Error al Actualizar el Registro";
                }

                return View("Modal");
            }


        }

        //[HttpGet]
        //public ActionResult Delete(string NumeroEmpleado)
        //{
        //    ML.Result result = BL.Empleado.EmpleadoDelete(empleado);

        //    return View();
        //}

    }
}
