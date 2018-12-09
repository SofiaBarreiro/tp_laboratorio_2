using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{

    #region enumeradores
    public enum EEstado
    {
        Ingresado,
        EnViaje,
        Entregado,
    }
    #endregion
    public class Paquete : IMostrar<Paquete>
    {

        #region Atributos
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        #endregion
        #region Eventos
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public delegate void DelegadoSQL();
        public event DelegadoEstado InformaEstado;
        public event DelegadoSQL InformarSQL;

        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = (object.Equals(value, null)) ? this.direccionEntrega : value;
            }
        }

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


        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = (object.Equals(value, null)) ? this.trackingID : value;
            }
        }


        #endregion
        #region constructores

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.Estado = EEstado.Ingresado;


        }
        #endregion

        #region Metodos

        /// <summary>
        /// muestra los datos de Paquete
        /// </summary>
        /// <param name="elemento">lista de paquetes</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            string cadena =string.Format("{0} para {1}\n", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
            string retorno = (object.Equals(elemento, null)) ? "" : cadena;
            return retorno;
        
        }


        
        /// <summary>
        /// Inicia los hilos, realiza los cambios de estados y guarda los datos en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.Estado++;
                this.InformaEstado(this,EventArgs.Empty);
            }
            while (this.Estado != EEstado.Entregado);
            if (this.Estado == EEstado.Entregado)
            {

                if (PaqueteDAO.Insertar(this))
                {

                    InformarSQL();
                }
               
            }



        }

        


        /// <summary>
        //7 sobreescribe el metodo ToString y llama a la funcion MostrarDatos
        /// </summary>
        /// <returns>retorno de MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }
        #endregion

        #region operadores
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);

        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        #endregion




    }
}
