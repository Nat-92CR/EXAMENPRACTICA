using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMENPRACTICA.Clases
{
    public class tipo
    {
        public static int id { get; set; }
        public static string descripcion { get; set; }

        public tipo(int Id, string Descripcion)
        {
            id = Id;
            descripcion = Descripcion;
        }
        public tipo(string Descripcion)
        {
            descripcion = Descripcion;
        }
        public tipo() { }

        public static int Agregar(string descripcion)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INGRESARTIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@DESCRIPCION", descripcion));


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

        public static int Borrar(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRARTIPO", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CODIGO", id));


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

        public void consultar()
        {

        }

        public void modificar()
        {

        }

        public static List<tipo> consultaFiltro(int id)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<tipo> tipos = new List<tipo>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("CONSULTAR_FILTROTIPOS", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tipo tipo = new tipo(reader.GetInt32(0), reader.GetString(1));  // instancia
                            tipos.Add(tipo);
                            
                        }
                        

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return tipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return tipos;
        }





        public static List<tipo> ObtenerTipos()
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            List<tipo> tipos = new List<tipo>();
            try
            {

                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("consultar ", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tipo tipo = new tipo(reader.GetInt32(0), reader.GetString(1));  // instancia
                            tipos.Add(tipo);
                        }

                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return tipos;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return tipos;
        }
    }
}