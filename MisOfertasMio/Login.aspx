<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MisOfertasMio.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesión - MisOfertas</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Estilos/estiloLogin.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
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
                <a class="btn btn-outline-secondary" href="RegistroConsumidor.aspx">Registrarse</a> &nbsp; 
                <a class="btn btn-outline-primary" href="Login.aspx">Iniciar Sesión</a> 
            </div>
        </div>
    </nav>


    <form id="form1" runat="server">
        <h2>Iniciar Sesión</h2>
        <input type="text" placeholder="&#128100; RUT ej. 11222333-4" name="txtUsuario" id="txtUsuario" runat="server" autofocus />
        <input type="password" placeholder="&#128477; Contraseña" name="txtPass" id="txtPass" runat="server" />
        <h2><asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label></h2>
        <input type="submit" value="Ingresar" runat="server" onserverclick="Ingresar_ServerClick" />
        <input type="submit" value="Registrarse" runat="server" onserverclick="Registrarse_ServerClick" id="registro" />
    </form>
</body>
</html>
