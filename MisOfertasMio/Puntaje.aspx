<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Puntaje.aspx.cs" Inherits="MisOfertasMio.pprueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mi Puntaje - MisOfertas</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.js"></script>
    <script src="Scripts/popper.js"></script>
    <script src="Scripts/bootstrap.js"></script>
    <link href="Estilos/estiloPuntaje.css" rel="stylesheet" />

        <%--Navbar--%>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-style: solid;
            border-width: 1px;
        }
        </style>
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

</head>

<body>

    

    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <form id="form1" runat="server">
        <div>

            <h1 style="text-align:center;"><asp:Label ID="lblPuntaje" runat="server" Text="Puntaje actual: "></asp:Label>
                <asp:Label ID="txtPuntaje" runat="server" Text="" CssClass="text-success" ></asp:Label></h1>

            <br />
            <table align="center" class="auto-style1" style="border-style: groove; border-width: thin; width: 100%; height:250px; text-align: center;">
                <tr style="font-weight:bold; background-color:darkgreen; color:white; padding:5px;">
                    <td>Puntaje</td>
                    <td>Descuento</td>
                    <td>Tope</td>
                    <td>Rubro</td>
                    <td>Generar Descuento</td>
                </tr>
                <tr>
                    <td>10-100</td>
                    <td>5%</td>
                    <td>$100.000</td>
                    <td>Alimentos</td>
                    <td><asp:Button ID="btnDescuento1" runat="server" Text="Descargar" CssClass="btn btn-outline-success" OnClick="btnDescuento1_Click" /></td>
                </tr>
                <tr>
                    <td>110-500</td>
                    <td>10%</td>
                    <td>$150.000</td>
                    <td>Alimentos, Electrónica y Línea Blanca</td>
                    <td><asp:Button ID="btnDescuento2" runat="server" Text="Descargar" CssClass="btn btn-outline-success" OnClick="btnDescuento2_Click" /></td>
                </tr>
                <tr">
                    <td>510-1000</td>
                    <td>15%</td>
                    <td>$300.000</td>
                    <td>Alimentos, Electrónica, Línea Blanca, Ropa</td>
                    <td><asp:Button ID="btnDescuento3" runat="server" Text="Descargar" CssClass="btn btn-outline-success" OnClick="btnDescuento3_Click" /></td>
                </tr>
            </table>

            <br />

            <h3 style="text-align:center;"><asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label></h3>


        </div>
    </form>
</body>
</html>
