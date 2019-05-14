using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor de la clase dulce
        /// </summary>
        /// <param name="marca">Marca del Dulce</param>
        /// <param name="patente">Codigo de barras del Dulce</param>
        /// <param name="color">Color primario del empaque del Dulce</param>
        public Dulce(EMarca marca, string patente, ConsoleColor color)
            : base(patente, marca, color)
        {

        }


        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }


        /// <summary>
        /// Sobreescribe el método Mostrar de la clase Producto
        /// y muestra los datos de la clase Dulce
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
