using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {

        // GET: PersonasController
        public ActionResult Listado()
        {

            // Obtener lista de personas desde la BL
            List<Persona> personas;
            // Crear el ViewModel
            PersonaConNombreDepartamentosVM viewModel = null;
            try
            {
                personas = ListadosBL.ListadoPersonasBL();

                // Transformar cada Persona en PersonaConNombreDepartamento
                List<PersonaConNombreDepartamento> personasConDepartamento = personas
                    .Select(persona =>
                    {
                        return new PersonaConNombreDepartamento(persona);
                    })
                    .ToList();

                viewModel = new PersonaConNombreDepartamentosVM(personasConDepartamento);
            }
            catch (Exception ex)
            {
                // Pasar el error a la vista si no obtiene valor
                return View("MiError");
            }

            // Pasar el ViewModel a la vista
            return View(viewModel);

        }





        // GET: aController/Details/5
        public ActionResult Detalles(int id)
        {


            // Obtener persona aleatoria
            Persona persona = BL.ListadosBL.ObtenerPersonaPorId(id);


            // Crear el ViewModel
            PersonaConNombreDepartamento miPersona = new PersonaConNombreDepartamento(persona);

            //retornamos la vista con la persona del ViewModel
            return View(miPersona);
        }







        // GET: Controller/Edit/5
        public ActionResult Edit(int id)
        {

            // Obtener persona aleatoria
            Persona persona =BL.ListadosBL.ObtenerPersonaPorId(id);

            // Obtener listado de departamentos
            List<Departamento> departamentos = BL.ListadosBL.ListadoDepartamentosBL();

            // Crear el ViewModel
            PersonaConListaDepartamentos miPersona = new PersonaConListaDepartamentos(persona, departamentos);

            //retornamos la vista con la persona del ViewModel
            return View(miPersona);
        }

        // POST: Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar(int id)
        {
            try
            {
                // Llamamos al método DAL para eliminar la persona
                int filasEliminadas = AccionesBL.DeletePersonaBL(id);

                if (filasEliminadas > 0)
                {
                    // Redirigir a la vista de listado de personas si se eliminó correctamente.
                    return RedirectToAction("Listado");
                }
                else
                {
                    // Mostrar un mensaje de error si no se eliminó nada.
                    ViewBag.Error = "No se encontró la persona para eliminar.";
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                // Capturar y manejar el error adecuadamente.
                ViewBag.Error = "Error al eliminar la persona.";
                return View("MiError");
            }
        }



    }
}
