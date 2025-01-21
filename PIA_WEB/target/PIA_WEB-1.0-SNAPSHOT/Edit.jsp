<%-- 
    Document   : Edit
    Created on : 8 oct 2024, 6:36:56 p.m.
    Author     : pablo
--%>

<%@page import="com.mycompany.pia_web.Modelos.Usuarios"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Modifica tus datos</title>
    <link rel="stylesheet" href="css/estiloslog.css">
    <link rel="stylesheet" href="css/bootstrap.css">
</head>
<script>
        function confirmarEliminacion() {
            // Muestra una alerta de confirmación
            const confirmacion = confirm("¿Estás seguro de que deseas eliminar esta publicación?");
            
            if (confirmacion) {
                window.location.href = "ElimUServlet";
            } else {
                // Acción si el usuario cancela
                alert("Operación cancelada.");
            }
        }
            </script>
<body class="cuerpo">
     <% 
    Usuarios usuario = (Usuarios) session.getAttribute("Usuario"); 
  String url="Imagenes/Usuarios/Usuarios"+usuario.getImg();
%>
    <div class="web">
        <img src="LOGOWEB.jpg" width="60px" height="60px">   <h6 id="titulo">DEVWEB</h6>
       <div class="barrPrin">
        <button class="btnBarr" ><a class="nav-link "  href="PrincipalServlet">Inicio</a></button>
        <button class="btnBarr" > <a class="nav-link" href="PerfilServlet">Perfil</a></button>
            <button class="btnBarr" ><a class="nav-link" href="EditData.jsp">Editar datos</a></button>
                <button class="btnBarr" ><a class="nav-link" href="Login.jsp">Cerrar sesion</a></button>
           </div>
                <form class="d-flex" action="BusqServlet" method="post">
                    <input class="BarrBusq" type="search" name="Busq" id="Busq" placeholder="Buscar" aria-label="Search">
                    <button class="btn btn-outline-success" type="submit">Buscar</button>
                  </form>
                  <div class="identificador">

                <p class="usu"><%=usuario.getUsname()%></p> <img src=<%=url%> alt="" class="img-circular">
                  </div>
        </div>
    

<div class="contenedor_FormReg">
<form class="formRegUs" action="EditServlet" method="post" enctype="multipart/form-data">
    <h3>Tus datos</h3><br>
    <label for="fimg">Foto de Perfil:</label>
    <input class="Rimg" type="file" name="fimg" id="fimg"><br>

    <label for="fnombres">Nombre(s):</label>
    <input class="inputReg" type="text" name="fnombres" id="fnombres"  value=<%=usuario.getNoms()%> ><br> 

    <label for="fape">Apellidos:</label>
    <input class="inputReg" type="text" name="fape" id="fape"  value=<%=usuario.getAps()%>><br>

    <label for="fcorreo">Correo:</label>
    <input type="email" name="fcorreo" id="fcorreo" value=<%=usuario.getCorreo()%> ><br>

    <label for="fpass">Contraseña:</label>
    <input class="inputReg" type="password" name="fpass" id="fpass" value=<%=usuario.getContra()%> ><br>

    <label for="fnac">Fecha de nacimiento:</label>
    <input type="date" name="fnac" id="fnac"><br>
    
    <button class="btnlogin" type="submit">Modificar</button>  <button class="btnback" ><a class="back"  href="PerfilServlet">Regresar</a></button>
 
         <% String error = (String) request.getAttribute("errorM"); %>
<% if (error != null) { %>
    <script>
        alert("<%= error %>");
    </script>
<% } %>
</form>
   <button class="btnback" onclick="confirmarEliminacion()">Eliminar</button>
</div>

<div class="Footer">
    <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
</div>
</body>
</html>