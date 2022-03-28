namespace Swagger_Api_and_RESTful.Models
{
    public class Group : DataTrail
    {
        [Key]
        [Required]
        [StringLength(36)]
        public string GroupId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
    public class DataTrail
    {
        [MaxLength(36)]
        public string CreatedBy { get; set; }
        [MaxLength(36)]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
