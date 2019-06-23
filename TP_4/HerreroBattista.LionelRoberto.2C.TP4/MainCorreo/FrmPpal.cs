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

        public FrmPpal()
        {
            InitializeComponent();

            this.correo = new Correo();

            PaqueteDAO.InformarUsuario += this.mensajeExcepcionThread;
        }

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

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

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

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

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

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mensajeExcepcionThread(object sender, EventArgs e)
        {
            MessageBox.Show(((Exception)sender).Message);
        }

       

    }
}
