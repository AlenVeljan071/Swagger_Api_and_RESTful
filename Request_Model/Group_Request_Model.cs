namespace Swagger_Api_and_RESTful.Request_Model
{
    public class Group_Request_Model
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
