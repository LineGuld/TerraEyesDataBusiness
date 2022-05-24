using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TerraEyes_BusinessServer.UserRepository
{
    public class Repository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<string> ConnectionIds { get; set; }
        public DbSet<Groups> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Users.db");
        }
    }

    public class User
    {
        [Required]
        public string UserId { get; set; }
        public ICollection<string> ConnectionIds { get; set; }
        public virtual ICollection<Groups> Groups { get; set; }
    }

    public class Groups
    {
        [Key]
        public int Id { get; set; }
        public string UserType { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}