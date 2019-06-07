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

        static Profesor()
        {
            Profesor.random = new Random();
            
        }

        public Profesor()
        {
            
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

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

        protected override string MostrarDatos()
        {
            string datos;

            datos = String.Format("{0}\n{1}", base.MostrarDatos(), this.ToString());
           
            return datos;
        }

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

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }

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

        public override string ToString()
        {
            string datos;

            datos = String.Format("{0}\n", base.MostrarDatos());
            datos = String.Format("{0}\n{1}",datos, this.ParticiparEnClase());

            return datos;
        }
    }
}
