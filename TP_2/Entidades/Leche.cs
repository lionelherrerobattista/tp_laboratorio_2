using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }

        private ETipo tipo;

        /// <summary>
        /// Constructor de la clase Leche
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca">Marca de la Leche</param>
        /// <param name="patente">Código de barras de la Leche</param>
        /// <param name="color">Color primario del empaque de la Leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color)
            : this(marca, patente, color, ETipo.Entera)
        {
            
        }

        /// <summary>
        /// Sobrecarga del Constructor, recibe TIPO
        /// </summary>
        /// <param name="marca">Marca de la Leche</param>
        /// <param name="patente">Código de barras de la Leche</param>
        /// <param name="color">Color del empaque de la Leche</param>
        /// <param name="tipo">Tipo de Leche</param>
        public Leche(EMarca marca, string patente, ConsoleColor color, ETipo tipo)
            : base(patente, marca, color)
        {
            this.tipo = tipo;
        }


        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        protected override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        /// <summary>
        /// Sobreescribe el método Mostrar de la clase Producto
        /// y muestra los datos de la clase Leche
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}\n", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
