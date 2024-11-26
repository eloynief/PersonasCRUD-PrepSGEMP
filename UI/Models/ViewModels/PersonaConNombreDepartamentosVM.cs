using Entities;

namespace UI.Models.ViewModels
{
    public class PersonaConNombreDepartamentosVM
    {

        public List<PersonaConNombreDepartamento> Personas { get; }

        public PersonaConNombreDepartamentosVM()
        {
            List<Persona> personas = BL.ListadosBL.ListadoPersonasBL();

            List<PersonaConNombreDepartamento> personasConNombres = new List<PersonaConNombreDepartamento>();

            foreach (Persona persona in personas)
            {
                personasConNombres.Add(new PersonaConNombreDepartamento(persona));
            }

            Personas = personasConNombres;
        }


    }
}
