using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcionmenu=0;
            Expendedora miexpendedora = new Expendedora();
            string codigo;
            double precio;
            double volumen;

            switch (opcionmenu)
            {
                case 1:
                    //Encender maquina
                    miexpendedora.EncenderMaquina();
                    Console.WriteLine(miexpendedora.Encendida ());
                    break;
                case 2:
                    //Listado de Latas disponibles
                    ListarLatas(miexpendedora);
                    break;
                case 3:
                    ListarLatas(miexpendedora);
                    Console.WriteLine("Ingrese un codigo");
                    codigo = Console.ReadLine();
                    do {
                        Console.WriteLine("Ingrese un precio");
                    }
                    while (!double.TryParse(Console.ReadLine(), out precio));
                    do
                    {
                        Console.WriteLine("Ingrese el volumen");
                    }
                    while (!double.TryParse(Console.ReadLine(), out volumen));
                    try {
                        miexpendedora.AgregarLata(new Lata(codigo, precio, volumen));
                    }
                    catch (CapacidadInsuficienteException e)
                    {
                        Console.WriteLine
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }


        }

        private static void ListarLatas(Expendedora miexpendedora)
        {
            foreach (string lata in miexpendedora.GetLatas())
            {
                Console.WriteLine(lata);
            }
        }
    }
}
