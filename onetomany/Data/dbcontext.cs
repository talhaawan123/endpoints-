using Microsoft.EntityFrameworkCore;
using onetomany.Models;

namespace onetomany.Data

{
    public class dbcontext :DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options):base(options)
        { }
        public DbSet<Person> People {  get; set; }
    }
}
