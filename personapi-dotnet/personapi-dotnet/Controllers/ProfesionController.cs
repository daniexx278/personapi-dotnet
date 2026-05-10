using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Interfaces;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfesionController : Controller
	{
		private readonly IProfesionRepository _repository;

		public ProfesionController(IProfesionRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult GetAll()
		{
			return Ok(_repository.GetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var profesion = _repository.GetById(id);

			if (profesion == null)
			{
				return NotFound();
			}

			return Ok(profesion);
		}

		[HttpPost]
		public IActionResult Create(Profesion profesion)
		{
			_repository.Add(profesion);

			_repository.Save();

			return Ok(profesion);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id, Profesion profesion)
		{
			if (id != profesion.Id)
			{
				return BadRequest();
			}

			_repository.Update(profesion);

			_repository.Save();

			return Ok(profesion);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var profesion = _repository.GetById(id);

			if (profesion == null)
			{
				return NotFound();
			}

			_repository.Delete(id);

			_repository.Save();

			return Ok();
		}
	}
}