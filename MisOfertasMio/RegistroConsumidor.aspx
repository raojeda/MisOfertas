<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistroConsumidor.aspx.cs" Inherits="MisOfertasMio.RegistroConsumidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registro - MisOfertas</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Estilos/estiloRegistro.css" rel="stylesheet" />

    <%--Navbar--%>
    <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
        <a class="navbar-brand" href="Home.aspx">MISOFERTAS</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false"
        aria-label="Toggle navigation">
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
                <a class="btn btn-outline-secondary" href="RegistroConsumidor.aspx">Registrarse</a> &nbsp; 
                <a class="btn btn-outline-primary" href="Login.aspx">Iniciar Sesión</a> 
            </div>
        </div>
    </nav>

</head>
<body>

    <form id="form1" runat="server">

        <div>
            <br />
            <br />
            <h2>REGISTRO DE USUARIO</h2>


            <asp:Label ID="lblRun" runat="server" Text="RUT" CssClass="Milbl"></asp:Label>
            <asp:TextBox ID="txtRun" runat="server" placeholder="RUT ej. 11222333-4" CssClass="Milbl"></asp:TextBox>

            <asp:Label ID="lblNombres" runat="server" Text="Nombres" CssClass="Milbl"></asp:Label>
            <div style="width: 50%; float: left; padding-right: 5px; padding-bottom: 5px;">
                <asp:TextBox ID="txtPrimerNombre" runat="server" placeholder="Primer Nombre"></asp:TextBox>
            </div>
            <div style="width: 50%; float: right; padding-left: 5px; padding-bottom: 5px;">
                <asp:TextBox ID="txtSegundoNombre" runat="server" placeholder="Segundo Nombre"></asp:TextBox>
            </div>

            <asp:Label ID="lblApellidos" runat="server" Text="Apellidos" CssClass="Milbl"></asp:Label>
            <div style="width: 50%; float: left; padding-right: 5px; padding-bottom: 5px;">
                <asp:TextBox ID="txtApellidoPaterno" runat="server" placeholder="Primer Apellido"></asp:TextBox>
            </div>
            <div style="width: 50%; float: right; padding-left: 5px; padding-bottom: 5px;">
                <asp:TextBox ID="txtApellidoMaterno" runat="server" placeholder="Segundo Apellido"></asp:TextBox>
            </div>

            <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="Milbl"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="tu@correo.com"></asp:TextBox>

            <asp:Label ID="lblPass" runat="server" Text="Contraseña" CssClass="Milbl"></asp:Label>
            <input id="txtClave" type="password" runat="server" placeholder="********" />

            <br />
            <div class="container">
                <asp:Label ID="lblSuscrito" runat="server" Text="¿Suscribirse?" CssClass="MiSuscribir"></asp:Label>
                <br />
            <div class="material-switch pull-right" style="align-content:center; display:flex;">
                
                <input id="chkSuscrito" name="chkSuscrito001" type="checkbox" style="margin:auto;" runat="server" />
                <label for="chkSuscrito" class="label-info" style="margin:auto;" runat="server"></label>
            </div>
            </div>

            <br />

            <asp:Label ID="lblRegionID" runat="server" Text="Región" CssClass="Milbl"></asp:Label>
            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="MiDDL" AutoPostBack="True" OnSelectedIndexChanged="RegionSeleccionada"></asp:DropDownList>

            <asp:Label ID="lblComunaID" runat="server" Text="Comuna" CssClass="Milbl"></asp:Label>
            <asp:DropDownList ID="ddlComuna" runat="server" AutoPostBack="True" CssClass="MiDDL"></asp:DropDownList>

            <br />
            <br />

            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" OnClick="btn_Registrarse" />
            <asp:Label ID="lblMensaje2" runat="server" CssClass="Milbl"></asp:Label>

        </div>
        <div>
            <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" CssClass="btnVolver" />
        </div>
    </form>
</body>
</html>
