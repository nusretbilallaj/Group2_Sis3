using Group2_Sis3.Models;
using Microsoft.EntityFrameworkCore;

namespace Group2_Sis3.Data
{
    public class Konteksti:DbContext
    {
        public Konteksti(DbContextOptions<Konteksti> opcionet):base(opcionet)
        {
            
        }

        public DbSet<Studenti> Studentet { get; set; }
        public DbSet<Komuna> Komunat { get; set; }
        public DbSet<Profesori> Profesoret { get; set; }

    }
}
