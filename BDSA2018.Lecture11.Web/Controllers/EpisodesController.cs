using BDSA2018.Lecture11.Services;
using BDSA2018.Lecture11.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BDSA2018.Lecture11.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EpisodesController : ControllerBase
    {
        private IEpisodeRepository _repository;

        public EpisodesController(IEpisodeRepository repository)
        {
            _repository = repository;
        }

        // GET api/episodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDTO>>> Get()
        {
            return await _repository.Read().ToListAsync();
        }

        // GET api/episodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EpisodeDetailedDTO>> Get(int id)
        {
            var episode = await _repository.FindAsync(id);

            if (episode == null)
            {
                return NotFound();
            }

            return episode;
        }

        // POST api/episodes
        [HttpPost]
        public async Task<ActionResult<EpisodeDetailedDTO>> Post([FromBody] EpisodeCreateUpdateDTO episode)
        {
            var dto = await _repository.CreateAsync(episode);

            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        // PUT api/episodes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EpisodeCreateUpdateDTO episode)
        {
            var updated = await _repository.UpdateAsync(episode);

            if (updated)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/episodes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
