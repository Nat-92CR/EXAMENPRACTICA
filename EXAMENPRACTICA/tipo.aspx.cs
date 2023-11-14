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
    public partial class tipo : System.Web.UI.Page
    {
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM tipo"))
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


            int resultado = Clases.tipo.Agregar(tdescripcion.Text);

            if (resultado > 0)
            {
                alertas("Tipo ingresado ha sido ingresado con exito");
                tdescripcion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar tipo");

            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int resultado = Clases.tipo.Borrar(int.Parse(tcodigo.Text));

            if (resultado > 0)
            {
                alertas("Tipo ingresado ha sido ingresado con exito");
                tdescripcion.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                alertas("Error al ingresar tipo");

            }


        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(tcodigo.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TIPO WHERE ID ='" + codigo + "'"))


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
}
