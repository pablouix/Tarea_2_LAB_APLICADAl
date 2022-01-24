using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace Tarea_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Roles roles;
        public MainWindow()
        {
            InitializeComponent();

            roles = new Roles();
            this.DataContext = roles;

            var lista = RolesBLL.GetLista();
            DatosDataGrid.ItemsSource = lista;

            RolFechaCreacionTextBox.IsEnabled = false;
            RolFechaCreacionTextBox.Text = Convert.ToString(DateTime.Now.Day)+"/"+Convert.ToString(DateTime.Now.Month)+"/"+Convert.ToString(DateTime.Now.Year); 
        }
       

        private void btnGuardar(object sender, RoutedEventArgs e){
            if(String.IsNullOrWhiteSpace(RolIDTextBox.Text) || string.IsNullOrEmpty(RolIDTextBox.Text))
            {
                MessageBox.Show("El id del rol esta vacia...");
            }
            else if(String.IsNullOrWhiteSpace(RolDescripcionTextBox.Text) || string.IsNullOrEmpty(RolDescripcionTextBox.Text))
            {
                MessageBox.Show("La descripcion del rol esta vacia...");
            }
            else
            {
                var encontrado = RolesBLL.ExisteRolDescripcion(RolDescripcionTextBox.Text);
               

                if(encontrado != true)
                {
                    Roles roles = new Roles(Convert.ToInt32(RolIDTextBox.Text), RolDescripcionTextBox.Text);
                    var paso = RolesBLL.Guardar(roles); 
                    if(paso)
                    {
                        MessageBox.Show("Rol creado con exito...");

                        var lista = RolesBLL.GetLista();
                        DatosDataGrid.ItemsSource = lista;

                        RolIDTextBox.Text = "";
                    
                        RolDescripcionTextBox.Text = "";
                    }
                    else
                        MessageBox.Show("No se pudo crear el rol...");

                }
                else
                {
                    MessageBox.Show("Rol ya existe...");

                }
            }
        }

        public void btnBuscar(object sender, RoutedEventArgs e){
            

            if(String.IsNullOrWhiteSpace(RolIDTextBox.Text) || string.IsNullOrEmpty(RolIDTextBox.Text)){
                
                MessageBox.Show("Id del rol esta vacio...");

            }
            else
            {
               
                var encontrado = RolesBLL.Buscar(Convert.ToInt16(RolIDTextBox.Text));

                if(encontrado != null)
                {
                   
                    this.roles = encontrado;
                    this.DataContext = this.roles;

                    RolIDTextBox.Text = Convert.ToString(roles.RolId);
                    RolFechaCreacionTextBox.Text = Convert.ToString(DateTime.Now.Day)+"/"+Convert.ToString(DateTime.Now.Month)+"/"+Convert.ToString(DateTime.Now.Year);
                    RolDescripcionTextBox.Text = roles.Descripcion;
                

                    MessageBox.Show("Encontrado...");
                }else{
                    MessageBox.Show("No Existe...");
                }

            }
           
        }

        public void btnEliminar(object sender, RoutedEventArgs e)
        {
            if(RolesBLL.Eliminar(Convert.ToInt16(RolIDTextBox.Text)))
            {
                var lista = RolesBLL.GetLista();
                DatosDataGrid.ItemsSource = lista;
                MessageBox.Show("Rol eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar Rol !", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        public void btnEditar(object sender, RoutedEventArgs e)
        {

            if(String.IsNullOrWhiteSpace(RolIDTextBox.Text) || string.IsNullOrEmpty(RolIDTextBox.Text))
            {
                MessageBox.Show("El id del rol esta vacia...");
            }
            else if(String.IsNullOrWhiteSpace(RolDescripcionTextBox.Text) || string.IsNullOrEmpty(RolDescripcionTextBox.Text))
            {
                MessageBox.Show("La descripcion del rol esta vacia...");
            }
            else
            {
                var encontrado = RolesBLL.ExisteRolDescripcion(RolDescripcionTextBox.Text);

                if(encontrado != true){

                    Roles roles = new Roles(Convert.ToInt32(RolIDTextBox.Text), RolDescripcionTextBox.Text);
                    var paso = RolesBLL.Modificar(roles); 
                    if(paso)
                    {
                        MessageBox.Show("Rol Modificado con exito...");

                        var lista = RolesBLL.GetLista();
                        DatosDataGrid.ItemsSource = lista;

                        RolIDTextBox.Text = "";
                    
                        RolDescripcionTextBox.Text = "";
                    }
                    else
                        MessageBox.Show("No se pudo modificar el rol...");

                }
                else
                {
                    MessageBox.Show("Rol ya existe...");

                }
            }
        }

        public void btnNuevo(object sender, RoutedEventArgs e)
        {
            RolIDTextBox.Text = "";         
            RolDescripcionTextBox.Text = "";
        }
    }
}
