using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades_TP3
{
    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD

        }

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        /// <summary>
        /// Constructor por defecto de la clase Universidad, instancia las listas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        /// <summary>
        /// Devuelve o establece la lista de Alumnos de la Universidad
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
        /// Devuelve o establece la lista de Profesores de la Universidad
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Devuelve o establece la lista de Jornadas de la Universidad
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Indexador para acceder a una Jornada específica
        /// </summary>
        /// <param name="i">Índice de la Jornada</param>
        /// <returns>Jornada que se corresponde con el índice</returns>
        public Jornada this[int i]
        {
            get
            {
                Jornada jornadaAux = null;

                if (i < this.jornadas.Count)
                {
                    jornadaAux = this.jornadas[i];
                }

                return jornadaAux;
            }
            set
            {
                if (i < this.jornadas.Count)
                {
                    this.jornadas[i] = value;
                }
            }
        }

        /// <summary>
        /// Serializa los datos de Universidad en un XML junto con los datos de sus Profesores, Alumnos y Jornadas
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>true si serializó los datos, false si hubo error</returns>
        public static bool Guardar(Universidad uni)
        {
            string archivo;

            Xml<Universidad> archivoxml = new Xml<Universidad>();

            archivo = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            return archivoxml.Guardar(archivo, uni);
        }

        /// <summary>
        /// Muestra los datos de la Universidad
        /// </summary>
        /// <param name="uni">Universidad que se va a mostrar</param>
        /// <returns>Datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

        /// <summary>
        /// Hace públicos los datos de la Universidad
        /// </summary>
        /// <returns>Datos de la Universidad</returns>
        public override string ToString()
        {
            string datos;

            datos = "JORNADA:";

            foreach (Jornada jornada in this.Jornadas)
            {
                datos = String.Format("{0}\n{1}", datos, jornada.ToString());
                datos = String.Format("{0}<----------------------------------------->", datos);
            }

            return datos;
        }

        /// <summary>
        /// Comprueba que el Alumno no esté inscripto en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el Alumno no está inscripto, false si está</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Comprueba si el profesor no está dando clases en la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si el Profesor no está dando clases, false si está</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer profesor que no pueda dar la clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Profesor que no puede dar la clase</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor auxProfesor = null;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor != clase)
                {
                    auxProfesor = profesor;
                    break;
                }
            }

            return auxProfesor;
        }

        /// <summary>
        /// Agrega una clase a una universidad
        /// </summary>
        /// <param name="g">Universidad donde se va a agregar la clase</param>
        /// <param name="clase">Clase a agregar</param>
        /// <returns>Universidad con la clase agregada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada nuevaJornada = null;
            Profesor profesor;

            profesor = (g == clase);

            nuevaJornada = new Jornada(clase, profesor);

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == clase)
                {
                    nuevaJornada.Alumnos.Add(alumno);
                }
            }

            if(nuevaJornada.Alumnos.Count > 0)
            {
                g.Jornadas.Add(nuevaJornada);
            }
            

            return g;

        }

        /// <summary>
        /// Agrega un alumno a la Universidad validando que no haya sido cargado previamente
        /// </summary>
        /// <param name="g">Universidad donde se va a agregar el alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Universidad con el alumno agregado</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }

        /// <summary>
        /// Agrega un Profesor a la Univeridad validando que no haya sido cargado previamente
        /// </summary>
        /// <param name="g">Universidad donde se va a agregar al Profesor</param>
        /// <param name="i">Profesor que se va a agregar</param>
        /// <returns>Universidad con el Profesor cargado</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }

        /// <summary>
        /// Comprueba si el Alumno está inscripto en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>true si el alumno está inscripto, false si no está</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool sonIguales = false;

            foreach (Alumno auxAlumno in g.Alumnos)
            {
                if (auxAlumno == a)
                {
                    sonIguales = true;
                }
            }

            return sonIguales;
        }

        /// <summary>
        /// Comprueba si el Profesor está dando clases en la Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>true si el profesor está dando clases en la Universidad, false si no está</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool sonIguales = false;

            foreach (Profesor auxProfesor in g.Instructores)
            {
                if (auxProfesor == i)
                {
                    sonIguales = true;
                }
            }

            return sonIguales;
        }

        /// <summary>
        /// Retornará el primer profesor capaz de dar la clase indicada
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Primer profesor que puede dar la clase</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor auxProfesor = null;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                {
                    auxProfesor = profesor;
                    break;
                }
            }

            if (Object.ReferenceEquals(auxProfesor, null))
            {
                throw new SinProfesorException();
            }

            return auxProfesor;
        }
    }
}
