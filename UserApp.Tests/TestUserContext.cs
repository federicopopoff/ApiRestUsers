using UserApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Tests
{
    public class TestUserContext : IUserContext
    {
        public TestUserContext()
        {
            this.Users = new TestUserDbSet();
        }

        public DbSet<User> Users { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(User item) { }
        public void Dispose() { }
    }
}
