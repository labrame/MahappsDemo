using System.Data.Entity;

namespace MahappsDemo.Repository
{
    public class TestContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Result> Results { get; set; }
    }
}
