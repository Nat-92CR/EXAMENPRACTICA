using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EXAMENPRACTICA.Clases;
using System.Drawing;

namespace EXAMENPRACTICA
{
    public partial class Usuario : System.Web.UI.Page
    {
        // Declaración de la variable datagrid
        protected GridView datagrid;

        // Declaración de la variable tnombre
        protected TextBox tnombre;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            datagrid.DataSource = dt;
                            datagrid.DataBind();  // actualizar el grid view
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuario.AGREGAR_USUARIO(tnombre.Text);

            if (resultado > 0)
            {
                alertas("Usuario añadido ha sido ingresado con exito");
                tnombre.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar Usuario");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.Usuario.Borrar(int.Parse(tnombre.Text));

            if (int.TryParse(tnombre.Text, out int UsuarioId))
            {
                if (resultado > 0)
                {
                    alertas("Tipo eliminado con éxito");
                    tnombre.Text = string.Empty;
                    LlenarGrid();
                }
                else
                {
                    alertas("Error al eliminar tipo");
                }
            }
            else
            {
                alertas("Ingrese un valor numérico válido para el código");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tnombre.Text, out int Nombre))
            {
                string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioId = @Nombre"))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", Nombre);
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                datagrid.DataSource = dt;
                                datagrid.DataBind();  // actualizar el grid view
                            }
                        }
                    }
                }
            }
            else
            {
                alertas("Ingrese un valor numérico válido para el código");
            }
        }

        protected void datagrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Código para el evento SelectedIndexChanged del datagrid
        }
    }
}

