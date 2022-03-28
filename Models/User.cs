namespace Swagger_Api_and_RESTful.Models
{
    public class User : DataTrail
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string UserId { get; set; }
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
