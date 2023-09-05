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

        public void GenerarPedido(int numeroPedido, string observacionPedido, string nombreCliente, string direccionCliente, int telefonoCliente, string datosReferenciaDireccionCliente, int idCadete) 
        {
            var cadete = BuscarCadetePorID(idCadete);
            Pedido pedido = new Pedido(numeroPedido, observacionPedido, nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
            cadete.AgregarPedido(pedido);
        } 
        public void ReasignarPedido(int idOrigen,int idDestino,int numeroPedido) 
        {
            var origen = BuscarCadetePorID(idOrigen);
            var destino = BuscarCadetePorID(idDestino);
            var pedidoARemover = origen.ObtenerPedidoPorNumero(numeroPedido);
            origen.EliminarPedido(pedidoARemover.Numero);
            destino.AgregarPedido(pedidoARemover);  
        }
        
        private Cadete BuscarCadetePorID(int idCadete) 
        {
            var cadete  = this.Cadetes.FirstOrDefault(cadete => cadete.Id == idCadete);
            return cadete;
        }
       
        public string GenerarInforme() 
        {
            string intro = $"Cadeteria: {this.Nombre} | Teléfono: {this.Telefono}";
            string cuerpo = "";
            foreach (var cad in this.Cadetes)
            {
                cuerpo = cuerpo + cad.InformeCadete();
            }
            return intro + cuerpo;
        }

        public void BorrarPedido(int idCadete,int nroPedido) 
        {
            var cadete = BuscarCadetePorID(idCadete);
            cadete.EliminarPedido(nroPedido);
        }
    }
}
