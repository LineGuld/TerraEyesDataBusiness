using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TerraEyes_BusinessServer.UserRepository
{
    public class UserRepository : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<UserGroups> Groups { get; set; }
    }

    public class User
    {
        [Key]
        public string UserId { get; set; }
        public ICollection<Connection> Connections { get; set; }
        public virtual ICollection<UserGroups> Groups { get; set; }
    }

    public class Connection
    {
        public string ConnectionId { get; set; }
        public string UserAgent { get; set; }
        public bool Connected { get; set; }
    }

    public class UserGroups
    {
        [Key]
        public string UserType { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}