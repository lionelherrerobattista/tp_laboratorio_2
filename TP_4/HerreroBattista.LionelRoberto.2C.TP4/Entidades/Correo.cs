using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {

        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Constructor por defecto de la clase Correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Obtiene o establece la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Cierra los hilos activos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread hilo in this.mockPaquetes)
            {
                if(hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }


        /// <summary>
        /// Muestra los datos del correo
        /// </summary>
        /// <param name="elementos">Lista de paquetes</param>
        /// <returns>Datos del correo</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string datos = "";
            string paquete;
            bool primeraIteracion = true;

            foreach(Paquete p in ((Correo)elementos).Paquetes)
            {
                paquete = String.Format("{0} para {1} ({2})", p.TrackingID,
                    p.DireccionEntrega, p.Estado.ToString());

                if(primeraIteracion)
                {
                    primeraIteracion = false;
                    datos = paquete;
                }
                else
                {
                    datos = String.Format("{0}\n{1}", datos, paquete);
                }
                

                
            }

            return datos;

            
        }

        /// <summary>
        /// Agrega un paquete a la lista y crea un hilo para el método MockCicloDeVida
        /// y agrega dichi hilo a mockPaquetes
        /// </summary>
        /// <param name="c">Correo donde se va a agregar el Paquete</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool paqueteRepetido = false;

            Thread hilo;



            foreach (Paquete auxPaquete in c.Paquetes)
            {
                if(auxPaquete == p)
                {
                    paqueteRepetido = true;
                }
            }

            if(paqueteRepetido)
            {
                throw new TrackingIdRepetidoException("El paquete ya está en la lista");
            }
            else
            {
                c.Paquetes.Add(p);

               
                hilo = new Thread(p.MockCicloDeVida);

                c.mockPaquetes.Add(hilo);

                try
                {
                    hilo.Start();
                }
                catch (Exception e)
                {
                    throw e;
                }
               
            }

            return c;
        }




    }
}
