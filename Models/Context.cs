using Microsoft.EntityFrameworkCore;
 
namespace NinjaInfoCards.Models
{
    public class Context : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public Context(DbContextOptions options) : base(options) 
        {}

        public DbSet<Ninja> Ninjas {get;set;}

    }
}