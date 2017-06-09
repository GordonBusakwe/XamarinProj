
using Microsoft.EntityFrameworkCore;
using Webservice.Models;

namespace Webservice
{
    public class DatabaseContext:DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :base(options)
        {
        }
        public  DbSet<Rental> Rentals { get; set; }
  
        public  DbSet<User> Users { get; set; }
        public  DbSet<Admin> Admin { get; set; }
        public  DbSet<Properties> Property { get; set; }

        public  DbSet<Developments> Development { get; set; }

        public  DbSet<AdviceSecs> Advices { get; set; }
    }
}
