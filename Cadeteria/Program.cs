using _Cadeteria;

public class Program
{
    private static void Main(string[] args)
    {
        int opcion; 
        AccesoDato data = new AccesoDato();
        Cadeteria cadeteria = data.GetCadeteria("cadeteria.csv");
        List<Cadete> cadetes = data.GetCadetes("cadetes.csv");
        cadeteria.Cadetes = cadetes;

        Console.WriteLine("Bienvenidos al Sistema integral de Cadeteria");
        Console.WriteLine("Seleccione la opcion deseada");
        Console.WriteLine("1:Generar Pedido | 2:Reasignar Pedido | 3:Borrar Pedido |4:GEenerar Informe");
        opcion = int.Parse(Console.ReadLine());
        

        switch (opcion)
        {
            case 1:
                Console.WriteLine("Escriba el numero del pedido"); // (en el futiro esto se hara auto incremental)
                int numeroPedido= int.Parse(Console.ReadLine());
                Console.WriteLine("Escriba observaciones");
                string observacionPedido = Console.ReadLine();
                Console.WriteLine("Escriba nombre cliente");
                string nombreCliente = Console.ReadLine();
                Console.WriteLine("Indique la direccion del cliente");
                string direccionCliente = Console.ReadLine();
                Console.WriteLine("Telefono del cliente");
                int telefonoCliente=int.Parse(Console.ReadLine());
                Console.WriteLine("ALgun dato referencia a la direccion del cliente");
                string datosReferenciaDireccionCliente = Console.ReadLine();
                Console.WriteLine("Numero de cadete para asignarle el pedido");
                int idCadete = int.Parse(Console.ReadLine());
                cadeteria.GenerarPedido(numeroPedido,observacionPedido,nombreCliente,direccionCliente,telefonoCliente,datosReferenciaDireccionCliente,idCadete);
                break;
            case 2:
                Console.WriteLine("Numero de cadete origen");
                int idCadeteOrigen = int.Parse(Console.ReadLine());
                Console.WriteLine("Numero de cadete para asignarle el pedido");
                int idCadeteDestino = int.Parse(Console.ReadLine());
                Console.WriteLine("Numero de pedido");
                int nroPedido = int.Parse(Console.ReadLine());
                cadeteria.ReasignarPedido(idCadeteOrigen,idCadeteDestino,nroPedido);
                break;
            case 3:
                Console.WriteLine("Numero de cadete");
                int _idCadete = int.Parse(Console.ReadLine());
                Console.WriteLine("Numero de pedido");
                int _nroPedido = int.Parse(Console.ReadLine());
                cadeteria.BorrarPedido(_idCadete,_nroPedido);
                break;
            case 4:
                cadeteria.GenerarInforme(); // se optimizara mas adelante
                break;
            default:
                break;
        }
    }
}