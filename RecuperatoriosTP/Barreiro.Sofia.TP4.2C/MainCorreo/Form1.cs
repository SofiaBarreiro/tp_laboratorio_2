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
namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        #region Atributos
        Correo correo;


        #endregion

        #region Constructores
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            mtxTrackingID.Focus();
        }
        #endregion

        #region Metodos


        /// <summary>
        /// muestra los datos en el richTextBx y llama al metodo de extension Guardar
        /// </summary>
        /// <typeparam name="T">Tipo generico</typeparam>
        /// <param name="elemento">objeto de la clase Generica</param>
        void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            rtbMostrar.Clear();
            if (!(object.ReferenceEquals(elemento, null)))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento) + "\n";
                try
                {
                    Entidades.GuardarString.Guardar(this.rtbMostrar.Text, "salida.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Actuliza los datos de los listBox
        /// </summary>
        void ActualizarEstados()
        {

            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresando.Items.Clear();

            foreach (Paquete aux in this.correo.Paquetes)
            {
                switch (aux.Estado)
                {
                    case EEstado.Ingresado:
                        lstEstadoIngresando.Items.Add(aux);
                        
                        break;
                    case EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(aux);
                        break;
                    case EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(aux);
                        break;
                }
            }

          
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }


        private void MostrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);

        }

        #endregion
        #region Eventos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(txtDireccion.Text, mtxTrackingID.Text);
            paquete.InformaEstado += paq_InformaEstado;


            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException)
            {
                string mensaje = "El Tracking ID " + paquete.TrackingID + " ya figura en la lista de envios.";
                MessageBox.Show(mensaje, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            ActualizarEstados();


        }

        private void FrmPpal_Load(object sender, EventArgs e)
        {

        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }



        /// <summary>
        /// llama al metodo mostrar Informacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);


        }
        #endregion


    }
}
