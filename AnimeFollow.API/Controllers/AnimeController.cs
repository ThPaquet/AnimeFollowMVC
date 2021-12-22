using AnimeFollowMVC.Services.DepotInterfaces;
using AnimeFollowMVC.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeFollowMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeController : ControllerBase
    {
        private IDepotAnime _depot;

        public AnimeController(IDepotAnime p_depot)
        {
            this._depot = p_depot;
        }
        // GET: api/<AnimeController>
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<IEnumerable<Anime>> Get()
        {
            return Ok(this._depot.GetAnimes());
        }

        // GET api/<AnimeController>/5
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{p_id}")]
        public ActionResult<Anime?> Get(int p_id)
        {
            Anime? anime = this._depot.GetAnime(p_id);

            if (anime == null)
            {
                return NotFound();
            }

            return Ok(anime);
        }

        // POST api/<AnimeController>
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] Anime p_anime)
        {
            if (ModelState.IsValid)
            {
                this._depot.CreateAnime(p_anime);
                return Created(nameof(this.Post), p_anime);
            }

            else
            {
                return BadRequest();
            }
        }

        // PUT api/<AnimeController>/5
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{p_id}")]
        public ActionResult Put(int p_id, [FromBody] Anime p_anime)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            Anime? anime = this._depot.GetAnime(p_id);

            if (anime is null)
            {
                return NotFound();
            }

            p_anime.Id = p_id;
            this._depot.UpdateAnime(p_anime);
            return NoContent();
        }

        // DELETE api/<AnimeController>/5
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [HttpDelete("{p_id}")]
        public ActionResult Delete(int p_id)
        {
            Anime? anime = this._depot.GetAnime(p_id);

            if (anime is null)
            {
                return NotFound();
            }

            this._depot.DeleteAnime(p_id);
            return NoContent();
        }
    }
}
