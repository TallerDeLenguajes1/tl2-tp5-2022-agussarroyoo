using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tl2_tp5_2022_agussarroyoo.Models;
using tl2_tp5_2022_agussarroyoo.ViewModels;
using AutoMapper;


namespace tl2_tp5_2022_agussarroyoo
{
    public class MapeoCadete: Profile
    {
        public MapeoCadete() {
          CreateMap<Cadete, CadeteViewModel>().ReverseMap();

        }

    }
}