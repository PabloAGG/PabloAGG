<%-- 
    Document   : Perfil
    Created on : 8 oct 2024, 6:37:23 p.m.
    Author     : pablo
--%>

<%@page import="com.mycompany.pia_web.Modelos.Publicaciones"%>
<%@page import="java.util.List"%>
<%@page import="java.util.List"%>
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
    <title>Mi Perfil</title>
    <link rel="stylesheet" href="css/bootstrap.css">
    <link rel="stylesheet" href="css/estiloslog.css">
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
                  
                  
                  <div class="contenedor_principal">
<div class="BusqAv">
    <img src=<%=url%> alt="" class="img-cirUs">
    <ul>
       
        <li><strong>Nombre Usuario:</strong> <%=usuario.getUsname()%> </li>
        <li><strong>Nombre:</strong> <%=usuario.getNoms()%> <%=usuario.getAps()%></li>
        <li><strong>Correo:</strong> <%=usuario.getCorreo()%></li>
        
        <script>
    // Formatear la fecha a YYYY-MM-DD en el servidor antes de pasarla a JavaScript
    var fechaNacimiento = "<%= new java.text.SimpleDateFormat("yyyy-MM-dd").format(usuario.getNac()) %>";

    function calcularEdad(fechaNacimiento) {
        var hoy = new Date();
        var nacimiento = new Date(fechaNacimiento);
        
        var edad = hoy.getFullYear() - nacimiento.getFullYear();
        var mes = hoy.getMonth() - nacimiento.getMonth();
        
        if (mes < 0 || (mes === 0 && hoy.getDate() < nacimiento.getDate())) {
            edad--;
        }

        return edad;
    }

    // Mostrar la edad calculada
    var edadUsuario = calcularEdad(fechaNacimiento);
    document.getElementById("edadUsuario").innerint = edadUsuario;
    </script>
         <li><strong>Edad:</strong> <h6 id="edadUsuario"></h6></li>
     
      
       
    </ul>
    <button class="btnMod"><a class="edi" href="Edit.jsp">Modificar datos</a></button>
 <% String mensaje = (String) request.getAttribute("mensaje"); %>
<% if (mensaje != null) { %>
    <script>
        alert("<%= mensaje %>");
    </script>
<% } %>
</div>
<%List<Publicaciones> listaPublicaciones =(List) request.getAttribute("ListaPublicaciones");%>
<div class="contenedor_publi">
<label for="flistpub">Mis Publicaciones</label><br>
<form action="ModificarPubliServlet" method="post">
<ul class="list-group">
 <% if(listaPublicaciones!=null)
            for(Publicaciones item : listaPublicaciones){     %>
          
            <li class="list-group-item">
                <input class="form-check-input me-1" type="radio" name="PubliT" value=<%=item.getIdpubli()%>>
            <%=item.getTitulo() %>
     
            </li>
               <% }     %>      
</ul>
   
<button class="btnReg" type="submit">Modificar</button>
</form>
<div class="Paginas">
           <nav aria-label="Paginacion">
  <ul id="paginacionPublicaciones" class="pagination"> </ul>
</nav>
</div>


</div>
</div>
<script src="js/Publicaciones.js"></script>

        <div class="Footer">
            <p id="datos">DEVWEB<br>Pablo Garcia 2006335 Gpo 54<br>Jorge Rodriguez 2007179 Gpo 53</p>
        </div>

</body>
</html>
