using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class CodigoInvalidoException : Exception
    {
        public CodigoInvalidoException (string mensaje) : base (mensaje)
        {
            
        }
    }
}
