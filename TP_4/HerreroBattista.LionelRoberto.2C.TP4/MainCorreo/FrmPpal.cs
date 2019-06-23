using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using MetodoDeExtension;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;

        /// <summary>
        /// Constructor por defecto del formulario
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();

            this.correo = new Correo();

            PaqueteDAO.InformarUsuario += this.mensajeExcepcionThread;
        }

        /// <summary>
        /// Recorre la lista de paquetes agregando cada uno de ellos en la lista que corresponda
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach(Paquete p in this.correo.Paquetes)
            {
                switch(p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                }
            }

        }

        /// <summary>
        /// Cierra el formulario y los hilos abiertos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        /// <summary>
        /// Muestra la información del paquete y la guarda en un archivo .txt en el escritorio
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string datos;

            if(!(elemento is null))
            {
                
                datos = elemento.MostrarDatos(elemento);

                rtbMostrar.Text = datos;

                try
                {
                    datos.Guardar(String.Format("{0}\\salida.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }

                
            }
        }

        /// <summary>
        /// Muestra la información del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Informa el estado del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado); this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Agrega un paquete a la lista de Correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete p = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

            p.InformarEstado += this.paq_InformaEstado;

            try
            {
                correo = correo + p;
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            this.ActualizarEstados();
        }

        /// <summary>
        /// Muestra la información de la lista de paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// En caso de que no se pueda guardar en la Base de Datos, muestra el mensaje de error de la excepción que se produce
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mensajeExcepcionThread(object sender, EventArgs e)
        {
            MessageBox.Show(((Exception)sender).Message);
        }

       

    }
}
