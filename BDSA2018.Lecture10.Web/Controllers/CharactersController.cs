using BDSA2018.Lecture10.Models;
using BDSA2018.Lecture10.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2018.Lecture10.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterRepository _repository;
        private readonly IHubContext<LogHub> _hubContext;

        public CharactersController(ICharacterRepository repository, IHubContext<LogHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        // GET api/characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> Get()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "GET api/characters");

            return await _repository.Read().ToListAsync();
        }

        // GET api/characters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> Get(int id)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"GET api/characters/{id}");

            var character = await _repository.FindAsync(id);

            if (character == null)
            {
                return NotFound();
            }

            return character;
        }

        // POST api/characters
        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> Post([FromBody] CharacterCreateUpdateDTO character)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "GET api/character");

            var dto = await _repository.CreateAsync(character);

            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        // PUT api/characters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CharacterCreateUpdateDTO character)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"PUT api/characters/{id}");

            var updated = await _repository.UpdateAsync(character);

            if (updated)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/characters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"DELETE api/characters/{id}");

            var deleted = await _repository.DeleteAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
