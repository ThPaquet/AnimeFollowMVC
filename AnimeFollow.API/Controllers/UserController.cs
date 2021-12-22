using AnimeFollowMVC.Services.DepotInterfaces;
using AnimeFollowMVC.Services.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimeFollowMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDepotUsers _depot;

        public UserController(IDepotUsers p_depot)
        {
            this._depot = p_depot;
        }
        // GET: api/<UserController>
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(this._depot.GetUsers());
        }

        // GET api/<UserController>/5
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet("{p_id}")]
        public ActionResult<User> Get(int p_id)
        {
            User? user = _depot.GetUser(p_id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/<UserController>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] User p_user)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            this._depot.CreateUser(p_user);
            return Created(nameof(this.Post), p_user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{p_id}")]
        public ActionResult Put(int p_id, [FromBody] User p_user)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest();
            }

            User? user = this._depot.GetUser(p_id);

            if (user is null)
            {
                return NotFound();
            }

            user.Id = p_user.Id;
            this._depot.UpdateUser(user);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{p_id}")]
        public ActionResult Delete(int p_id)
        {
            User? user = this._depot.GetUser(p_id);

            if (user is null)
            {
                return NotFound();
            }

            this._depot.DeleteUser(p_id);
            return NoContent();
        }
    }
}
