namespace Swagger_Api_and_RESTful.Repository
{
    public interface IGroup_Repository
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<Group> GetGroupAsync(string id);
        Task<Group> PostGroupAsync(Group_Request_Model song);
        Task<Group> PutGroupAsync(string id, Group_Request_Model group);
        Task<bool> DeleteGroupAsync(string id);
    }
}