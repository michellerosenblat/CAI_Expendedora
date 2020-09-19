using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class DineroInsuficienteException : Exception
    {
        public DineroInsuficienteException(Lata lata, double dinero) : base("No hay dinero suficiente para realizar la compra de: " + lata.Codigo + ". Faltan: $ "+ (lata.Precio - dinero)) { }
    }
}
