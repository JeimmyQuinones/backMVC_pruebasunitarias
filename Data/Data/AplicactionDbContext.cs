using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AplicactionDbContext: DbContext
    {
        public AplicactionDbContext():base("mvcPrueba")
        {

        }
        public DbSet<Usuario>Usuario { get; set; }
        public DbSet<Proceso> Proceso { get; set; }
    }
}
