using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMENPRACTICA.Clases
{
    public class Reparaciones
    {

        public int EquipoId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public char Estado { get; set; } 
     
        public Reparaciones() { }


        public static int Agregar(int EquipoId, DateTime FechaSolicitud, Char Estado)
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
                    cmd.Parameters.Add(new SqlParameter("@EQUIPOID", EquipoId));
                    cmd.Parameters.Add(new SqlParameter("@FECHASOLICITUD", FechaSolicitud));
                    cmd.Parameters.Add(new SqlParameter("@ESTADO", Estado));

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