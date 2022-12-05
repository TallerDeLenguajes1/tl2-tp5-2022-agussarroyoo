using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp5_2022_agussarroyoo.Models
{
    public class Pedido
    {
        static private  int nro=0;
        private int ID;
        private string obs;
        private int idCadete;
        private int idCliente ;
        private Estado estado;

        public Pedido (string obs,int idClient,int idCadete) {
            nro++;
            this.ID = nro;
            this.obs = obs;
            this.estado = Estado.Enviado;
            this.idCliente = idClient;
            this.idCadete = idCadete;
        }

        public void listarInfo() {
            System.Console.WriteLine("nro: " + this.ID);
            System.Console.WriteLine("estado: " + this.estado);
        }

        
        public int id {
            get {
                return this.ID;
            }set{
                this.ID = value;
            }
        }
        public string Obs {
            get{
                return obs;
            } set {
                this.obs = value;
            }
        }
        public int IdCliente {
            get {
                return this.idCliente;
            } set{
                this.idCliente = value;
            }
        }
        public int IdCadete {
            get {
                return this.idCadete;
            } set {
                this.idCadete = value;
            }
        }
        public Estado Estado {
            get {
                return estado;
            } set {
                estado = value;
            }
        }
    
    }
}