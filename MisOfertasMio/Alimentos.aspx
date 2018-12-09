<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alimentos.aspx.cs" Inherits="MisOfertasMio.Alimentos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Alimentos - MisOfertas</title>

    <link href="Estilos/estiloHome.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/popper.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <script>
        function valida(e) {
            tecla = (document.all) ? e.keyCode : e.which;

            //Tecla de retroceso para borrar, siempre la permite
            if (tecla == 8) {
                return true;
            }

            // Patron de entrada, en este caso solo acepta numeros
            patron = /[0-9]/;
            tecla_final = String.fromCharCode(tecla);
            return patron.test(tecla_final);
        }
    </script>
    <script>
        void cerrarSesion() {
            Session.Clear();
            Session["user"] = null;
            Response.Redirect("Home.aspx");
        }
    </script>

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

    <br />
    <br />
    <br />

    <form id="form1" runat="server">
        <div>

            <center>
                <br />
            <font color="black"><h1 >ALIMENTOS PARA USTED</h1></font>
                <hr style="width:80%; height: 3px; background: #0066CC; color:#0066CC; opacity:0.8;"/>
            <div class="row" style="text-align:center; max-width:90%;">
                <% 
            var max = totalOfertas();

            foreach(var x in max)
            {

                traerOferta(x.ID);
                    string idEnUso = ""+x.ID;
                %>
                <div style="margin:auto;">
                <div class="card text-dark bg-primery mb-3" style="max-width: 18rem; opacity: 0.95; width: 300px; height:450px;">
                    <center><asp:Image ID="imaOferta" runat="server" CssClass="card-img" Height="200px" Width="90%" ImageAlign="Middle"></asp:Image></center>
                    <div class="card-header">
                        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                        <asp:Label ID="lblTitulo" runat="server" Text="TITULO DE LA OFERTA"></asp:Label>
                    </div>
                    <div class="card-body">
                        <h5 class="card-title">
                            <asp:Label ID="lblDescripcion" runat="server" Text="DESCRIPCION DE LA OFERTA" Font-Size="Medium"></asp:Label></h5>
                        <p class="card-text">
                            <asp:Label ID="lblNormal" runat="server" Text="PRECIO NORMAL" ForeColor="Red" Font-Strikeout="True" Font-Size="Small"></asp:Label>
                            <br />
                            <asp:Label ID="lblOferta" runat="server" Text="PRECIO OFERTA" ForeColor="Green"></asp:Label>
                            <h4><a href="DetalleOferta.aspx?id=<%= idEnUso %>" class="btn  btn-primary" style="width:80%"> Ver Detalle </a></h4>
                        </p>
                    </div>
                </div>
                </div>
                <%
            } %>
            </div>

        </center>

        </div>
    </form>
</body>
</html>
