using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tl2_tp5_2022_agussarroyoo.ViewModels
{
    public class CadeteViewModel
    {
        private int id;
        private string ?nombre;
        private string ?direc;
        
        private long telefono;
        
       
        public int ID {
            get {
                return this.id;
            } set{
                this.id =value;
            }
        }
        [Required(ErrorMessage="Debe ingresar un nombre")]
        public string? Nombre {
            get {
                return this.nombre;
            }set{
                this.nombre = value;
            }
        }
        [Required(ErrorMessage="Debe ingresar una direccion")]

        public string? Direccion {
            get{
                return this.direc;
            }set{
                this.direc = value;
            }
        }
        [Required(ErrorMessage="Debe ingresar un telefono")]

        public long Telefono {
            get{
                return this.telefono;
            } set{
                this.telefono = value;
            }
        }
    }
}