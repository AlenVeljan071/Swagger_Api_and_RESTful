namespace Swagger_Api_and_RESTful.Data
{
    public class DbInteractor : DbContext
    {
        public DbInteractor(DbContextOptions<DbInteractor> options) : base(options)
        {

        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
