namespace Swagger_Api_and_RESTful.Extensions
{
    public static class Extensions
    {
        public static Group_Response_Model GroupResponse(this Group group)
        {
            return new Group_Response_Model()
            {
                GroupId = group.GroupId,
                Name = group.Name
            };
        }

        public static User_Response_Model UserResponse(this User user)
        {
            return new User_Response_Model()
            {
                UserId = user.UserId,
                Email = user.Email,
                GroupId = user.GroupId,
                Name = user.Name,
                Password = user.Password
            };
        }
    }
}
