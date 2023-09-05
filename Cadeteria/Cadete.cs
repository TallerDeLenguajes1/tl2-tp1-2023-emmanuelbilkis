using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _Cadeteria
{
    public class Cadete
    {
        private int id;
        private string nombre;
        private string direccion;
        private int telefono;
        private List<Pedido> pedidos;
        private const double valorPedido=500;

        public Cadete(int id, string nombre, string direccion, int telefono, List<Pedido> pedidos)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Pedidos = pedidos;
        }

        public Cadete(int id, string nombre, string direccion, int telefono) 
        {
            this.id = id;
            this.nombre = nombre;   
            this.direccion = direccion;
            this.telefono = telefono;
            this.pedidos = new List<Pedido>();
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        public double JornalACobrar() 
        {
            double cobroTotal;
            int cantidadPedidos = this.Pedidos.Count(pedido => pedido.Estado);
            cobroTotal = valorPedido * cantidadPedidos;
            return cobroTotal;
        }

        public void AgregarPedido(Pedido pedido) 
        {
            this.Pedidos.Add(pedido);   
        }

        public void EliminarPedido(int numeroPedido)
        {
            var elementoAEliminar = ObtenerPedidoPorNumero(numeroPedido);
            if (this.Pedidos.Remove(elementoAEliminar))
            {
                Console.WriteLine("Se eliminó con éxito");
            }
            else
            {
                Console.WriteLine("No se pudo eliminar");
            }
        }

        public Pedido ObtenerPedidoPorNumero(int numero) 
        {
            var pedido = this.Pedidos.FirstOrDefault(pedido => pedido.Numero==numero);
            return pedido;
        } 

        public string InformeCadete() 
        {
            string informe = $" - Informe Cadete {this.Nombre} - ID:{this.Id} - ";
            foreach (var pedidoX in this.Pedidos)
            {
                informe = informe + "-" + pedidoX.Observacion + "-" + pedidoX.Numero + "-" + pedidoX.Estado + "-" + " | Datos Cliente" + pedidoX.VerDatosDelCliente();
            }

            return informe;
        }
    }
}
