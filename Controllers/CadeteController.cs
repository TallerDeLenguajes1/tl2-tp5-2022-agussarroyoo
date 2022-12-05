using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tl2_tp5_2022_agussarroyoo.Models;
using tl2_tp5_2022_agussarroyoo.ViewModels;

namespace tl2_tp5_2022_agussarroyoo.Controllers
{
    [Route("[controller]/[action]")]
    public class CadeteController : Controller
    {
        private readonly ILogger<Cadete> _logger;
        private readonly IMapper _mapper;
        public static ICollection<Cadete> cadetes = new List<Cadete>();
        public static ICollection<CadeteViewModel> cadetesViewModel = new List<CadeteViewModel>();

        public CadeteController(ILogger<Cadete> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public IActionResult Alta() {
            return View(new CadeteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alta(string nombre, string direc, long telefono) {
            Cadete cadete = new Cadete( nombre,  direc,  telefono);
            cadetes.Add(cadete);
            cadetesViewModel = _mapper.Map<List<CadeteViewModel>>(cadetes);

            return View("Listar", cadetesViewModel);
        }

        [HttpGet]
        public IActionResult Baja(int Id) {
            try
            {
              cadetes.Remove(BuscarPorId(Id));
              cadetesViewModel = _mapper.Map<List<CadeteViewModel>>(cadetes);

              return View("Listar", cadetesViewModel);

            }
            catch (System.Exception)
            {
                
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult Edit(int Id) {
            return RedirectToAction("Editar",BuscarPorId(Id));
        }

        public IActionResult Editar(int Id) {
            CadeteViewModel cadete = _mapper.Map<CadeteViewModel>(BuscarPorId(Id));
            return View(cadete);
        }

        [HttpPost] 
        public IActionResult Editar(int id,string nombre, string direc, long telefono) {
            try
            {
                Cadete cadete = BuscarPorId(id);
                cadete.Nombre = nombre;
                cadete.Direccion = direc;
                cadete.Telefono = telefono;
                cadetesViewModel = _mapper.Map<List<CadeteViewModel>>(cadetes);

                return RedirectToAction("Listar");
            }
            catch (System.Exception)
            {
                
                return RedirectToAction("Index");
            }
            

        }
        public Cadete BuscarPorId(int id) {
            return cadetes.FirstOrDefault(x => x.ID == id);
        }

        public IActionResult Listar() {
            return View(cadetesViewModel);
        }

    }
}