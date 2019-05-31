using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_TP3
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        
        }

        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;


        public Persona()
        {

        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this (nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this (nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                this.apellido = this.ValidarNombreApellido(value);
            }
        }

        public int DNI
        {
            get
            {
                return this.DNI;
            }
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = this.ValidarDni(this.nacionalidad, value);
            }
        }

        public override string ToString()
        {
            string datos;

            datos = String.Format("Nombre:{0}\nApellido:{1}",this.Nombre, this.Apellido);
            datos = String.Format("{0}\nNacionalidad:{1}\nDNI:{2}\n", datos, this.Nacionalidad, this.DNI);
            
            return datos;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;

            switch(nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dni >= 1 && dni <= 89999999)
                    {
                        dniValidado = dni;
                        
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;

                case ENacionalidad.Extranjero:
                    if(dni >= 90000000 && dni <= 99999999)
                    {
                        dniValidado = dni;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }

            return dniValidado;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            string dniAValidar;
            int dniValidado;

            dniAValidar = dato.Replace(".", String.Empty);

            if(dniAValidar.Count() > 8)
            {
                throw new DniInvalidoException();
            }
            else if((Int32.TryParse(dniAValidar, out dniValidado)) == false)
            {
                throw new DniInvalidoException();
            }

            return dniValidado;

        }

        private string ValidarNombreApellido(string dato)
        {
            string datoValidado = "";

            if((dato.All(Char.IsLetter)))
            {
                datoValidado = dato;
            }

            return datoValidado;
        }

    }
}
