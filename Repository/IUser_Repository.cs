namespace Swagger_Api_and_RESTful.Repository
{
    public interface IUser_Repository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(string id);
        Task<User> PostUserAsync(User_Request_Model user);
        Task<User> PutUserAsync(string id, User_Request_Model user);
        Task<bool> DeleteUserAsync(string id);
    }
}