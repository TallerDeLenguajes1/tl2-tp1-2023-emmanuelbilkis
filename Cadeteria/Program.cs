using _Cadeteria;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Elija la opcion de carga | 1: csv-csv | 2:csv-json | 3:json-json | json-csv");
        int opcionCarga = int.Parse(Console.ReadLine());   
        switch (opcionCarga)
        {
            case 1:
                Menu menu = new Menu("cadeteria.csv","cadetes.csv");
                menu.On();
                break;
            case 2:
                Menu menu2 = new Menu("cadeteria.csv", "cadetes.json");
                menu2.On(); 
                break;
            case 3:
                Menu menu3 = new Menu("cadeteria.json", "cadetes.json");
                menu3.On();
                break;
            case 4:
                Menu menu4 = new Menu("cadeteria.json", "cadetes.csv");
                menu4.On();
                break;
            default:
                break;
        }
    }
}