using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Expendedora
    {
        List<Lata> latas;
        string proveedor;
        int capacidad;
        double dinero;
        private bool encendida;
        public Expendedora()
        {
            encendida = false;
            capacidad = 1;
            latas = new List<Lata>();
            dinero = 0;
        }
        public string Encendida()
        {
            if (encendida)
                return "La máquina está encendida";
            else
                return "La máquina está apagada";
        }
        public void EncenderMaquina()
        {
            encendida = true;
        }
        public void AgregarLata(Lata lata)
        {
                if (this.encendida && GetCapacidadRestante()>0)
                {
                    latas.Add(lata);
                }
                else if (!this.encendida)
                {
                    throw new Exception("Se debe encender la maquina primero");
                }
                else  
                {
                    throw new CapacidadInsuficienteException();
                }

        }
        public Lata ExtraerLata(CodigoLata codigoLata, double dineroIngresado)
        {
            if (HayStockDe(codigoLata))
            {
                Lata lataAEliminar = latas.Find(lata => lata.Codigo.Equals(codigoLata));
                if (AlcanzaDineroPara(lataAEliminar, dineroIngresado)) {
                    latas.Remove(lataAEliminar);
                    IngresarDinero(lataAEliminar.Precio);
                    return lataAEliminar;
                }
                else
                {
                    throw new DineroInsuficienteException(lataAEliminar, dineroIngresado);
                }
            }else
                throw new SinStockException ();
        }
        /* public string GetBalance()
 {

 }*/
        public bool AlcanzaDineroPara (Lata lata, double dineroIngresado)
        {
            return lata.Precio <= dineroIngresado;
        }
        public void IngresarDinero (double dineroAIngresar)
        {
            dinero += dineroAIngresar;
        }
        public bool HayStockDe (CodigoLata codigoLata)
        {
            return latas.Any(lata => lata.Codigo.Equals (codigoLata));
        }
        public int GetCapacidadRestante()
        {
            return capacidad - latas.Count();
        }
        public string[] GetLatas()
        {
            return new string [6]{ "CO1 - Coca Cola Regular", "CO2 - Coca Cola Zero", "SP1 - Sprite Regular", "SP2 - Sprite Zero", "FA1 - Fanta Regular", "FA2 - Fanta Zero"};
        }
        public int CantidadLatas()
        {
            return latas.Count();
        }
        public double Dinero {
            get
            {
                return dinero;
            }
        }
        public string DevuelveStock()
        {
            string stock="";
            foreach (Lata lata in latas)
            {
                stock += lata.Codigo + " $ " + + lata.Precio + " $/L " + (lata.Precio/lata.Volumen) +'\n';
            }
            return stock;
        }
    }
}
