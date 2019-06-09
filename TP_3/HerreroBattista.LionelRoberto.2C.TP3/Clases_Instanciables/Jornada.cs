using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EClases = Entidades_TP3.Universidad.EClases;

namespace Entidades_TP3
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Constructor por defecto de la clase Jornada, instancia la lista de Alumnos
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Crea un objeto de la clase Jornada
        /// </summary>
        /// <param name="clase">Clase de la Jornada</param>
        /// <param name="instructor">Profesor de la Jornada</param>
        public Jornada(EClases clase, Profesor instructor) :
            this()
        {
            this.clase = clase;
            this.instructor = instructor;

        }

        /// <summary>
        /// Devuelve o establece la lista de Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Devuelve o establece la clase
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Devuelve el Profesor de la Jornada
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        /// <summary>
        /// Guarda los datos de la Jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>true si guardó, false si hubo error</returns>
        public static bool Guardar(Jornada jornada)
        {
            string archivo;

            Texto jornadaATexto = new Texto();

            archivo = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            return jornadaATexto.Guardar(archivo, jornada.ToString());
        }

        /// <summary>
        /// Retorna los datos de la Jornada como texto
        /// </summary>
        /// <returns>Datos de la jornada</returns>
        public static string Leer()
        {
            string archivo;
            string datos;

            Texto textoAJornada = new Texto();

            archivo = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));  //;

            if (!(textoAJornada.Leer(archivo, out datos)))
            {
                datos = "No se pudo leer";
            }

            return datos;
        }

        /// <summary>
        /// Compara si un alumno no participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno no participa, false si participa</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega alumnos a la clase validando que no estén previamente cargados
        /// </summary>
        /// <param name="j">Jornada donde se guarda el alumno</param>
        /// <param name="a">Alumno a guardar</param>
        /// <returns>Jornada con el alumno cargado</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool estaAlumno = false;

            foreach (Alumno auxAlumno in j.Alumnos)
            {
                if (auxAlumno == a)
                {
                    estaAlumno = true;
                    break;
                }
            }

            if (estaAlumno == false)
            {
                j.Alumnos.Add(a);
            }


            return j;
        }

        /// <summary>
        /// Comprueba si el Alumno participa de la clase
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno participa, false si no participa</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool sonIguales = false;

            if (a == j.Clase)
            {

                sonIguales = true;
            }

            return sonIguales;
        }

        /// <summary>
        /// Muestra los datos de la Jornada
        /// </summary>
        /// <returns>Datos de la Jornada</returns>
        public override string ToString()
        {
            string datos;


            datos = String.Format("CLASE DE {0}", this.Clase);
            datos = String.Format("{0} POR {1}", datos, this.Instructor.ToString());

            datos = String.Format("{0}\n\nALUMNOS:", datos);

            foreach (Alumno alumno in this.Alumnos)
            {
                datos = String.Format("{0}\n{1}\n", datos, alumno.ToString());
            }

            return datos.ToString();
        }
    }
}
