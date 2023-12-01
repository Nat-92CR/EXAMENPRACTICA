using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMENPRACTICA.Clases
{
    public class Asignaciones
    {

        public int AsignacionId { get; set; }
        public int ReparacionId { get; set; }
        public string TecnicoId { get; set; }
        public float FechaAsignacion { get; set; }

        public Asignaciones() { }


        public static int Agregar(string descripcion, float precio, int tipo)
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
                    cmd.Parameters.Add(new SqlParameter("@PRECIO", precio));
                    cmd.Parameters.Add(new SqlParameter("@TIPO", tipo));

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