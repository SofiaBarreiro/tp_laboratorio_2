using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{


    public static class PaqueteDAO
    {
        #region Atributos

        static SqlCommand comando; 
        static SqlConnection conexion;
        #endregion

        #region Metodos
        /// <summary>
        /// carga los datos en una base de datos SQl
        /// </summary>
        /// <param name="p">paquete a agregar</param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string query = "INSERT INTO Paquetes (direccionEntrega,trackingID,alumno) VALUES(";
            query = query + "'" + p.DireccionEntrega + "','" + p.TrackingID + "','" + "Barreiro Sofia'" + ")";

            try
            {
                PaqueteDAO.comando.CommandText = query;
                PaqueteDAO.conexion.Open();
                PaqueteDAO.comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                retorno = false;
            }
            finally
            {
                if (retorno)
                {
                    PaqueteDAO.conexion.Close();
                }
            }
            return retorno;
        }

        #endregion

        #region Constructores

        static PaqueteDAO()
        {

           
            comando = new SqlCommand();


            conexion = new SqlConnection("Data Source=.;Initial Catalog=correo-sp-2017;Integrated Security=True");
            PaqueteDAO.comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;

        }

        #endregion
    }
}
