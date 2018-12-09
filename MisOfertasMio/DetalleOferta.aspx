<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleOferta.aspx.cs" Inherits="MisOfertasMio.DetalleOferta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Detalle oferta - MisOfertas</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/popper.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Estilos/estiloDetalleOferta.css" rel="stylesheet" />

</head>

<body>

    <%--Navbar--%>
    <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
        <a class="navbar-brand" href="Home.aspx">MISOFERTAS</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarsExampleDefault">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="Alimentos.aspx">Alimentos<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="Electronica.aspx">Electronica<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="LineaBlanca.aspx">Linea Blanca<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="Vestuario.aspx">Vestuario<span class="sr-only">(current)</span></a>
                </li>
            </ul>
            <div class="form form-inline my-2 my-lg-0">
                <%
                    if(Session["user"] != null){
                    
                %>
                <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label> &nbsp; 
                <a class="btn btn-outline-warning" href="Puntaje.aspx">Mi Puntaje</a> &nbsp; 
                <a class="btn btn-outline-danger" href="Login.aspx">Cerrar Sesion</a>
                <%
                    } else {
                %>
                <a class="btn btn-outline-secondary" href="RegistroConsumidor.aspx">Registrarse</a> &nbsp; 
                <a class="btn btn-outline-primary" href="Login.aspx">Iniciar Sesión</a> 
                <%
                    }
                %>
            </div>
        </div>
    </nav>

    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <h2>Detalle Oferta</h2>

            <center><asp:Image ID="imaOfer" runat="server" Width="40%" Height="200px" ImageAlign="Middle" /></center>

            <div style="width:50%; float:left;">

                <asp:Label ID="lblId" runat="server" Text="N° de oferta: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtId" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblTitulo" runat="server" Text="Titulo: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtTitulo" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblDescrip" runat="server" Text="Descripción: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtDescrip" runat="server" Enabled="false" TextMode="MultiLine" CssClass="MiScroll" ></asp:TextBox>
                <br />
                <asp:Label ID="lblFechaIncio" runat="server" Text="Inicio de oferta: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtFechaI" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblFechaTermino" runat="server" Text="Termino de oferta: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtFechaT" runat="server" Enabled="false"></asp:TextBox>
                <br />
            </div>

            <div style="width:50%; float:left;">
                <asp:Label ID="lblPrecioNorm" runat="server" Text="Precio normal: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtPrecioNormal" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblPrecioOfer" runat="server" Text="Precio oferta: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtPrecioOf" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblCompraMin" runat="server" Text="Minimo a comprar: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtCmin" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblCompraMax" runat="server" Text="Maximo a comprar: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtCMax" runat="server" Enabled="false"></asp:TextBox>
                <br />
                <asp:Label ID="lblRetail" runat="server" Text="Retail: " CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtRetail" runat="server" Enabled="false"></asp:TextBox>
                <br />
            </div>

            <%
                if(txtRetail.Text == "ABCDIN")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/ABCDIN.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "FALABELLA")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/FALABELLA.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "JUMBO")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/JUMBO.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "LA POLAR")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/LA%20POLAR.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "LIDER")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/LIDER.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "PARIS")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/PARIS.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "PROVIMARKET")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/PROVIMARKET.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "RIPLEY")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/RIPLEY.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "SANTA ISABEL")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/SANTA%20ISABEL.png" /></div> 
            <%
            }
            %>
            <%
                if(txtRetail.Text == "TOTTUS")
            {
            %> 
                <div style="text-align:center;"><img src="Imagen/Retail/TOTTUS.png" /></div> 
            <%
            }
            %>
            

            <%
                if(Session["user"] != null){
            %>
            <br />
            <br />
            <hr style="width:100%; height: 3px; background: #0066CC; color:#0066CC; opacity:0.8;"/>
            <h2>VALORACIÓNES</h2>

            <div style="text-align:center;">
                <asp:Label ID="lblEscala" runat="server" Text="Escala: " CssClass="Milbl"></asp:Label>
                <asp:DropDownList ID="ddlEscala" runat="server" CssClass="MiDDL">
                    <asp:ListItem>Excelente</asp:ListItem>
                    <asp:ListItem>Buena</asp:ListItem>
                    <asp:ListItem>Mala</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblComentario" runat="server" Text="Ingresa tu comentario acá" CssClass="Milbl"></asp:Label>
                <asp:TextBox ID="txtComentario" Text="" runat="server" TextMode="multiline" CssClass="MiComentario"/>
                <br />
                <asp:Label ID="lblFoto" runat="server" Text="Boleta de compra: " CssClass="Milbl"></asp:Label>
                <asp:FileUpload ID="ImagenEva" runat="server" CssClass="MiFile" /><br />
                <asp:Button ID="btnEnviarEvaluacion" runat="server" Text="Enviar evaluacion" OnClick="btnEnviarEvaluacion_Click" />
            </div>
            <div style="text-align:center;">
                <h2><asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></h2>
            </div>
            <%
                }
            %>

        </div>
    </form>
</body>
</html>
