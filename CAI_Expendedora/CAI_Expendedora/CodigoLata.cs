using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI_Expendedora
{
    class CodigoLata
    {
        string codigo;
        string marca;
        string sabor;

        public CodigoLata(string codigo, string marca, string sabor)
        {
            this.codigo = codigo;
            this.marca = marca;
            this.sabor = sabor;
        }
        public CodigoLata(string codigo) : this(codigo, MarcaDe(codigo), SaborDe(codigo)) { }
        static public string MarcaDe(string codigo)
        {

            switch (codigo.First ())
            {
                case 'C':
                    return "Coca Cola";
                case 'F':
                    return "Fanta";
                case 'S':
                    return "Sprite";
                default:
                    throw new CodigoInvalidoException("El codigo no es valido");
            }

        }
        static public string SaborDe (string codigo)
        {
            switch (codigo.Last())
            {
                case '1':
                   return "Regular";
                case '2':
                    return "Zero";
                default:
                   throw new Exception("El codigo no es valido");
            }
        }
    }
}