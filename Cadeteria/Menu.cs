using _Cadeteria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Cadeteria
{
    public class Menu
    {
        public Menu(string pathCadeteria, string pathCadetes)
        {
            string[] arregloCadeteria = pathCadeteria.Split(".");
            string[] arregloCadetes = pathCadeteria.Split(".");

            if (arregloCadeteria[1] == "csv")
            {
                AccesoDato data = new AccesoDatoCsv();
                this.cadeteria = data.GetCadeteria("cadeteria.csv");
            }
            else
            {
                if (arregloCadeteria[1] == "json")
                {
                    AccesoDato data = new AccesoDatoJson();
                    this.cadeteria = data.GetCadeteria("cadeteria.json");
                }
            }

            if (arregloCadetes[1] == "csv")
            {
                AccesoDato data = new AccesoDatoCsv();
                this.cadetes = data.GetCadetes("cadetes.csv");
            }
            else
            {
                if (arregloCadetes[1] == "json")
                {
                    AccesoDato data = new AccesoDatoCsv();
                    this.cadetes = data.GetCadetes("cadetes.csv");
                }
            }

            this.salir = false;
            this.opcion = 1;
        }

        public Cadeteria cadeteria { get; set; }
        public List<Cadete> cadetes { get; set; }
        public bool salir { get; set; }
        public int opcion { get; set; }


        public void On ()
        {
            while (!salir)
            {
                Console.WriteLine("0:Cargar datos |1:Crear Pedido | 2:Asignar cadete a un pedido | 3:Reasignar cadete |4:Borrar Pedido | 5:Generar Informe | 6:Salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Escriba el numero del pedido"); // (en el futuro esto se hara auto incremental)
                        int numeroPedido = int.Parse(Console.ReadLine());
                        Console.WriteLine("Escriba observaciones");
                        string observacionPedido = Console.ReadLine();
                        Console.WriteLine("Escriba nombre cliente");
                        string nombreCliente = Console.ReadLine();
                        Console.WriteLine("Indique la direccion del cliente");
                        string direccionCliente = Console.ReadLine();
                        Console.WriteLine("Telefono del cliente");
                        int telefonoCliente = int.Parse(Console.ReadLine());
                        Console.WriteLine("ALgun dato referencia a la direccion del cliente");
                        string datosReferenciaDireccionCliente = Console.ReadLine();
                        cadeteria.CrearPedido(numeroPedido, observacionPedido, nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el id de cadete");
                        int _idCadete = int.Parse(Console.ReadLine());
                        Console.WriteLine("Ingrese el nunmero del pedido");
                        int _nroPedido = int.Parse(Console.ReadLine());
                        cadeteria.AsignarCadeteAPedido(_idCadete, _nroPedido);
                        break;
                    case 3:
                        Console.WriteLine("Numero de cadete para asignarle el pedido");
                        int idCadeteDestino = int.Parse(Console.ReadLine());
                        Console.WriteLine("Numero de pedido");
                        int nroPedido = int.Parse(Console.ReadLine());
                        cadeteria.ReasignarPedido(idCadeteDestino, nroPedido);
                        break;
                    case 4:
                        Console.WriteLine("Numero de pedido a borrar");
                        int _NumeroPedido = int.Parse(Console.ReadLine());
                        cadeteria.BorrarPedido(_NumeroPedido);
                        break;
                    case 5:
                        var informe = cadeteria.GenerarInforme();
                        foreach (var item in informe)
                        {
                            Console.WriteLine(item);
                        }// se optimizara mas adelante
                        break;
                    case 6:
                        salir = true;
                        break;

                    default:
                        break;
                }
            }
        }
    }

}

