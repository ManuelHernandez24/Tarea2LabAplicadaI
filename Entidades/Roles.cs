using System.Windows.Input;
using System.ComponentModel.DataAnnotations;

namespace Tarea_2_Registro
{
    public partial class MainWindow
    {
        //Clase Roles

        public class Roles{
            [Key]
            public int RolId {get; set;}

            public string? FechaCreacion {get; set;}

            public string? Descripcion {get; set;}

            public Roles(int rolId, string? fechaCreacion, string? descripcion){
                this.RolId = rolId;
                this.FechaCreacion = fechaCreacion;
                this.Descripcion = descripcion;
            }
        }

    }


 
    
}
