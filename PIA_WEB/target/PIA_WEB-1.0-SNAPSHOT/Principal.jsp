<%-- 
    Document   : Principal
    Created on : 8 oct 2024, 6:36:24 p.m.
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
    <title>Pagina principal</title>
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

                <p class="usu"><%=usuario.getUsname()%></p> <img src="Imagenes/Usuarios/Usuarios<%=usuario.getImg()%>" alt="" class="img-circular">
                  </div>
        </div>
<%List<Publicaciones> listaPublicaciones =(List) request.getAttribute("ListaPublicaciones");%>
        <div class="Dashb">
            <h2>Publicaciones</h2>
            <ul id="listaPublicaciones">
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
          <br>
           <button  class="creaPubli"><a class="back"  href="Publicacion.jsp">Publicar</a></button>
           <div class="Paginas">
           <nav aria-label="Paginacion">
  <ul id="paginacionPublicaciones" class="pagination"> </ul>
</nav>
</div>
        </div>
      

 <% String mensaje = (String) request.getAttribute("mensajeP"); %>
<% if (mensaje != null) { %>
    <script>
        alert("<%= mensaje %>");
    </script>
<% } %>



 <script src="js/Publicaciones.js"></script>

        <div class="Footer">
            <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
        </div>
</body>
</html>