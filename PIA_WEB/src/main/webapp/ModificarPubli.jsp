<%-- 
    Document   : ModificarPubli
    Created on : 27 nov 2024, 9:22:58 p.m.
    Author     : migue
--%>

<%@page import="com.mycompany.pia_web.Modelos.Publicaciones"%>
<%@page import="com.mycompany.pia_web.Modelos.Usuarios"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="en">
<head>
      <% 
    Usuarios usuario = (Usuarios) session.getAttribute("Usuario"); 
    Publicaciones publi=(Publicaciones) session.getAttribute("Publicacion");
  String url="Imagenes/Usuarios/Usuarios"+usuario.getImg();
%>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Modifica una Publicacion</title>
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/estiloslog.css">
</head>
<script>
        function confirmarEliminacion() {
            // Muestra una alerta de confirmación
            const confirmacion = confirm("¿Estás seguro de que deseas eliminar esta publicación?");
            
            if (confirmacion) {
                window.location.href = "ElimPubServley";
            } else {
                // Acción si el usuario cancela
                alert("Operación cancelada.");
            }
        }
            </script>
<body  class="cuerpo">

    <div class="web">
        <img src="LOGOWEB.jpg" width="60px" height="60px">   <h6 id="titulo">DEVWEB</h6>
        <div class="identificador2">
            <p class="usu"><%=usuario.getUsname()%></p> <img src= <%=url%> alt="" class="img-circular">
              </div>
        </div>

<div class="EspPub">
   <form class="espPubform" action="ModPubServlet" method="post" enctype="multipart/form-data">
        <br>
      <label for="fnombre">TITULO:</label>
      <input class="inputReg" type="text" name="titulo" id="fnombre"  value=<%=publi.getTitulo()  %> ><br>
   
     <label for="fnombre">Descripcion:</label>
      <input class="inputReg" type="text" name="descri" id="fnombre"  value=<%=publi.getDesc()  %> ><br>
   
    <label for="fcate">Categorias</label>
    <ul class="list-group">
     <li class="list-group-item">
    <input class="form-check-input me-1" type="radio" name="categoria" value="Fotografia" 
           <%= "Fotografia".equals(publi.getCat()) ? "checked" : "" %>>
    Fotografia
</li>
<li class="list-group-item">
    <input class="form-check-input me-1" type="radio" name="categoria" value="Videojuegos"
           <%= "Videojuegos".equals(publi.getCat()) ? "checked" : "" %>>
    Videojuegos
</li>
<li class="list-group-item">
    <input class="form-check-input me-1" type="radio" name="categoria" value="Gastronomia"
           <%= "Gastronomia".equals(publi.getCat()) ? "checked" : "" %>>
    Gastronomia
</li>
<li class="list-group-item">
    <input class="form-check-input me-1" type="radio" name="categoria" value="Moda"
           <%= "Moda".equals(publi.getCat()) ? "checked" : "" %>>
    Moda
</li>
<li class="list-group-item">
    <input class="form-check-input me-1" type="radio" name="categoria" value="Musica"
           <%= "Musica".equals(publi.getCat()) ? "checked" : "" %>>
    Musica
</li>

    </ul>

    <button class="btnReg" type="submit">Modificar</button>
      <button class="btnReg" type="button"><a class="cancel" href="PrincipalServlet">Cancelar</a></button>
   </form><br>
     <button class="btnback" onclick="confirmarEliminacion()">Eliminar</button>
  

 <% String errorP= (String) request.getAttribute("errorP"); %>
<% if (errorP != null) { %>
    <script>
        alert("<%= errorP %>");
    </script>
<% } %>
</div>

<div class="Footer">
    <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
</div>

</body>
</html>
