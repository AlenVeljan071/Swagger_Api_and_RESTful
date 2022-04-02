namespace Swagger_Api_and_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser_Repository _repository;

        public UsersController(IUser_Repository repository)
        {
            _repository = repository;
        }

        //GET: api/Groups
        [HttpGet]
        public ActionResult<IEnumerable<User_Response_Model>> GetUsers()
        {
           return _repository.GetUsersAsync().Result.Select(x=>x.UserResponse()).ToList();
        }

        //GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User_Response_Model>> GetUser(string id)
        {
            var userResponse = await _repository.GetUserAsync(id);
            if (userResponse == null) return NotFound();
            return Ok(userResponse.UserResponse());
        }
        // PUT: api/Groups/5
        [HttpPut]
        public async Task<IActionResult> PutUser(string id, User_Request_Model user)
        {
            var response = await _repository.PutUserAsync(id, user);
            if (response == null) return BadRequest();
            return Ok();
        }
        //POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<User_Response_Model>> PostUser(User_Request_Model user)
        {
            var response = await _repository.PostUserAsync(user);
            if (response == null) return BadRequest();
            return CreatedAtAction("GetUser", new { id = response.UserId }, response.UserResponse());
        }
        // DELETE: api/Groups/5
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var response = await _repository.DeleteUserAsync(id);
            if (!response) return BadRequest();
            return Ok();
        }
    }
}
