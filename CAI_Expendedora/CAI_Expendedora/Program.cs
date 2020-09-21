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
            int opcionMenu = 0;
            Expendedora expendedora = new Expendedora();
            double precio;
            double volumen;
            CodigoLata codigoLata;
            MostrarEstadoDe(expendedora);
            while (opcionMenu !=6)
            {
                opcionMenu = PedirOpcionMenu();
                switch (opcionMenu)
                {
                    case 0:
                        //Encender maquina
                        expendedora.EncenderMaquina();
                        break;
                    case 1:
                        //Listado de Latas disponibles
                        ListarLatas(expendedora);
                        break;
                    case 2:
                        expendedora.EncenderMaquina();
                        ListarLatas(expendedora);
                        codigoLata = PedirCodigoLata();
                        precio = PedirNumero("Ingrese el precio");
                        volumen = PedirNumero("Ingrese el volumen");
                        try
                        {
                            expendedora.AgregarLata(new Lata(codigoLata, precio, volumen));
                            Console.WriteLine("Lata agregada exitosamente");
                        }
                        catch (CapacidadInsuficienteException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        expendedora.EncenderMaquina();
                        if (expendedora.GetCapacidadRestante() > 0)
                        {
                            expendedora.AgregarLata(new Lata("CO1", 5, 500));
                        }

                        ListarLatas(expendedora);
                        try
                        {
                            expendedora.ExtraerLata(PedirCodigoLata(), PedirNumero("Ingrese el dinero"));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 4:
                        expendedora.EncenderMaquina();
                        MostrarEstadoDe(expendedora);
                        break;
                    case 5:
                        expendedora.EncenderMaquina();
                        Console.WriteLine(expendedora.DevuelveStock());
                        break;
                    default:
                        break;
                }
                MostrarEstadoDe(expendedora);
            }
        }

        private static int PedirOpcionMenu()
        {
            int opcionMenu;
            do
            {
                Console.WriteLine("Ingrese la opcion de menú que desee:");
                Console.WriteLine("Opción 0: Encender máquina");
                Console.WriteLine("Opción 1: Listado de latas disponibles");
                Console.WriteLine("Opción 2: Insertar una lata");
                Console.WriteLine("Opción 3: Extraer Lata");
                Console.WriteLine("Opción 4: Obtener Balance");
                Console.WriteLine("Opción 5: Stock Disponible");
                Console.WriteLine("Opcion 6: Salir");
            }
            while (!int.TryParse(Console.ReadLine(), out opcionMenu));
            return opcionMenu;
        }

        private static double PedirNumero(string mensaje)
        {
            double numero;
            do
            {
                Console.WriteLine(mensaje);
            }
            while (!double.TryParse(Console.ReadLine(), out numero));
            return numero;
        }
        private static CodigoLata PedirCodigoLata()
        {
            Console.WriteLine("Ingrese un codigo");
            try
            {
                return new CodigoLata(Console.ReadLine());
            }
            catch (CodigoInvalidoException e)
            {
                Console.WriteLine(e.Message);
                return PedirCodigoLata();
            }

        }

        private static void ListarLatas(Expendedora miexpendedora)
        {
            foreach (string lata in miexpendedora.GetLatas())
            {
                Console.WriteLine(lata);
            }
        }
        private static void MostrarEstadoDe (Expendedora expendedora)
        {
            Console.WriteLine("---------------ESTADO---------------");
            Console.WriteLine(expendedora.Encendida());
            Console.WriteLine("La cantidad de latas es: " + expendedora.CantidadLatas());
            Console.WriteLine ("La capacidad restante es: " + expendedora.GetCapacidadRestante());
            Console.WriteLine("La cantidad de dinero es :" + expendedora.Dinero);
            Console.WriteLine("----------------FIN----------------");
        }
    }
}
