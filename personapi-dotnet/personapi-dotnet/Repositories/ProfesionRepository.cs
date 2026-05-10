using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class ProfesionRepository : IProfesionRepository
    {
        private readonly PersonaDbContext _context;

        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // LISTAR TODAS
        public IEnumerable<Profesion> GetAll()
        {
            return _context.Profesions.ToList();
        }

        // BUSCAR POR ID
        public Profesion? GetById(int id)
        {
            return _context.Profesions.Find(id);
        }

        // INSERTAR
        public void Add(Profesion profesion)
        {
            _context.Profesions.Add(profesion);
        }

        // ACTUALIZAR
        public void Update(Profesion profesion)
        {
            _context.Profesions.Update(profesion);
        }

        // ELIMINAR
        public void Delete(int id)
        {
            var profesion = _context.Profesions.Find(id);

            if (profesion != null)
            {
                _context.Profesions.Remove(profesion);
            }
        }

        // GUARDAR CAMBIOS
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}