using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        

        // The method to intract with the database
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}