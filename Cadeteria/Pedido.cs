using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Cadeteria
{
    public class Pedido
    {
        private int numero;
        private string observacion;
        private bool estado;
        private Cliente cliente;

        public Pedido(int numero, string observacion, string nombre, string direccion, int telefono, string datosReferenciaDireccion)
        {
            this.numero = numero;
            this.observacion = observacion;
            this.estado = false;
            Cliente clienteAsignado = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
            this.Cliente = clienteAsignado;
        }

        public int Numero { get => numero; set => numero = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public bool Estado { get => estado; set => estado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

        public string VerDireccionCliente()
        {
            return this.cliente.Direccion;
        }

        public string VerDatosDelCliente()
        {
            string datos = this.Cliente.Nombre + "-" + this.cliente.Telefono 
             + "-" + this.cliente.Direccion + "-" + this.cliente.DatosReferenciaDireccion;
            return datos;   
        }

        public string GenerarInformePedido()
        {
            string informe = $"Numero:{this.Numero} | Observacion:{this.Observacion} | Estado:{this.Estado}";
            informe = informe + "| Datos CLiente: " + this.VerDatosDelCliente();
            return informe;
        }

    }
}
