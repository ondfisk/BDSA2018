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
    public class ActorsController : ControllerBase
    {
        private readonly IActorRepository _repository;
        private readonly IHubContext<LogHub> _hubContext;

        public ActorsController(IActorRepository repository, IHubContext<LogHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        // GET: api/actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActorDTO>>> Get()
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "GET api/actors");

            return await _repository.Read().ToListAsync();
        }

        // GET: api/actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDetailedDTO>> Get(int id)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"GET api/characters/{id}");

            var actor = await _repository.FindAsync(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

        // POST: api/actors
        [HttpPost]
        public async Task<ActionResult<ActorDetailedDTO>> Post([FromBody] ActorCreateUpdateDTO actor)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"POST api/characters");

            var created = await _repository.CreateAsync(actor);

            return CreatedAtAction(nameof(Get), new { created.Id }, created);
        }

        // PUT: api/actors/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActorCreateUpdateDTO actor)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"PUT api/characters/{id}");

            var result = await _repository.UpdateAsync(actor);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", $"DELETE api/characters/{id}");

            var result = await _repository.DeleteAsync(id);

            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
