using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_TP3;


namespace EntidadesAbstractas
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
                return this.dni;
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

        /// <summary>
        /// Sobrecarga del método ToString() que retorna los datos de las personas
        /// </summary>
        /// <returns>Datos de las personas</returns>
        public override string ToString()
        {
            string datos;

            datos = String.Format("NOMBRE COMPLETO: {0}, {1}",this.Apellido, this.Nombre);
            datos = String.Format("{0}\nNACIONALIDAD:{1}\n", datos, this.Nacionalidad);
            
            return datos;
        }

        /// <summary>
        /// Valida que el DNI ingresado esté dentro del rango de números correspondientes con la nacionalidad de la persona
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI a validar</param>
        /// <returns>DNI validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int dniValidado = 0;

            switch(nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        dniValidado = dato;
                        
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;

                case ENacionalidad.Extranjero:
                    if(dato >= 90000000 && dato <= 99999999)
                    {
                        dniValidado = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
                    break;
            }

            return dniValidado;
        }

        /// <summary>
        /// Valida que el DNI no contenga error de formato
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI validado</param>
        /// <returns></returns>
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

            try
            {
                dniValidado = this.ValidarDni(nacionalidad, dniValidado);
            }
            catch(Exception e)
            {
                throw e;
            }
            

            return dniValidado;

        }
        
        /// <summary>
        /// Valida que los nombres y apellidos contengan caracteres válidos
        /// </summary>
        /// <param name="dato">Nombre o apellido</param>
        /// <returns>Dato validado</returns>
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
