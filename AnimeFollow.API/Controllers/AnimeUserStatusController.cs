using AnimeFollowMVC.Services.DepotInterfaces;
using AnimeFollowMVC.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeFollowMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimeUserStatusController : ControllerBase
    {
        private IDepotAnimeUserStatus _depot;
        public AnimeUserStatusController(IDepotAnimeUserStatus p_depot)
        {
            this._depot = p_depot;
        }

        // GET: api/<AnimeUserStatus>
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<IEnumerable<AnimeUserStatusController>> Get()
        {
            return Ok(this._depot.GetAnimeUserStatuses());
        }

        // GET api/<AnimeUserStatus>/5
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{p_id}")]
        public ActionResult<AnimeUserStatus> Get(int p_id)
        {
            AnimeUserStatus? animeUserStatus = this._depot.GetAnimeUserStatus(p_id);

            if (animeUserStatus == null)
            {
                return NotFound();
            }

            return Ok(animeUserStatus);
        }

        // POST api/<AnimeUserStatus>
        [ProducesResponseType(203)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] AnimeUserStatus p_animeUserStatus)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            this._depot.CreateAnimeUserStatus(p_animeUserStatus);
            return Created(nameof(this.Post), p_animeUserStatus);
        }

        // PUT api/<AnimeUserStatus>/5
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [HttpPut("{p_id}")]
        public ActionResult Put(int p_id, [FromBody] AnimeUserStatus p_animeUserStatus)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            AnimeUserStatus? animeUserStatus = this._depot.GetAnimeUserStatus(p_id); 

            if (animeUserStatus is null)
            {
                return NotFound();
            }

            p_animeUserStatus.Id = p_id;
            this._depot.UpdateAnimeUserStatus(p_animeUserStatus);
            return NoContent();
        }

        // DELETE api/<AnimeUserStatus>/5
        [HttpDelete("{p_id}")]
        public ActionResult Delete(int p_id)
        {
            AnimeUserStatus? animeUserStatus = this._depot.GetAnimeUserStatus(p_id);

            if (animeUserStatus is null)
            {
                return NotFound();
            }

            this._depot.DeleteAnimeUserStatus(p_id);
            return NoContent();
        }
    }
}
