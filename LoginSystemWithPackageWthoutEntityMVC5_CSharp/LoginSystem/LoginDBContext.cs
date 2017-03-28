using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginSystem
{
    public class LoginDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
