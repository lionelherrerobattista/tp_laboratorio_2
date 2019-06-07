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

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

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

        public static bool Guardar(Universidad uni)
        {
            string archivo;

            Xml<Universidad> archivoxml = new Xml<Universidad>();

            archivo = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            return archivoxml.Guardar(archivo, uni);
        }

        private static string MostrarDatos(Universidad uni)
        {
            return uni.ToString();
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }

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
