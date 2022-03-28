namespace Swagger_Api_and_RESTful.Request_Model
{
    public class User_Request_Model
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(36)]
        public string GroupId { get; set; }
    }
}
