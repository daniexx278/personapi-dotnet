using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly PersonaDbContext _context;

        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // LISTAR TODOS
        public IEnumerable<Telefono> GetAll()
        {
            return _context.Telefonos.ToList();
        }

        // BUSCAR POR NUM
        public Telefono? GetByNum(string num)
        {
            return _context.Telefonos.Find(num);
        }

        // INSERTAR
        public void Add(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);
        }

        // ACTUALIZAR
        public void Update(Telefono telefono)
        {
            _context.Telefonos.Update(telefono);
        }

        // ELIMINAR
        public void Delete(string num)
        {
            var telefono = _context.Telefonos.Find(num);

            if (telefono != null)
            {
                _context.Telefonos.Remove(telefono);
            }
        }

        // GUARDAR CAMBIOS
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}