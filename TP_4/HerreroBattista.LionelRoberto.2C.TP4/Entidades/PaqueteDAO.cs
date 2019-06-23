using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Constructor estático de la clase PaqueteDAO
        /// </summary>
        static PaqueteDAO()
        {
            string connectionStr;

            connectionStr = "Data Source=.\\SQLEXPRESS; Initial Catalog =correo-sp-2017; Integrated Security = True";

            conexion = new SqlConnection(connectionStr);

            comando = new SqlCommand();

            comando.CommandType = System.Data.CommandType.Text;

            comando.Connection = conexion;

        }

        /// <summary>
        /// Guarda un paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete a guardar</param>
        /// <returns>True si guardó, false si hubo error</returns>
        public static bool Insertar(Paquete p)
        {
            bool consultaRealizada = true;
            string consulta;

            consulta = String.Format("INSERT INTO Paquetes(direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}','Lionel Herrero Battista')",
                p.DireccionEntrega, p.TrackingID);

            try
            {
                comando.CommandText = consulta;

                conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch
            {
                Exception e = new Exception("No se pudo guardar el paquete en la base de datos.");

                EventArgs eventArgs = new EventArgs();

                consultaRealizada = false;

                InformarUsuario.Invoke(e, eventArgs);

            }
            finally
            {
                conexion.Close();
            }

            return consultaRealizada;
        }

        public delegate void ExceptionThread(object sender, EventArgs e);

        public static event ExceptionThread InformarUsuario;

    }
}
