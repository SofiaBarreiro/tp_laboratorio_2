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
        #region Atributos

        private List<Thread> mockPaquetes;

        private List<Paquete> paquetes;

        #endregion

        #region Propiedades
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


        #endregion

        #region Constructores
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();

        }
        #endregion

        #region Metodos
        /// <summary>
        /// finaliza los hilos que se encuentran activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (hilo.IsAlive)
                {

                    hilo.Abort();
                }

            }
        }


        /// <summary>
        /// devuelve una cadena con los datos del paquete
        /// </summary>
        /// <param name="elementos"> lista de paquetes</param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {

            List<Paquete> listaPaquete = (List<Paquete>)((Correo)elementos).paquetes;
            StringBuilder cadena = new StringBuilder();
            foreach (Paquete paquete in listaPaquete)
            {
                cadena.AppendFormat("{0} para {1} ({2})", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());

            }

            return cadena.ToString();

        }
        #endregion

        #region Operadores
        /// <summary>
        /// añade un paquete a la lista de correos si no se encuentra repetido
        /// </summary>
        /// <param name="c">lista de correos</param>
        /// <param name="p">paquete a agregar</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool encontro = false;
            
                foreach (Paquete aux in c.paquetes)
                {

                    if (aux == p)
                    {
                        throw new TrackingIdRepetidoException("id repetido");

                    }

                }

                c.paquetes.Add(p);

                Thread nuevo = new Thread(p.MockCicloDeVida);

                c.mockPaquetes.Add(nuevo);

            nuevo.Start();

            return c;
        }
        #endregion



    }
}
