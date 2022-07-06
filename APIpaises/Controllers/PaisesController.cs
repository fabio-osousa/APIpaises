using APIpaises.Model;
using APIpaises.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIpaises.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisesRepository _paisesRepository;
        public PaisesController(IPaisesRepository paisesRepository)
        {
            _paisesRepository = paisesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Paises>> GetPaises()
        {
            return await _paisesRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> GetPaises(int id)
        {
            return await _paisesRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Paises>> PostPaises([FromBody] Paises paises)
        {
            var newpaises = await _paisesRepository.Create(paises);
            return CreatedAtAction(nameof(GetPaises), new { id = newpaises.ID }, newpaises);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var paisesToDelete = await _paisesRepository.Get(id);
            
            if(paisesToDelete == null)
                return NotFound();

            await _paisesRepository.Delete(paisesToDelete.ID);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> PutPaises(int id,[FromBody] Paises paises)
        {
            if (id != paises.ID)
                return BadRequest();

                await _paisesRepository.Updade(paises);

            return NoContent();
        }
    }
}
