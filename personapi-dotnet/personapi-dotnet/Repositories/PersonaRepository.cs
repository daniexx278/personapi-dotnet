using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly PersonaDbContext _context;

        public PersonaRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // LISTAR TODAS LAS PERSONAS
        public IEnumerable<Persona> GetAll()
        {
            return _context.Personas.ToList();
        }

        // BUSCAR PERSONA POR CC
        public Persona? GetByCc(int cc)
        {
            return _context.Personas.Find(cc);
        }

        // INSERTAR PERSONA
        public void Add(Persona persona)
        {
            _context.Personas.Add(persona);
        }

        // ACTUALIZAR PERSONA
        public void Update(Persona persona)
        {
            _context.Personas.Update(persona);
        }

        // ELIMINAR PERSONA
        public void Delete(int cc)
        {
            var persona = _context.Personas.Find(cc);

            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }
        }

        // GUARDAR CAMBIOS
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}