using NPOI.OpenXmlFormats.Dml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Cadeteria
{
    public class Cadeteria
    {
        private string nombre;
        private int telefono;
        private List<Cadete> cadetes;
        private List<Pedido> pedidos;

        public Cadeteria() { }
        public Cadeteria(string nombre, int telefono, List<Cadete> cadetes)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Cadetes = cadetes;
        }

        public Cadeteria(string nombre, int telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Cadetes = new List<Cadete>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }

        /*private void CrearPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, int telefonoCliente, string datosReferenciaDireccionCliente, int idCadete) 
        {
            var cadete = BuscarCadetePorID(idCadete);
            Pedido pedido = new Pedido(numeroPedido, observacionPedido, nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
            cadete.AgregarPedido(pedido);
        }

        public void AsignarPedido(nroPedido,IdCadete)
        {
        }

        /*public void ReasignarPedido(int idOrigen,int idDestino,int numeroPedido) 
        {
            var origen = BuscarCadetePorID(idOrigen);
            var destino = BuscarCadetePorID(idDestino);
            var pedidoARemover = origen.ObtenerPedidoPorNumero(numeroPedido);
            origen.EliminarPedido(pedidoARemover.Numero);
            destino.AgregarPedido(pedidoARemover);  
        }*/
        public double CobrarJornalVersionJoin(int idCadete)
        {
            var resultado = Cadetes
                .Where(cadete => cadete.Id == idCadete) // Filtra por el idCadete proporcionado
                .Join(Pedidos,
                    cadete => cadete.Id,
                    pedido => pedido.Cadete.Id,
                    (cadete, pedido) => pedido) // Proyecta solo los pedidos relacionados con el cadete
                .ToList(); // Convierte el resultado en una lista

            int cantidadResultados = resultado.Count();
            double jornal = cantidadResultados * 500;
            return jornal;
        }

        public double CobrarJornal(int idCadete)
        {
            Cadete cadete = BuscarCadetePorID(idCadete); // Busca el cadete por su ID

            if (cadete != null) // Verifica si se encontró un cadete con el ID especificado
            {
                int cantidadPedidos = Pedidos
                    .Count(pedido => pedido.Cadete.Id == idCadete); // Cuenta los pedidos del cadete específico

                double jornal = cantidadPedidos * 500;
                return jornal;
            }
            else
            {
                return -1;
            }
        }


        private Cadete BuscarCadetePorID(int idCadete) 
        {
            var cadete  = this.Cadetes.FirstOrDefault(cadete => cadete.Id == idCadete);
            return cadete;
        }

        private Pedido BuscarPedidoPorNro(int nroPedido)
        {
            var cadete = this.Pedidos.FirstOrDefault(pedido => pedido.Numero == nroPedido);
            return cadete;
        }

        /*public string GenerarInforme() 
        {
            string intro = $"Cadeteria: {this.Nombre} | Teléfono: {this.Telefono}";
            string cuerpo = "";
            foreach (var cad in this.Cadetes)
            {
                cuerpo = cuerpo + cad.InformeCadete();
            }
            return intro + cuerpo;
        }*/


        /*public void BorrarPedido(int idCadete,int nroPedido) 
        {
            var cadete = BuscarCadetePorID(idCadete);
            cadete.EliminarPedido(nroPedido);
        }*/
    }
}
