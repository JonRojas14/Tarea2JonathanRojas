using Microsoft.EntityFrameworkCore;
using Tarea2JonathanRojas.Models;

namespace Tarea2JonathanRojas.Data
  
{
    public class ApplicationDbContext : DbContext // hereda de la clase DBContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Constructor de la clase
        }


        //Instacias de los modelos
        public DbSet<Edificio> Edificio { get; set; }
        public DbSet<Servicio> Servicio { get; set; }

        public DbSet<ServPorEdif> Spe { get; set; }
    }
}
