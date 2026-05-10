using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Interfaces
{
    public interface IEstudioRepository
    {
        IEnumerable<Estudio> GetAll();

        Estudio? GetByIds(int idProf, int ccPer);

        void Add(Estudio estudio);

        void Update(Estudio estudio);

        void Delete(int idProf, int ccPer);

        void Save();
    }
}