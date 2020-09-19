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

        public Lata(string codigo, double precio, double volumen)
        {
            this.codigo = new CodigoLata(codigo);
            this.precio = precio;
            this.volumen = volumen;
        }
        public Lata(CodigoLata codigoLata, double precio, double volumen)
        {
            this.codigo = codigoLata;
            this.precio = precio;
            this.volumen = volumen;
        }
        public CodigoLata Codigo
        {
            get {
            return this.codigo;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }
        public double Volumen
        {
            get
            {
                return this.volumen;
            }
        }
    }
}
