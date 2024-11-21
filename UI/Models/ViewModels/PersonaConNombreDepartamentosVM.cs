namespace UI.Models.ViewModels
{
    public class PersonaConNombreDepartamentosVM
    {

        public List<PersonaConNombreDepartamento> Personas { get; }

        public PersonaConNombreDepartamentosVM(List<PersonaConNombreDepartamento> personas)
        {
            Personas = personas;
        }


    }
}
