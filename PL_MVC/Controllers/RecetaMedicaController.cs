using Microsoft.AspNetCore.Mvc;

namespace PL_MVC.Controllers
{
    public class RecetaMedicaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            ML.Result result = BL.RecetaMedica.GetAll();

            if (result.Correct)
            {
                recetaMedica.RecetaMedicas = result.Objects.ToList();
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            return View(recetaMedica);
        }
        [HttpPost]
        public IActionResult GetAll(ML.RecetaMedica recetaMedica)
        {
            ML.Result result = BL.RecetaMedica.GetAll();
            recetaMedica.RecetaMedicas = result.Objects;

            return View(recetaMedica);
        }

        [HttpGet]
        public ActionResult Form(int? IdReceta)
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            recetaMedica.Paciente = new ML.Paciente();
            ML.Result resultPaciente = BL.Paciente.GetAll();

            if (IdReceta != null)
            {
                ML.Result result = BL.RecetaMedica.GetById(IdReceta.Value);
                if (result.Correct)
                {

                    recetaMedica = (ML.RecetaMedica)result.Object;
                    recetaMedica.Paciente.Pacientes = resultPaciente.Objects;
                }

            }
            else
            {
                recetaMedica.Paciente.Pacientes = resultPaciente.Objects;
            }

            return View(recetaMedica);
        }
        [HttpPost]
        public ActionResult Form(ML.RecetaMedica recetaMedica)
        {

                if (recetaMedica.IdReceta == 0 || recetaMedica.IdReceta == null)
                {
                    ML.Result result = BL.RecetaMedica.AddEF(recetaMedica);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Se ha completado el registro";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;
                    }

                }
                else
                {

                    ML.Result result = BL.RecetaMedica.Update(recetaMedica);

                    if (result.Correct)
                    {

                        ViewBag.Mensaje = "Se ha completado la actualizacion";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error" + result.ErrorMessage;
                    }
                }


                return PartialView("Modal");

          
        }



        [HttpGet]
        public ActionResult Delete(int IdReceta)
        {

            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            ML.Result result = BL.RecetaMedica.Delete(IdReceta);
            if (result.Correct)
            {

                ViewBag.Mensaje = "Materia eliminada correctamente";
            }
            else
            {
                ViewBag.Mensaje = "No se logro eliminar la materia: " + result.ErrorMessage;
            }

            return PartialView("Modal");
        }




    }
}
