using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tl2_tp5_2022_agussarroyoo.Models;
using tl2_tp5_2022_agussarroyoo.ViewModels;

namespace tl2_tp5_2022_agussarroyoo.Mappers
{
    public class MapeoPedido:Profile
    {
        public MapeoPedido() {
            CreateMap<Pedido,PedidoViewModel>().ReverseMap();

        }
    }
}