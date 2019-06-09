using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EClases = Entidades_TP3.Universidad.EClases;


namespace Entidades_TP3
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }


        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor por defecto de la clase Alumno
        /// </summary>
        public Alumno()
        {

        }


        /// <summary>
        /// Crea un objeto de la clase ALumno
        /// </summary>
        /// <param name="id">Id del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">Dni del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
          : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Crea un objeto de la clase ALumno
        /// </summary>
        /// <param name="id">Id del Alumno</param>
        /// <param name="nombre">Nombre del Alumno</param>
        /// <param name="apellido">Apellido del Alumno</param>
        /// <param name="dni">Dni del Alumno</param>
        /// <param name="nacionalidad">Nacionalidad del Alumno</param>
        /// <param name="claseQueToma">Clase que toma el Alumno</param>
        /// <param name="estadoCuenta">Estado de cuenta del Alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
          : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Sobrescribe el método MostrarDatos con todos los datos del alumno
        /// </summary>
        /// <returns>string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            string datos;

            datos = String.Format("{0}\n{1}", base.MostrarDatos(), this.ToString());

            return datos;
        }

        /// <summary>
        /// Un alumno es distinto a un EClase si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Eclase</param>
        /// <returns>true si son distintos, false si no son distintos</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            bool sonDistintos = false;

            if (a.claseQueToma != clase)
            {
                sonDistintos = true;
            }

            return sonDistintos;
        }

        /// <summary>
        /// Compara si un Alumno es igual a un EClase si ese Alumno toma dicha clase y su estado de cuenta
        /// no es Deudor
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Eclase</param>
        /// <returns>true si son iguales, false si no son iguales</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            bool sonIguales = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                sonIguales = true;
            }

            return sonIguales;
        }

        /// <summary>
        /// Retornará la clase que toma el Alumno
        /// </summary>
        /// <returns>clase que toma el alumno</returns>
        protected override string ParticiparEnClase()
        {
            string clase;

            clase = String.Format("TOMA CLASE DE {0}", this.claseQueToma);

            return clase;
        }

        /// <summary>
        /// Hace públicos los datos del alumno
        /// </summary>
        /// <returns>Datos del alumno</returns>
        public override string ToString()
        {
            string datos;

            datos = String.Format("{0}", base.MostrarDatos());

            datos = String.Format("{0}\nESTADO DE CUENTA: {1}", datos,
                this.estadoCuenta);
            datos = String.Format("{0}\n{1}", datos, this.ParticiparEnClase());

            return datos;
        }
    }
}
