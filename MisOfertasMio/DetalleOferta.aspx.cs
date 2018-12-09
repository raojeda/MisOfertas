using DALCmisofertas;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MisOfertasMio
{
    public partial class DetalleOferta : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string idofer = Request.QueryString["id"];
            verOferta(Convert.ToInt32(idofer));
            

            if (Session["user"] != null)
            {
                string rut = Session["user"].ToString();
                mostrarUsuario();
                registrarVisita(idofer, rut);
            }

            

        }

        public void verOferta(int i)
        {
            OFERTA of = new OFERTA();
            string retail = "";
            var consulta = from c in Conexion.Entities.OFERTA
                           where c.ID == i
                           select c;

            foreach (var x in consulta)
            {
                of.ID = x.ID;
                of.TITULO = x.TITULO;
                of.DESCRIPCION = x.DESCRIPCION;
                of.FECHA_INICIO = x.FECHA_INICIO;
                of.FECHA_TERMINO = x.FECHA_TERMINO;
                of.PRECIO_NORMAL = x.PRECIO_NORMAL;
                of.PRECIO_OFERTA = x.PRECIO_OFERTA;
                of.COMPRA_MIN = x.COMPRA_MIN;
                of.COMPRA_MAX = x.COMPRA_MAX;
                of.ACTIVA = x.ACTIVA;
                of.ENCARGADO_RUN = x.ENCARGADO_RUN;
                retail = x.ENCARGADO.RETAIL.RAZON_SOCIAL;
                imaOfer.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(x.IMAGEN);
            }

            txtId.Text = "" + of.ID;
            txtTitulo.Text = of.TITULO;
            txtDescrip.Text = of.DESCRIPCION;
            txtFechaI.Text = "" + of.FECHA_INICIO.ToString("dd/MM/yyyy");
            txtFechaT.Text = "" + of.FECHA_TERMINO.ToString("dd/MM/yyyy");
            txtPrecioNormal.Text = of.PRECIO_NORMAL.ToString("C");
            txtPrecioOf.Text = of.PRECIO_OFERTA.ToString("C");
            txtCmin.Text = "" + of.COMPRA_MIN;
            txtCMax.Text = "" + of.COMPRA_MAX;
            txtRetail.Text = retail;
        }

        protected void btnEnviarEvaluacion_Click(object sender, EventArgs e)
        {

            HttpPostedFile imagenSubida = ImagenEva.PostedFile;
            string nombreArchivo = Path.GetFileName(imagenSubida.FileName);
            string nombreExtencion = Path.GetExtension(nombreArchivo);
            int tamaanoArchivo = imagenSubida.ContentLength;
            if (nombreExtencion.ToLower() == ".jpg" || nombreExtencion.ToLower() == ".bpm"
                || nombreExtencion.ToLower() == ".gif" || nombreExtencion.ToLower() == ".png")
            {
                Byte[] byteImage = new Byte[tamaanoArchivo];
                imagenSubida.InputStream.Read(byteImage, 0, tamaanoArchivo);

                string fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
                string comentario = txtComentario.Text.ToString();

                if(comentario != "")
                {
                    EVALUACION ev = new EVALUACION();

                    var consultaEV = (from cu in Conexion.Entities.EVALUACION
                                     select cu.ID).Max();

                    decimal ultimoIDEV = Convert.ToDecimal(consultaEV);

                    if (ultimoIDEV == 0)
                    {
                        ultimoIDEV = 1;
                    }

                    ev.ID = ultimoIDEV + 1;
                    ev.FECHA_COMPRA = Convert.ToDateTime(fechaHoy);
                    ev.IMAGEN = byteImage;
                    ev.COMENTARIO = comentario;

                    Conexion.Entities.EVALUACION.Add(ev);

                    string escala = ddlEscala.SelectedItem.Text;

                    VALORACION va = new VALORACION();

                    var consultaVA = (from cu in Conexion.Entities.VALORACION
                                     select cu.ID).Max();

                    decimal ultimoIDVA = Convert.ToDecimal(consultaVA);

                    if (ultimoIDVA == 0)
                    {
                        ultimoIDVA = 1;
                    }

                    va.ID = ultimoIDVA + 1;
                    va.ESCALA = escala;
                    va.EVALUACION_ID = ultimoIDEV;
                    va.CONSUMIDOR_RUN = Session["user"].ToString();
                    va.OFERTA_ID = Convert.ToDecimal(Session["idOferta"].ToString());

                    Conexion.Entities.VALORACION.Add(va);

                    // Sumar 10 puntos por evaluacion subida.

                    string rut = Session["user"].ToString();
                    decimal anterior = 0;

                    using (var context = new EntitiesMO())

                    {
                        var nuevoPuntaje = context.CONSUMIDOR.Find(rut);
                        anterior = nuevoPuntaje.PUNTAJE;
                        context.CONSUMIDOR.Attach(nuevoPuntaje);
                        nuevoPuntaje.PUNTAJE = anterior + 10;
                        context.Configuration.ValidateOnSaveEnabled = false;
                        context.SaveChanges();
                    }

                    lblMensaje.Text = "Evaluación guardada correctamente. <br/> ¡Haz ganado 10 puntos!";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "Debe escribir un comentario.";
                }
                

            }
            else
            {
                lblMensaje.Text = "Suba una imagen por favor.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

        }

        public void mostrarUsuario()
        {
            CONSUMIDOR of = new CONSUMIDOR();

            string id = Session["user"].ToString();

            var consulta = from c in Conexion.Entities.CONSUMIDOR
                           where c.RUN == id
                           select c;

            foreach (var x in consulta)
            {
                of.RUN = x.RUN;
                of.P_NOMBRE = x.P_NOMBRE;
                of.APELLIDO_P = x.APELLIDO_P;
                of.PUNTAJE = x.PUNTAJE;
            }

            lblUsuario.Text = "Bienvenido: " + of.P_NOMBRE + " " + of.APELLIDO_P;
            lblUsuario.ForeColor = System.Drawing.Color.White;
        }

        public void registrarVisita(string idofer, string rut)
        {
            COMPORTAMIENTO_BI bi = new COMPORTAMIENTO_BI();


            decimal idOf = Convert.ToDecimal(idofer);
            var consulta = Conexion.Entities.COMPORTAMIENTO_BI.Find(idOf);
            decimal anterior = 0;

            if(consulta == null)
            {
                bi.IDBI = Convert.ToDecimal(idofer);
                bi.ID_OFERTA = Convert.ToDecimal(idofer);
                bi.RUT_CONSUMIDOR = rut;
                bi.CANT_ACCESOS = 1;
                Conexion.Entities.COMPORTAMIENTO_BI.Add(bi);
                Conexion.Entities.SaveChanges();
            }
            else
            {
                anterior = consulta.CANT_ACCESOS;
                Conexion.Entities.COMPORTAMIENTO_BI.Attach(consulta);
                consulta.CANT_ACCESOS = anterior + 1;
                Conexion.Entities.Configuration.ValidateOnSaveEnabled = false;
                Conexion.Entities.SaveChanges();
            }

        }

    }
}