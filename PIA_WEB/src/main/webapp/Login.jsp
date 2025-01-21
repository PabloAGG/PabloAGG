<%-- 
    Document   : Login
    Created on : 8 oct 2024, 6:33:22 p.m.
    Author     : pablo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Inicio Sesion</title>
    <link rel="stylesheet" href="css/estiloslog.css">
</head>
<body class="cuerpo">
    <div class="web">
    <img src="LOGOWEB.jpg" width="60px" height="60px">   <h6 id="titulo">DEVWEB</h6>
    </div>
    <div class="contenedor">
        <div class="contenedor_login">
                    
            <!--Login-->
            <form id="formLogin" action="LoginServlet" method="get" class="form__log">
                <h2 id="IS">Iniciar Sesión</h2>
                <label for="fname">Usuario:</label><br>
                <input class="inputLogin" type="text" id="fusuario" name="fusuario" placeholder="Nombre de Usuario"><br>
                <label for="lname">Contraseña:</label><br>
                <input class="inputLogin" type="password" id="fcontra" name="fcontra" placeholder="Contraseña"><br>
                <button class="btnlogin" >Entrar</button>
                </form>
            <% String error = (String) request.getAttribute("error"); %>
<% if (error != null) { %>
    <script>
        alert("<%= error %>");
    </script>
<% } %>
   <% String mensaje = (String) request.getAttribute("mensaje"); %>
<% if (mensaje != null) { %>
    <script>
        alert("<%= mensaje %>");
    </script>
<% } %>

        </div>

        <div class="Contenedor_regus">
            <p>¿Aún no tienes una cuenta?<br>
            ¡Registrarse es gratis!</p><br>
            <button class="btnReg" ><a class="regUs"  href="Registro.jsp">Registrate!</a></button>

        </div>
    </div>

    <div class="Footer">
        <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
    </div>
</body>
</html>
