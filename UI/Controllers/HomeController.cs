﻿using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;
using UI.Models.ViewModels;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ListadoPersonas()
        {
            List<PersonaConNombreDepartamento> personaConNombres = new PersonaConNombreDepartamentosVM().Personas;
            return View(personaConNombres);
        }



        public IActionResult EditarPersona(int id)
        {
            var persona = ListadosBL.ListadoPersonasBL().FirstOrDefault(p => p.Id == id);
            var departamentos = ListadosBL.ListadoDepartamentosBL();
            if (persona == null) return NotFound();

            var viewModel = new PersonaConListaDepartamentos(persona, departamentos);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EditarPersona(Persona persona)
        {
            AccionesBL.EditarPersonaBL(persona);
            return RedirectToAction("ListadoPersonas");
        }

        public IActionResult Detalles(int id)
        {
            Persona personas = ListadosBL.ObtenerPersonaPorIdBL(id);
            PersonaConNombreDepartamento personasConDepartamentos =new PersonaConNombreDepartamento(personas);
            return View(personasConDepartamentos);
        }

        public IActionResult CrearPersona()
        { 
            // Obtener el listado de departamentos desde la lógica de negocio
            var departamentos = ListadosBL.ListadoDepartamentosBL();

            // Crear el ViewModel con una lista de departamentos
            var viewModel = new PersonaConListaDepartamentos(
                new Persona(),
                departamentos
            );

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CrearPersona(Persona persona)
        {
            AccionesBL.CrearPersonaBL(persona);
            return RedirectToAction("ListadoPersonas");
        }

        public IActionResult BorrarPersona(int id)
        {
            Persona personas = ListadosBL.ObtenerPersonaPorIdBL(id);
            PersonaConNombreDepartamento personasConDepartamentos = new PersonaConNombreDepartamento(personas);
            return View(personasConDepartamentos);
        }

        [HttpPost]
        public IActionResult ConfirmarBorrado(int id)
        {
            try
            {
                // Llamar a la lógica de negocio para eliminar
                int filasAfectadas = AccionesBL.DeletePersonaBL(id);
                if (filasAfectadas == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar un mensaje adecuado
                ModelState.AddModelError("", "Error al eliminar la persona: " + ex.Message);
                return View("Error");
            }

            return RedirectToAction("ListadoPersonas");
        }





    }
}
