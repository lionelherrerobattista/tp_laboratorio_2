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

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor) :
            this()
        {
            this.clase = clase;
            this.instructor = instructor;

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

        public static bool Guardar(Jornada jornada)
        {
            string archivo;

            Texto jornadaATexto = new Texto();

            archivo = String.Format("{0}\\Jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));

            return jornadaATexto.Guardar(archivo, jornada.ToString());
        }

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

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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

        public static bool operator ==(Jornada j, Alumno a)
        {
            bool sonIguales = false;

            if (a == j.Clase)
            {

                sonIguales = true;
            }

            return sonIguales;
        }

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
