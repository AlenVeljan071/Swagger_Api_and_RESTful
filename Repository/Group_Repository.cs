namespace Swagger_Api_and_RESTful.Repository
{
    public class Group_Repository : IGroup_Repository
    {

        private readonly DbInteractor _context;
        public Group_Repository(DbInteractor context)
        {
            _context = context;
        }
        public async Task<bool> DeleteGroupAsync(string id)
        {
            var group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(group);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupAsync(string id)
        {
            var group = await _context.Groups.Where(x => x.GroupId == id).FirstOrDefaultAsync();
            return group;
        }

        public async Task<Group> PostGroupAsync(Group_Request_Model song)
        {
            var dbGroup = new Group()
            {
                GroupId = Guid.NewGuid().ToString(),
                Name = song.Name,
                CreatedDate = DateTime.UtcNow
            };
            _context.Groups.Add(dbGroup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return dbGroup;
        }

        public async Task<Group> PutGroupAsync(string id, Group_Request_Model group)
        {
            var groupUpd = await _context.Groups.Where(x => x.GroupId == id).FirstOrDefaultAsync();
            if (group == null) return null;
            groupUpd.Name = group.Name;
            groupUpd.UpdatedDate = DateTime.UtcNow;
            _context.Groups.Update(groupUpd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return groupUpd;
        }
    }
}
