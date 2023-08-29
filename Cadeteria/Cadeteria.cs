using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private int telefono;
        private List<Cadete> cadetes;

        public Cadeteria(string nombre, int telefono, List<Cadete> cadetes)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Cadetes = cadetes;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }

        public void GenerarPedido(Pedido pedido,string nombre) 
        {
            var cadete = from cade in this.cadetes
                         where cade.Nombre == nombre select cade;
            cadete.FirstOrDefault().AgregarPedido(pedido);          
        }

        public void ReasignarPedido(Cadete origen,Cadete destino,int numeroPedido) 
        {
            var pedidoARemover = origen.ObtenerPedidoPorNumero(numeroPedido);
            origen.EliminarPedido(pedidoARemover.Numero);
            destino.AgregarPedido(pedidoARemover); // llamaria a estos metodos asi o tendria que agregar desde cadeteria un metodo borrar pedido?
            // aca usaria el GenerarPedido? o directamente como lo hice? 
        }
    }
}
