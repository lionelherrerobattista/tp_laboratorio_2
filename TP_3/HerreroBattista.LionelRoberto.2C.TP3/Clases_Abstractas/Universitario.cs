using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto de la clase Universitario
        /// </summary>
        public Universitario()
            : base()
        {

        }

        /// <summary>
        /// Crea un objecto de la clase Universitario
        /// </summary>
        /// <param name="legajo">Número de legajo</param>
        /// <param name="nombre">Nombre del Universitario</param>
        /// <param name="apellido">Apellido del Universitario</param>
        /// <param name="dni">Dni del Universitario</param>
        /// <param name="nacionalidad">Nacionalidad del Universitario</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Muestra todos los datos del universitario
        /// </summary>
        /// <returns>String con todos los datos del universitario</returns>
        protected virtual string MostrarDatos()
        {
            string datos;

            datos = String.Format("{0}\nLEGAJO NÚMERO: {1}", base.ToString(), this.legajo);

            return datos;
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Sobrecarga del método Equals que comprueba que un objeto sea del tipo Universitario
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true si es del mismo tipo, false si no lo es</returns>
        public override bool Equals(object obj)
        {
            bool mismoTipo = false;

            if (obj is Universitario)
            {
                mismoTipo = true;
            }

            return mismoTipo;
        }

        /// <summary>
        /// Compara si dos universitarios tienen el mismo tipo y si su legajo o si su DNI coinciden
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns>true si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool sonIguales = false;

            if (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                sonIguales = true;
            }

            return sonIguales;
        }



        /// <summary>
        /// Compara si dos universitarios son distiontos
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns>true si son iguales, false si nlo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
