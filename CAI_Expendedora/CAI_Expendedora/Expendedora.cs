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
            capacidad = 10;
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
            try
            {
                if (this.encendida && GetCapacidadRestante() >= 1)
                {
                    latas.Add(lata);
                }
                else if (!this.encendida)
                {
                    throw new Exception("Se debe encender la maquina primero");
                }
            }
            catch (CapacidadInsuficienteException e)
            {
                //no se si hace falta capturar la excepcion aca o dejar que lo haga el program
                throw new CapacidadInsuficienteException(e.Message);
            }
            
            
        }
        public Lata ExtraerLata(string codigo, double dineroingresado)
        {

        }
        public string GetBalance()
        {

        }
        public int GetCapacidadRestante()
        {
            if (capacidad - latas.Count()>= 1)
            {
                return capacidad - latas.Count();
            }
            else
            {
                throw new CapacidadInsuficienteException("No hay capacidad suficiente");
            }

        }
        public string[] GetLatas()
        {
            return new string [6]{ "CO1 - Coca Cola Regular", "CO2 - Coca Cola Zero", "SP1 - Sprite Regular", "SP2 - Sprite Zero", "FA1 - Fanta Regular", "FA2 - Fanta Zero"};
        }
    }
}
