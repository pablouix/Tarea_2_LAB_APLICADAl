
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea_2
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public string? Descripcion { get; set; }
        public Roles(int rolid, string? descripcion){
            this.Descripcion = descripcion;
            this.RolId = rolid;
        }

        public Roles()
        {
        }
    }
}