using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MisOfertasMio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
            Session["user"] = null;
        }

        protected void Ingresar_ServerClick(object sender, EventArgs e)
        {

            string user = txtUsuario.Value;
            string pass = txtPass.Value;

            var consulta = from c in Conexion.Entities.CONSUMIDOR
                           where c.RUN == user && c.CLAVE == pass && c.ACTIVO == "1"
                           select c;

            if (consulta.SingleOrDefault() != null)
            {
                Session["user"] = user;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lblMensaje.Text = "Formato Erróneo.";
            }

        }

        protected void Registrarse_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("RegistroConsumidor.aspx");
        }

        public string error()
        {
            string error = lblMensaje.Text = "Formato Erróneo.";
            return error;
        }


    }
}