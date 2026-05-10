using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : Controller
    {
        private readonly IEstudioRepository _repository;

        public EstudioController(IEstudioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{idProf}/{ccPer}")]
        public IActionResult GetByIds(int idProf, int ccPer)
        {
            var estudio = _repository.GetByIds(idProf, ccPer);

            if (estudio == null)
            {
                return NotFound();
            }

            return Ok(estudio);
        }

        [HttpPost]
        public IActionResult Create(Estudio estudio)
        {
            _repository.Add(estudio);

            _repository.Save();

            return Ok(estudio);
        }

        [HttpPut("{idProf}/{ccPer}")]
        public IActionResult Update(int idProf, int ccPer, Estudio estudio)
        {
            if (idProf != estudio.IdProf || ccPer != estudio.CcPer)
            {
                return BadRequest();
            }

            _repository.Update(estudio);

            _repository.Save();

            return Ok(estudio);
        }

        [HttpDelete("{idProf}/{ccPer}")]
        public IActionResult Delete(int idProf, int ccPer)
        {
            var estudio = _repository.GetByIds(idProf, ccPer);

            if (estudio == null)
            {
                return NotFound();
            }

            _repository.Delete(idProf, ccPer);

            _repository.Save();

            return Ok();
        }
    }
}