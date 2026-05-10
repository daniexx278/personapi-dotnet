using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController : Controller
    {
        private readonly ITelefonoRepository _repository;

        public TelefonoController(ITelefonoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{num}")]
        public IActionResult GetByNum(string num)
        {
            var telefono = _repository.GetByNum(num);

            if (telefono == null)
            {
                return NotFound();
            }

            return Ok(telefono);
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            _repository.Add(telefono);

            _repository.Save();

            return Ok(telefono);
        }

        [HttpPut("{num}")]
        public IActionResult Update(string num, Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            _repository.Update(telefono);

            _repository.Save();

            return Ok(telefono);
        }

        [HttpDelete("{num}")]
        public IActionResult Delete(string num)
        {
            var telefono = _repository.GetByNum(num);

            if (telefono == null)
            {
                return NotFound();
            }

            _repository.Delete(num);

            _repository.Save();

            return Ok();
        }
    }
}