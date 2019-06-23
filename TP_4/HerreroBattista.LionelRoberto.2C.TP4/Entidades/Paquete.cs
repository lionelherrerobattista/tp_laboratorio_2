using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado

        }

        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        /// <summary>
        /// Constructor de la clase Paquete
        /// </summary>
        /// <param name="direccionEntrega">Dirección de entrega</param>
        /// <param name="trackingID">Tracking ID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Obtiene o establece la dirección de entrega del Paquete
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el estado del Paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el Tracking ID del Paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Hace que el Paquete cambie de estado
        /// </summary>
        public void MockCicloDeVida()
        {
            int indice;

            EventArgs e = new EventArgs();
            

            while (this.Estado != EEstado.Entregado) 
            {
                Thread.Sleep(4000);

                indice = (int)this.Estado;

                indice++;

                this.Estado = (EEstado)indice;

                this.InformarEstado(this.Estado, e);

            }

          
             PaqueteDAO.Insertar(this);
            
            

        }

        /// <summary>
        /// Muestra los datos del Paquete
        /// </summary>
        /// <param name="elemento">Paquete que se va a mostrar</param>
        /// <returns>Datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string datos;

            

            datos = String.Format("{0} para {1}", ((Paquete)elemento).TrackingID,
                ((Paquete)elemento).DireccionEntrega);

            return datos;

        }

        /// <summary>
        /// Comprueba si los paquetes no tienen el mismo Tracking ID
        /// </summary>
        /// <param name="p1">Primer paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>True si son distintos, false si son iguales</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Comprueba si lo paquetes tienen el mismo Tracking ID
        /// </summary>
        /// <param name="p1">Primer paquete a comparar</param>
        /// <param name="p2">Segundo paquete a comparar</param>
        /// <returns>True si son iguales, false si son distintos</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool sonIguales = false;

            if(p1.TrackingID == p2.TrackingID)
            {
                sonIguales = true;
            }

            return sonIguales;

        }

        /// <summary>
        /// Sobrecarga del método ToString que muestra la información del paquete
        /// </summary>
        /// <returns>Información del paquete</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public event DelegadoEstado InformarEstado;

    }
}
