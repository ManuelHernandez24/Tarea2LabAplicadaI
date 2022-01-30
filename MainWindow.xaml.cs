using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea_2_Registro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBoxFechaCreacion.Text = DateTime.Now.ToString("dd-MM-yyyy"); 
            RefrescarConsultaRoles();
            
        }

        private void AgregarButton_Click (object sender, RoutedEventArgs e){
            AgregarRol(TextBoxDescripcion.Text);
            DataGridConsultaRoles.ItemsSource = RolesBLL.GetLista();
        }

        private void EliminarButton_Click (object sender, RoutedEventArgs e){
            if(RolesBLL.Eliminar(int.Parse(TextBoxId.Text))){
                MessageBox.Show("No fue posible eliminar");
            }else{        
                MessageBox.Show("Se eliminó con exito");
            }
            DataGridConsultaRoles.ItemsSource = RolesBLL.GetLista();
        }

        private void ModificarButton_Click (object sender, RoutedEventArgs e){
            ModificarRol(TextBoxId.Text, TextBoxDescripcion.Text);
            DataGridConsultaRoles.ItemsSource = RolesBLL.GetLista();
        }

        public static bool ExisteDescripcion(string descripcion){
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.Descripcion == descripcion);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

           public static bool ExisteId(int id){
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Roles.Any(e => e.RolId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        void AgregarRol(string a){
            //Se pasa lo que el usuario ingresa por parametros.
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            Roles roles = new Roles(0,fecha,a);
            if (!ExisteDescripcion(roles.Descripcion)){
                RolesBLL.Insertar(roles);
                MessageBox.Show("Se guardó con éxito");
            }else{
                MessageBox.Show($"Ya existe un rol {TextBoxDescripcion.Text}");
            }
            
        }
            void ModificarRol(string a, string b){
            //Se pasa lo que el usuario ingresa por parametros.
            Roles roles = new Roles(int.Parse(a), DateTime.Now.ToString("dd-MM-yyyy") ,b);
            if (!ExisteId(roles.RolId)){
                MessageBox.Show($"No existe un usuario con el ID:{TextBoxId.Text}");

            }else{
                RolesBLL.Modificar(roles);
                MessageBox.Show($"Se modificó con éxito el rol con ID: {TextBoxId.Text}");
            }
        }

        void RefrescarConsultaRoles(){
            DataGridConsultaRoles.ItemsSource = RolesBLL.GetLista();
        }

    }


 
    
}
