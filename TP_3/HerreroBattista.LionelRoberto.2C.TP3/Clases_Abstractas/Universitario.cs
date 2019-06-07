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

        public Universitario()
            : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        protected virtual string MostrarDatos()
        {
            string datos;

            datos = String.Format("{0}\nLEGAJO NÚMERO: {1}", base.ToString(), this.legajo);

            return datos;
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            bool mismoTipo = false;

            if(obj is Universitario)
            {
                mismoTipo = true;
            }

            return mismoTipo;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool sonIguales = false;

            if(pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                sonIguales = true;
            }

            return sonIguales;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
    }
}
