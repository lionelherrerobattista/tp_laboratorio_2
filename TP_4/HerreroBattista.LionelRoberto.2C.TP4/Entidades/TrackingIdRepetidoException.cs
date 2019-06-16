using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Excepción que se lanza en caso de que haya un TrackingId repetido
        /// </summary>
        /// <param name="mensaje">Mensaje que se va a guardar</param>
        public TrackingIdRepetidoException(string mensaje)
            : base(mensaje)
        {

        }

        /// <summary>
        /// Excepción que se lanza en caso de que haya un TrackingId repetido
        /// </summary>
        /// <param name="mensaje">Mensaje que se va a guardar</param>
        /// <param name="inner">Inner exception</param>
        public TrackingIdRepetidoException(string mensaje, Exception inner)
            : base(mensaje, inner)
        {

        }
    }
}
