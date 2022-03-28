namespace Swagger_Api_and_RESTful.Repository
{
    public class User_Repository : IUser_Repository
    {
        private readonly DbInteractor _context;
        public User_Repository(DbInteractor context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
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

        public async Task<User> GetUserAsync(string id)
        {
            var user = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> PostUserAsync(User_Request_Model user)
        {
            var dbUser = new User()
            {
                UserId = Guid.NewGuid().ToString(),
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                GroupId = user.GroupId,
                CreatedDate = DateTime.UtcNow
            };
            _context.Users.Add(dbUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return dbUser;
        }

        public async Task<User> PutUserAsync(string id, User_Request_Model user)
        {
            var userUpd = await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (userUpd == null) return null;
            userUpd.Name = user.Name;
            userUpd.Email = user.Email;
            userUpd.Password = user.Password;
            userUpd.UpdatedDate = DateTime.UtcNow;

            _context.Users.Update(userUpd);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return userUpd;
        }
    }
}
