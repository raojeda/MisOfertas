using DALCmisofertas;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MisOfertasMio
{
    public partial class RegistroConsumidor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                llenarDDLs();
            }
        }

        EntitiesMO ent = new EntitiesMO();

        protected void btn_Registrarse(object sender, EventArgs e)
        {
            CONSUMIDOR co = new CONSUMIDOR();
            string rut = "";
            string verificador = "";

            try
            {
                if (txtRun.Text != "" && txtPrimerNombre.Text != "" && txtSegundoNombre.Text != "" && txtApellidoPaterno.Text != "" && txtApellidoMaterno.Text != "" && txtEmail.Text != "" && txtClave.Value != "")
                {
                    if (!validarRut(txtRun.Text))
                    {
                        lblMensaje2.Text = "Formato de rut incorrecto.";
                        lblMensaje2.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        rut = txtRun.Text;
                        rut = rut.ToUpper();
                        rut = rut.Replace(".", "");
                        rut = rut.Replace("-", "");
                        rut = rut.Substring(0, rut.Length - 1);
                        verificador = rut.Substring(rut.Length - 1, 1);
                        co.RUN = rut + "-" + verificador;
                        co.P_NOMBRE = txtPrimerNombre.Text;
                        co.S_NOMBRE = txtSegundoNombre.Text;
                        co.APELLIDO_P = txtApellidoPaterno.Text;
                        co.APELLIDO_M = txtApellidoMaterno.Text;

                        if (!validarEmail(txtEmail.Text) || txtEmail.Text == "")
                        {
                            lblMensaje2.Text = "Formato de email incorrecto.";
                            lblMensaje2.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {

                            co.EMAIL = txtEmail.Text;
                            co.CLAVE = txtClave.Value;
                            co.PUNTAJE = 0;
                            co.ACTIVO = "1";

                            if (chkSuscrito.Checked)
                            {
                                co.SUSCRITO = "1";
                            }
                            else
                            {
                                co.SUSCRITO = "0";
                            }

                            co.COMUNA_ID = Convert.ToDecimal(ddlComuna.Text);

                            ent.CONSUMIDOR.Add(co);

                            ent.SaveChanges();

                            lblMensaje2.Text = "Cuenta Creada.";
                            lblMensaje2.ForeColor = System.Drawing.Color.Green;
                        }
                    }
                }
                else
                {
                    lblMensaje2.Text = "Se requieren todos los datos por favor.";
                    lblMensaje2.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje2.Text = "RUT de usuario ya registrado";
                lblMensaje2.ForeColor = System.Drawing.Color.Red;
            }



        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        static bool validarEmail(string email)
        {
            try
            {
                new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        protected void RegionSeleccionada(object sender, EventArgs e)
        {

            decimal IDRegion = Convert.ToDecimal(ddlRegion.SelectedValue);

            var comunas = from c in Conexion.Entities.COMUNA
                          where c.REGION_ID == IDRegion
                          select c;

            ddlComuna.DataValueField = "ID";
            ddlComuna.DataTextField = "NOMBRE";
            ddlComuna.DataSource = comunas.ToList();
            ddlComuna.DataBind();

        }

        private void llenarDDLs()
        {
            var regiones = from r in Conexion.Entities.REGION
                           select r;
            ddlRegion.DataValueField = "ID";
            ddlRegion.DataTextField = "NOMBRE";
            ddlRegion.DataSource = regiones.ToList();
            ddlRegion.DataBind();

            decimal IDRegion = Convert.ToDecimal(ddlRegion.SelectedValue);

            var comunas = from c in Conexion.Entities.COMUNA
                          where c.REGION_ID == IDRegion
                          select c;

            ddlComuna.DataValueField = "ID";
            ddlComuna.DataTextField = "NOMBRE";
            ddlComuna.DataSource = comunas.ToList();
            ddlComuna.DataBind();

        }

    }

}