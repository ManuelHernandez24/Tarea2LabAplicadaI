using Microsoft.EntityFrameworkCore;

namespace Tarea_2_Registro
{
    public partial class MainWindow
    {
        //Contexto de EntityFramework
        public class Contexto:DbContext{
            public DbSet<Roles>? Roles {get; set;}
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=Roles.db");
            }
        }

    }


 
    
}
