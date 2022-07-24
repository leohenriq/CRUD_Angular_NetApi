using System.Net.Mime;
using CRUDApi.Interface;
using CRUDApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _repository;

        public PessoaController(IPessoaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Pessoa>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Get()
        {
            var result = await _repository.GetAll();
            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return result.ToList();
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Pessoa))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pessoa>> Get(long id)
        {
            var result = await _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Pessoa))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Pessoa>> Add([FromBody] Pessoa obj)
        {
            if (obj == null)
            {
                return NotFound();
            }

            await _repository.Add(obj);

            return obj;
        }

        [HttpPut("{id:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(long id, Pessoa obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            if (await _repository.GetById(id) == null)
            {
                return NotFound();
            }

            await _repository.Update(obj);

            return NoContent();
        }

        [HttpPut("StatusEnable/{id:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> StatusEnable(long id, Pessoa obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            if (await _repository.GetById(id) == null)
            {
                return NotFound();
            }

            await _repository.StatusEnable(id);

            return NoContent();
        }

        [HttpPut("StatusDisable/{id:long}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> StatusDisable(long id, Pessoa obj)
        {
            if (id != obj.Id)
            {
                return BadRequest();
            }

            if (await _repository.GetById(id) == null)
            {
                return NotFound();
            }

            await _repository.StatusDisable(id);

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(long id)
        {
            var obj = await _repository.GetById(id);
            if (obj == null)
            {
                return NotFound();
            }

            await _repository.Delete(obj);

            return NoContent();
        }
    }
}
