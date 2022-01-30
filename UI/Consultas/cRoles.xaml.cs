using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Tarea_2.BLL;
using Tarea_2.Entidades;


namespace Tarea_2.UI.Consultas
{
    public partial class cRoles : Window
    {
        public cRoles()
        {
            InitializeComponent();
        }

        private void btnConsultar(object sender, RoutedEventArgs e)
        {
            var listado = new List<Roles>();
        
            if (CriterioTextBox.Text.Trim().Length > 0)
            {  
                if (System.Text.RegularExpressions.Regex.IsMatch(CriterioTextBox.Text, "[^0-9]"))
                {
                    listado = RolesBLL.GetLista(e => e.Descripcion == CriterioTextBox.Text);

                }else{          
                    listado = RolesBLL.GetLista(e => e.RolId == Convert.ToInt32(CriterioTextBox.Text));
                } 
            }
            else
            {
                listado = RolesBLL.GetLista(c => true);
            }

            if (DesdeDataPicker.SelectedDate != null)
                listado = RolesBLL.GetLista(c => c.FechaCreacion >= DesdeDataPicker.SelectedDate);
                        
            if (HastaDatePicker.SelectedDate != null)
                listado = RolesBLL.GetLista(c => c.FechaCreacion.Date <= HastaDatePicker.SelectedDate);
                
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;    
        }
    }
}