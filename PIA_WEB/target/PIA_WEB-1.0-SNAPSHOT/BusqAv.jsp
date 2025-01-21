<%-- 
    Document   : BusqAv
    Created on : 8 oct 2024, 6:37:08 p.m.
    Author     : pablo
--%>

<%@page import="java.util.List"%>
<%@page import="com.mycompany.pia_web.Modelos.Publicaciones"%>
<%@page import="com.mycompany.pia_web.Modelos.Usuarios"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>

<html lang="en">
<head>
    <% 
    Usuarios usuario = (Usuarios) session.getAttribute("Usuario"); 
  String url="Imagenes/Usuarios/Usuarios"+usuario.getImg();
%>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Busqueda</title>
    <link rel="stylesheet" href="css/estiloslog.css">
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>
<body class="cuerpo">
    
    <div class="web">
        <img src="LOGOWEB.jpg" width="60px" height="60px">   <h6 id="titulo">DEVWEB</h6>
       <div class="barrPrin">
        <button class="btnBarr" ><a class="nav-link "  href="PrincipalServlet">Inicio</a></button>
        <button class="btnBarr" > <a class="nav-link" href="PerfilServlet">Perfil</a></button>
            <button class="btnBarr" ><a class="nav-link" href="BusqAv.jsp"> Busq Av</a></button>
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

<div class="BusqAv">
    <form action="BusqAvServlet" method="post">
        <h4>Por Fechas</h4>
<label for="fechain">Fecha de inicio</label>
<input type="date" name="fechaini" id="fechaini">
<label for="fechafin">Fecha Fin</label>
<input type="date" name="fechafin" id="fechafin">

<h4>Por categorias</h4>
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
<button class="btn btn-outline-success" type="submit">Buscar</button>
</form>
</div>

<%List<Publicaciones> listaPublicaciones =(List) request.getAttribute("ListaPublicaciones");%>
<div class="Dashbusq">
    <h2>Publicaciones</h2>
    <ul>
   <% if(listaPublicaciones!=null)
            for(Publicaciones item : listaPublicaciones){     %>
          
            <li>
                 <div class="card" style="width: 18rem; height: 18rem;">
           
            <div class="card-body">
              <h5 class="card-title"><%=item.getTitulo()%></h5>
              <p class="card-text"><%=item.getDesc()%> </p>
              
            </div>
           
        </div>
            </li>
               <% }     %>   
    </ul>  
    <div class="Paginas">
           <nav aria-label="Paginacion">
  <ul id="paginacionPublicaciones" class="pagination"> </ul>
</nav>
</div>
        </div>
            <% String error = (String) request.getAttribute("error"); %>
<% if (error != null) { %>
    <script>
        alert("<%= error %>");
    </script>
<% } %>
    <!----</div>---!><!-- comment -->
<script src="js/Publicaciones.js"></script>
        <div class="Footer">
            <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
        </div>
</body>
</html>