using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp5_2022_agussarroyoo.Models;
using System.ComponentModel.DataAnnotations;

namespace tl2_tp5_2022_agussarroyoo.ViewModels
{
    public class PedidoViewModel
    {
        public int ID { get; set; }
        public string  ?obs { get; set; }
        
        [Required(ErrorMessage = "Debe asignar un cadete")]
        public int idCadete { get; set; }
        
        [Required(ErrorMessage = "Debe asignar un cliente")]
        public int idCliente { get; set; }
        public Estado estado { get; set; }
    }
}