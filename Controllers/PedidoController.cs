using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tl2_tp5_2022_agussarroyoo.Models;
using tl2_tp5_2022_agussarroyoo.ViewModels;
using AutoMapper;

namespace tl2_tp5_2022_agussarroyoo.Controllers
{
    [Route("[controller]/[action]")]
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IMapper _mapper;
        public static ICollection<Pedido > pedidos = new List<Pedido>();
        public static ICollection<PedidoViewModel> _pedidosViewModel = new List<PedidoViewModel>();
        

        public PedidoController(ILogger<PedidoController> logger, IMapper mapper)
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

        [HttpGet("Alta")]
        public IActionResult Alta() {
            return View(new PedidoViewModel());
        }
         [HttpGet("Edit")]
        //Recibe la accion del boton Editar de la vista Listar y redirecciona a la vista Editar
        public IActionResult Edit(int Id) {
            return RedirectToAction("Editar", BuscarPorId(Id));
        }
        [HttpGet("Editar")]

        public IActionResult Editar(int Id) {
            PedidoViewModel pedido = _mapper.Map<PedidoViewModel>(BuscarPorId(Id));
            return View(pedido);
        }

        [HttpGet("Baja")]
        public IActionResult Baja(int Id) {
            try
            {
                pedidos.Remove(BuscarPorId(Id));
                _pedidosViewModel = _mapper.Map<List<PedidoViewModel>>(pedidos);

                return View("Listar",_pedidosViewModel);
            }
            catch (System.Exception)
            {
                
                return View("Index");
            }
            
        }

        [HttpPost("Alta")]
        [ValidateAntiForgeryToken]

        public IActionResult Alta(string obs, int idCliente, int idCadete) {
            Pedido nuevo = new Pedido(obs,idCliente,idCadete);
            pedidos.Add(nuevo);
            _pedidosViewModel = _mapper.Map<List<PedidoViewModel>>(pedidos);

            return View("Listar",_pedidosViewModel); 
        }
        [HttpPost("Editar")]
        public IActionResult Editar(int id,string obs, int idCliente, int idCadete) {
            try
            {
                Pedido actualizado = BuscarPorId(id);
                actualizado.Obs = obs;
                actualizado.IdCadete = idCadete;
                actualizado.IdCliente = idCliente;

                _pedidosViewModel = _mapper.Map<List<PedidoViewModel>>(pedidos);

                return RedirectToAction("Listar");

            }
            catch (System.Exception)
            {
                
                return View("Index");
            }

        }
        public IActionResult Listar() {
            return View(_pedidosViewModel);
        }

        public Pedido BuscarPorId(int id) {
            return pedidos.FirstOrDefault(x => x.id == id);
        }
    }
} 