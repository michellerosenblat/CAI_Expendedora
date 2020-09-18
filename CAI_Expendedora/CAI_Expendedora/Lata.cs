using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class Lata
    {
        double precio;
        double volumen;
        CodigoLata codigo;

        public Lata (string codigo, double precio, double volumen)
        {
            try {
                this.codigo = new CodigoLata(codigo);
            }
            catch (CodigoInvalidoException e)
            {
                throw new CodigoInvalidoException(e.Message);
            }
            
            this.precio = precio;
            this.volumen = volumen;
        }
    }
}
