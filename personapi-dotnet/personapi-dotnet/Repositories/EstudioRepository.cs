using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private readonly PersonaDbContext _context;

        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        // LISTAR TODOS
        public IEnumerable<Estudio> GetAll()
        {
            return _context.Estudios.ToList();
        }

        // BUSCAR POR PK COMPUESTA
        public Estudio? GetByIds(int idProf, int ccPer)
        {
            return _context.Estudios.Find(idProf, ccPer);
        }

        // INSERTAR
        public void Add(Estudio estudio)
        {
            _context.Estudios.Add(estudio);
        }

        // ACTUALIZAR
        public void Update(Estudio estudio)
        {
            _context.Estudios.Update(estudio);
        }

        // ELIMINAR
        public void Delete(int idProf, int ccPer)
        {
            var estudio = _context.Estudios.Find(idProf, ccPer);

            if (estudio != null)
            {
                _context.Estudios.Remove(estudio);
            }
        }

        // GUARDAR CAMBIOS
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}