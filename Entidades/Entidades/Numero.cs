using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                //valido el numero como string
                //...

                //lo seteo:
                Double.TryParse(value, out this.numero);
            }
        }
    }
}
