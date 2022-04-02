namespace Swagger_Api_and_RESTful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroup_Repository _repository;

        public GroupsController(IGroup_Repository repository)
        {
            _repository = repository;
        }

        //GET: api/Groups
        [HttpGet]
        public ActionResult<IEnumerable<Group_Response_Model>> GetGroups()
        {
           return _repository.GetGroupsAsync().Result.Select(x=>x.GroupResponse()).ToList();
        }

        //GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group_Response_Model>> GetGroup(string id)
        {
            var groupResponse = await _repository.GetGroupAsync(id);
            if (groupResponse == null) return NotFound();
            return Ok(groupResponse.GroupResponse());
        }
        // PUT: api/Groups/5
        [HttpPut]
        public async Task<IActionResult> PutGroup(string id, Group_Request_Model group)
        {
            var response = await _repository.PutGroupAsync(id, group);
            if (response == null) return BadRequest();
            return Ok();
        }
        //POST: api/Groups
        [HttpPost]
        public async Task<ActionResult<Group_Response_Model>> PostGroup(Group_Request_Model group)
        {
            var response = await _repository.PostGroupAsync(group);
            if (response == null) return BadRequest();
            return CreatedAtAction("GetGroup", new { id = response.GroupId }, response.GroupResponse());
        }
        // DELETE: api/Groups/5
        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(string id)
        {
            var response = await _repository.DeleteGroupAsync(id);
            if (!response) return BadRequest();
            return Ok();
        }


    }
}
