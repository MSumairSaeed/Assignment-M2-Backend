using System.Reflection.Metadata;
using crud_assignment_m2.Schemas;
using Microsoft.EntityFrameworkCore;
namespace crud_assignment_m2.schemas
{
    public class PostDBContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        //public PostDBContext() { }

        public PostDBContext(DbContextOptions options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer("Server=DESKTOP-JOJR9QA\SQLEXPRESS;Database=NomBD;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=sa;Password=yourStrong(!)Password;Integrated Security=False");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localhost)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;User ID=sa;Password=yourStrong(!)Password;");
        //}
    }
}