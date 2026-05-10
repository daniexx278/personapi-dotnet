using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : Controller
    {
        private readonly IPersonaRepository _repository;

        public PersonaController(IPersonaRepository repository)
        {
            _repository = repository;
        }

        // GET: api/persona
        [HttpGet]
        public IActionResult GetAll()
        {
            var personas = _repository.GetAll();

            return Ok(personas);
        }

        // GET: api/persona/123
        [HttpGet("{cc}")]
        public IActionResult GetByCc(int cc)
        {
            var persona = _repository.GetByCc(cc);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // POST: api/persona
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            _repository.Add(persona);

            _repository.Save();

            return Ok(persona);
        }

        // PUT: api/persona/123
        [HttpPut("{cc}")]
        public IActionResult Update(int cc, Persona persona)
        {
            if (cc != persona.Cc)
            {
                return BadRequest();
            }

            _repository.Update(persona);

            _repository.Save();

            return Ok(persona);
        }

        // DELETE: api/persona/123
        [HttpDelete("{cc}")]
        public IActionResult Delete(int cc)
        {
            var persona = _repository.GetByCc(cc);

            if (persona == null)
            {
                return NotFound();
            }

            _repository.Delete(cc);

            _repository.Save();

            return Ok();
        }
    }
}