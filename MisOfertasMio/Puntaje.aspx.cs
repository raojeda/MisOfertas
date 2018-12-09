using DALCmisofertas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Negocio;
using System;
using System.Linq;
using System.Web;
using System.Drawing;
using Image = iTextSharp.text.Image;
using System.IO;

namespace MisOfertasMio
{
    public partial class pprueba : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["user"] != null)
                {
                    mostrarUsuario();
                    txtPuntaje.Text = "" + obtenerPuntaje();
                    if(Session["puntaje"] != null)
                    {
                        txtPuntaje.Text = Session["puntaje"].ToString();
                    }
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

        protected void btnDescuento1_Click(object sender, EventArgs e)
        {
            decimal punt = Convert.ToDecimal(txtPuntaje.Text);
            string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (punt >= 10)
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(mdoc + @"/descuento.pdf", FileMode.Create));
                doc.Open();

                Paragraph titulo = new Paragraph("CUPÓN DE DESCUENTO", FontFactory.GetFont("arial", 40, 1, BaseColor.DARK_GRAY));
                titulo.Alignment = Element.ALIGN_CENTER;
                Paragraph fecha = new Paragraph("Fecha de emisión: " + DateTime.Now.ToString(), FontFactory.GetFont("arial", 8, 3, BaseColor.DARK_GRAY));
                fecha.Alignment = Element.ALIGN_RIGHT;
                Paragraph descuento = new Paragraph("5% \n", FontFactory.GetFont("arial", 72, 1, BaseColor.DARK_GRAY));
                descuento.Alignment = Element.ALIGN_CENTER;
                Paragraph cuerpo = new Paragraph("Descuento de un 5% en sección de ALIMENTOS con un tope de $100.000 \n ¡Aplicable en todas nuestras tiendas asociadas! \n " +
                "¡GRACIAS POR SU PREFERENCIA! \n\n");
                cuerpo.Alignment = Element.ALIGN_CENTER;
                cuerpo.Font.Size = 20;
                Paragraph piePagina = new Paragraph("\n MisOfertas © 2018", FontFactory.GetFont("arial", 9, 3, BaseColor.DARK_GRAY));
                piePagina.Alignment = Element.ALIGN_CENTER;

                Barcode128 code = new Barcode128();
                code.CodeType = Barcode.CODE128;
                code.Code = Session["user"].ToString();
                Image ima = code.CreateImageWithBarcode(writer.DirectContentUnder, BaseColor.BLACK, BaseColor.BLACK);
                ima.Alignment = Element.ALIGN_CENTER;
                ima.ScalePercent(300);

                doc.Add(fecha);
                doc.Add(titulo);
                doc.Add(descuento);
                doc.Add(cuerpo);
                doc.Add(ima);
                doc.Add(piePagina);

                doc.Close();

                lblMensaje.Text = "Cupón de descuento de 5% generado. \n Guardado en su Escritorio.";
                lblMensaje.ForeColor = Color.Green;

                // Descontar 10 puntos por cupón generado.

                string rut = Session["user"].ToString();
                decimal anterior = 0;

                using (var context = new EntitiesMO())

                {
                    var nuevoPuntaje = context.CONSUMIDOR.Find(rut);
                    anterior = nuevoPuntaje.PUNTAJE;
                    context.CONSUMIDOR.Attach(nuevoPuntaje);
                    nuevoPuntaje.PUNTAJE = anterior - 10;
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                    txtPuntaje.Text = "" + nuevoPuntaje.PUNTAJE;
                    Session["puntaje"] = nuevoPuntaje.PUNTAJE;
                   // Response.AddHeader("REFRESH", "3;URL=Puntaje.aspx");
                }



            }
            else
            {
                lblMensaje.Text = "No posee suficientes puntos.";
                lblMensaje.ForeColor = Color.Red;
            }

        }

        protected void btnDescuento2_Click(object sender, EventArgs e)
        {
            decimal punt = Convert.ToDecimal(txtPuntaje.Text);
            string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (punt >= 110)
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(mdoc + @"/descuento.pdf", FileMode.Create));
                doc.Open();

                Paragraph titulo = new Paragraph("CUPÓN DE DESCUENTO", FontFactory.GetFont("arial", 40, 1, BaseColor.DARK_GRAY));
                titulo.Alignment = Element.ALIGN_CENTER;
                Paragraph fecha = new Paragraph("Fecha de emisión: " + DateTime.Now.ToString(), FontFactory.GetFont("arial", 8, 3, BaseColor.DARK_GRAY));
                fecha.Alignment = Element.ALIGN_RIGHT;
                Paragraph descuento = new Paragraph("10% \n", FontFactory.GetFont("arial", 72, 1, BaseColor.DARK_GRAY));
                descuento.Alignment = Element.ALIGN_CENTER;
                Paragraph cuerpo = new Paragraph("Descuento de un 10% en sección de ALIMENTOS, ELECTRÓNICA o LÍNEA BLANCA con un tope de $150.000 \n¡Aplicable en todas nuestras tiendas asociadas! \n ¡GRACIAS POR SU PREFERENCIA! \n\n");
                cuerpo.Alignment = Element.ALIGN_CENTER;
                cuerpo.Font.Size = 20;
                Paragraph piePagina = new Paragraph("\n MisOfertas © 2018", FontFactory.GetFont("arial", 9, 3, BaseColor.DARK_GRAY));
                piePagina.Alignment = Element.ALIGN_CENTER;

                Barcode128 code = new Barcode128();
                code.CodeType = Barcode.CODE128;
                code.Code = Session["user"].ToString();
                Image ima = code.CreateImageWithBarcode(writer.DirectContentUnder, BaseColor.BLACK, BaseColor.BLACK);
                ima.Alignment = Element.ALIGN_CENTER;
                ima.ScalePercent(300);

                doc.Add(fecha);
                doc.Add(titulo);
                doc.Add(descuento);
                doc.Add(cuerpo);
                doc.Add(ima);
                doc.Add(piePagina);

                doc.Close();

                lblMensaje.Text = "Cupón de descuento de 10% generado. \n Guardado en su Escritorio.";
                lblMensaje.ForeColor = Color.Green;

                // Descontar 10 puntos por cupón generado.

                string rut = Session["user"].ToString();
                decimal anterior = 0;

                using (var context = new EntitiesMO())

                {
                    var nuevoPuntaje = context.CONSUMIDOR.Find(rut);
                    anterior = nuevoPuntaje.PUNTAJE;
                    context.CONSUMIDOR.Attach(nuevoPuntaje);
                    nuevoPuntaje.PUNTAJE = anterior - 110;
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                    txtPuntaje.Text = "" + nuevoPuntaje.PUNTAJE;
                }
            }
            else
            {
                lblMensaje.Text = "No posee suficientes puntos.";
                lblMensaje.ForeColor = Color.Red;
            }
        }

        protected void btnDescuento3_Click(object sender, EventArgs e)
        {
            decimal punt = Convert.ToDecimal(txtPuntaje.Text);
            string mdoc = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (punt >= 510)
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(mdoc + @"/descuento.pdf", FileMode.Create));
                doc.Open();

                Paragraph titulo = new Paragraph("CUPÓN DE DESCUENTO", FontFactory.GetFont("arial", 40, 1, BaseColor.DARK_GRAY));
                titulo.Alignment = Element.ALIGN_CENTER;
                Paragraph fecha = new Paragraph("Fecha de emisión: " + DateTime.Now.ToString(), FontFactory.GetFont("arial", 8, 3, BaseColor.DARK_GRAY));
                fecha.Alignment = Element.ALIGN_RIGHT;
                Paragraph descuento = new Paragraph("15% \n", FontFactory.GetFont("arial", 72, 1, BaseColor.DARK_GRAY));
                descuento.Alignment = Element.ALIGN_CENTER;
                Paragraph cuerpo = new Paragraph("Descuento de un 15% en sección de ALIMENTOS, ELECTRÓNICA, LÍNEA BLANCA o ROPA con un tope de $300.000 \n ¡Aplicable en todas nuestras tiendas asociadas! \n ¡GRACIAS POR SU PREFERENCIA! \n\n");
                cuerpo.Alignment = Element.ALIGN_CENTER;
                cuerpo.Font.Size = 20;
                Paragraph piePagina = new Paragraph("\n MisOfertas © 2018", FontFactory.GetFont("arial", 9, 3, BaseColor.DARK_GRAY));
                piePagina.Alignment = Element.ALIGN_CENTER;

                Barcode128 code = new Barcode128();
                code.CodeType = Barcode.CODE128;
                code.Code = Session["user"].ToString();
                Image ima = code.CreateImageWithBarcode(writer.DirectContentUnder, BaseColor.BLACK, BaseColor.BLACK);
                ima.Alignment = Element.ALIGN_CENTER;
                ima.ScalePercent(300);

                doc.Add(fecha);
                doc.Add(titulo);
                doc.Add(descuento);
                doc.Add(cuerpo);
                doc.Add(ima);
                doc.Add(piePagina);

                doc.Close();

                lblMensaje.Text = "Cupón de descuento de 15% generado. \n Guardado en su Escritorio.";
                lblMensaje.ForeColor = Color.Green;

                // Descontar 10 puntos por cupón generado.

                string rut = Session["user"].ToString();
                decimal anterior = 0;

                using (var context = new EntitiesMO())

                {
                    var nuevoPuntaje = context.CONSUMIDOR.Find(rut);
                    anterior = nuevoPuntaje.PUNTAJE;
                    context.CONSUMIDOR.Attach(nuevoPuntaje);
                    nuevoPuntaje.PUNTAJE = anterior - 510;
                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                    txtPuntaje.Text = "" + nuevoPuntaje.PUNTAJE;
                }
            }
            else
            {
                lblMensaje.Text = "No posee suficientes puntos.";
                lblMensaje.ForeColor = Color.Red;
            }
        }

        public decimal obtenerPuntaje()
        {
            CONSUMIDOR of = new CONSUMIDOR();

            string id = Session["user"].ToString();

            var consulta = from c in Conexion.Entities.CONSUMIDOR
                           where c.RUN == id
                           select c;

            foreach (var x in consulta)
            {
                of.PUNTAJE = x.PUNTAJE;
            }

          

            return of.PUNTAJE;

        }

    }
}
