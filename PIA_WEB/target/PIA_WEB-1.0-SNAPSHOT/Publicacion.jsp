<%-- 
    Document   : Publicacion
    Created on : 8 oct 2024, 6:38:22 p.m.
    Author     : pablo
--%>

<%@page import="com.mycompany.pia_web.Modelos.Usuarios"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html lang="en">
<head>
      <% 
    Usuarios usuario = (Usuarios) session.getAttribute("Usuario"); 
  String url="Imagenes/Usuarios/"+usuario.getImg();
%>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Crea una Publicacion</title>
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/estiloslog.css">
</head>
<body  class="cuerpo">

    <div class="web">
        <img src="LOGOWEB.jpg" width="60px" height="60px">   <h6 id="titulo">DEVWEB</h6>
        <div class="identificador2">
            <p class="usu"><%=usuario.getUsname()%></p> <img src= <%=url%> alt="" class="img-circular">
              </div>
        </div>

<div class="EspPub">
   <form class="espPubform" action="PublicarServlet" method="post" >
       <br>
      <label for="fnombre">TITULO:</label>
      <input class="inputReg" type="text" name="titulo" id="fnombre"  placeholder="Titulo" required><br>
   
        <textarea class="form-control" name="descri" placeholder="DESCRIPCION" required></textarea><br>
 

    <label for="fcate">Categorias</label>
    <ul class="list-group">
        <li class="list-group-item">
            <input class="form-check-input me-1" type="radio" name="categoria" value="Fotografia">
            Fotografia
        </li>
        <li class="list-group-item">
            <input class="form-check-input me-1" type="radio" name="categoria" value="Videojuegos">
            Videojuegos
        </li>
        <li class="list-group-item">
            <input class="form-check-input me-1" type="radio" name="categoria" value="Gastronomia">
            Gastronomia
        </li>
        <li class="list-group-item">
            <input class="form-check-input me-1" type="radio" name="categoria" value="Moda">
            Moda
        </li>
        <li class="list-group-item">
            <input class="form-check-input me-1" type="radio" name="categoria" value="Musica">
            Musica
        </li>
    </ul>

    <button class="btnReg" type="submit">Publicar</button>
    <button class="btnReg" type="button"><a class="cancel" href="PrincipalServlet">Cancelar</a></button>
</form>
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