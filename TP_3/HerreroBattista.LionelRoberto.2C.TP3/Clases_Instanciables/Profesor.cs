using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using EClases = Entidades_TP3.Universidad.EClases;

namespace Entidades_TP3
{
    public sealed class Profesor : Universitario
    {
        private Queue<EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Instancia el atributo random
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
            
        }

        /// <summary>
        /// Constructor por defecto de la clase Profesor
        /// </summary>
        public Profesor()
        {
            
        }

        /// <summary>
        /// Crea un objeto de la clase Profesor
        /// </summary>
        /// <param name="id">Id del Profesor</param>
        /// <param name="nombre">Nombre del Profesor</param>
        /// <param name="apellido">Apellido del Profesor</param>
        /// <param name="dni">DNI del Profesor</param>
        /// <param name="nacionalidad">Nacionalidad del Profesor</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Asigna dos clases al azar al profesor
        /// </summary>
        private void _randomClases()
        {
            EClases claseUno;
            EClases claseDos;

            claseUno = (EClases) random.Next(0, 4);

            System.Threading.Thread.Sleep(200);

            claseDos = (EClases) random.Next(0, 4);

            this.clasesDelDia.Enqueue(claseUno);
            this.clasesDelDia.Enqueue(claseDos);
        }

        /// <summary>
        /// Muestra todos los datos del profesor
        /// </summary>
        /// <returns>Datos del profesor</returns>
        protected override string MostrarDatos()
        {
            string datos;

            datos = String.Format("{0}\n{1}", base.MostrarDatos(), this.ToString());
           
            return datos;
        }

        /// <summary>
        /// Muestra el nombre de las clases que da el profesor
        /// </summary>
        /// <returns>Clases que da el profesor</returns>
        protected override string ParticiparEnClase()
        {
            string datos;

            datos = String.Format("CLASES DEL DÍA:");

            foreach (EClases clase in clasesDelDia)
            {
                datos = String.Format("{0}\n{1}", datos, clase);
            }

            return datos;
        }

        /// <summary>
        /// Compara si un profesor es distinto a la clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>true si el profesor no da esa clase, false si la da</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Compara si un profesor da la clase con la que se lo compara
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>true si el profesor da esa clase, false si no la da</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool sonIguales = false;

            foreach(EClases claseProfesor in i.clasesDelDia)
            {
                if(claseProfesor == clase)
                {
                    sonIguales = true;
                    break;
                }
            }

            return sonIguales;
        }

        /// <summary>
        /// Hace públicos los datos del profesor
        /// </summary>
        /// <returns>Datos del profesor</returns>
        public override string ToString()
        {
            string datos;

            datos = String.Format("{0}\n", base.MostrarDatos());
            datos = String.Format("{0}\n{1}",datos, this.ParticiparEnClase());

            return datos;
        }
    }
}
