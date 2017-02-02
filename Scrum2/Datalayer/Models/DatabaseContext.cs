using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datalayer.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<BlogEntryComment> BlogEntryComments { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Invite> Invites { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
