<%-- 
    Document   : Registro
    Created on : 8 oct 2024, 6:35:51 p.m.
    Author     : pablo
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registrate!</title>
    <link rel="stylesheet" href="css/estiloslog.css">
    
</head>
<body class="cuerpo">
    
    <div class="web">
        <img src="LOGOWEB.jpg" width="60px" height="60px">   <h6 id="titulo">DEVWEB</h6>
        </div>
<div>

</div>

<div class="contenedor_FormReg">
<form class="formRegUs" action="RegistroServlet" method="post" enctype="multipart/form-data">
    <h3>Ingresa tus datos</h3><br>
    <label for="fnombre">Nombre de Usuario:</label>
    <input class="inputReg" type="text" name="fnombre" id="fnombre"  placeholder="Nombre de Usuario"><br>

    <label for="fimg">Foto de Perfil:</label>
    <input class="Rimg" type="file" name="fimg" id="fimg"><br>

    <label for="fnombres">Nombre(s):</label>
    <input class="inputReg" type="text" name="fnombres" id="fnombres"  placeholder="Nombre(s)"><br> 

    <label for="fape">Apellidos:</label>
    <input class="inputReg" type="text" name="fape" id="fape"  placeholder="Apellidos"><br>

    <label for="fcorreo">Correo:</label>
    <input type="email" name="fcorreo" id="fcorreo" placeholder="correo@example.com"><br>

    <label for="fpass">Contraseña:</label>
    <input class="inputReg" type="password" name="fpass" id="fpass" placeholder="Contraseña"><br>
    <label for="fpass"> Confirma tu Contraseña:</label>
    <input class="inputReg" type="password" name="fpassC" id="fpass" placeholder="Contraseña"><br>

    <label for="fnac">Fecha de nacimiento:</label>
    <input type="date" name="fnac" id="fnac"><br>
    <button class="btnlogin" >Registrarme</button><br>
</form>
 <% String errorR= (String) request.getAttribute("errorR"); %>
<% if (errorR != null) { %>
    <script>
        alert("<%= errorR %>");
    </script>
<% } %>
</div>

<div class="Footer">
    <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
</div>
</body>
</html>
