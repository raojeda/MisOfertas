﻿using DALCmisofertas;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MisOfertasMio
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                mostrarUsuario();
            }
            
        }

        public void traerOferta(decimal i)
        {
            OFERTA of = new OFERTA();

            var consulta = from c in Conexion.Entities.OFERTA
                           where c.ID == i && c.ACTIVA == "1"
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
                imaOferta.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(x.IMAGEN);
            }
            
            lblID.Text = "N° " + of.ID + " | ";
            lblTitulo.Text = of.TITULO;
            lblDescripcion.Text = of.DESCRIPCION;
            lblNormal.Text = "Precio normal: " + of.PRECIO_NORMAL.ToString("C");
            lblOferta.Text = "Precio oferta: " + of.PRECIO_OFERTA.ToString("C");

        }

        public dynamic totalOfertas()
        {
            var consulta = from c in Conexion.Entities.OFERTA
                           where c.ACTIVA == "1"
                           orderby c.ID
                           select c;

            return consulta;
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

    }
}