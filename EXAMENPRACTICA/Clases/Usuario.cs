using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace EXAMENPRACTICA.Clases
{ 
 public class Usuario
{
    public static int nombre { get; set; }
    public static string correoElectronico { get; set; }
    public static int telefono { get; set; }


    public Usuario(int nombre, string correoElectronico, int telefono)
    {
        nombre = nombre;
        correoElectronico = correoElectronico;
        telefono = telefono;
    }
    public Usuario( string CorreoElectronico)
    {
        correoElectronico = CorreoElectronico;      
    }
    public Usuario() { }

    public static int AGREGAR_USUARIO(string CorreoElectronico)
    {
        int retorno = 0;

        SqlConnection Conn = new SqlConnection();
        try
        {
            using (Conn = DBConn.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("AGREGAR_USUARIO", Conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter( "@CORREOELECTRONICO", CorreoElectronico));


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

    public static int Borrar(int Nombre)
    {
        int retorno = 0;

        SqlConnection Conn = new SqlConnection();
        try
        {
            using (Conn = DBConn.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("BORRAR_USUARIOS", Conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", Nombre));


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

    public static List<Usuario> CONSULTAR_FILTRO_USUARIOS(int Nombre)
    {
        int retorno = 0;

        SqlConnection Conn = new SqlConnection();
        List<Usuario> usuarios = new List<Usuario>();
        try
        {

            using (Conn = DBConn.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("CONSULTAR_FILTRO_USUARIOS", Conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@NOMBRE", Nombre));
                retorno = cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));  // instancia
                        usuarios.Add(usuario);

                    }


                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            return usuarios;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return usuarios;
    }





    public static List<Usuario> ObtenerTipos()
    {
        int retorno = 0;

        SqlConnection Conn = new SqlConnection();
        List<Usuario> usuarios = new List<Usuario>();
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
                           Usuario usuario = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));  // instancia
                           usuarios.Add(usuario);
                        }

                }
            }
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            return usuarios;
        }
        finally
        {
            Conn.Close();
            Conn.Dispose();
        }

        return usuarios;
    }
}
}


