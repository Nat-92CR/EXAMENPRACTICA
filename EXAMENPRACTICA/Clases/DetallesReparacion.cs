using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMENPRACTICA.Clases
{
    public class DetallesReparaciones
    {

        public string descripcion { get; set; }
        public DateTime fechaInicio { get; set; }  
        public DateTime fechaFin { get; set; }

        public DetallesReparaciones() { }


        public static int Agregar(string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INGRESAR", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));
                    cmd.Parameters.Add(new SqlParameter("@FECHAINICIO", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@FECHAFIN", fechaFin));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
    }
}