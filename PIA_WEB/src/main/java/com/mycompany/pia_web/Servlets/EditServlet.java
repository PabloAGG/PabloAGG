/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package com.mycompany.pia_web.Servlets;
import com.mycompany.pia_web.Clases.Conexion;
import com.mycompany.pia_web.DAO.UsuarioDAO;
import com.mycompany.pia_web.Modelos.Usuarios;

import java.io.IOException;
import java.io.PrintWriter;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.MultipartConfig;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import jakarta.servlet.http.Part;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author migue
 */
@WebServlet(name = "EditServlet", urlPatterns = {"/EditServlet"})
@MultipartConfig
public class EditServlet extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        try (PrintWriter out = response.getWriter()) {
            /* TODO output your page here. You may use following sample code. */
            out.println("<!DOCTYPE html>");
            out.println("<html>");
            out.println("<head>");
            out.println("<title>Servlet EditServlet</title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet EditServlet at " + request.getContextPath() + "</h1>");
            out.println("</body>");
            out.println("</html>");
        }
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
           HttpSession session = request.getSession();
           Usuarios usuario = (Usuarios) session.getAttribute("Usuario");
  int id=usuario.getIdUsu();
         String contra =request.getParameter("fpass");
          String correo =request.getParameter("fcorreo");
         String nombres =request.getParameter("fnombres");
          String apellidos =request.getParameter("fape");
          Part img = request.getPart("fimg");
            final String fileName = usuario.getUsname()+".jpg";
            img.write("C:\\Users\\migue\\Documents\\NetBeansProjects\\PIA_WEB\\src\\main\\webapp\\Imagenes\\Usuarios"+fileName);
          
            SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
        String text_fechaNacimiento = request.getParameter("fnac");
        Date fecha_Nacimiento = null;
        
        try {
        fecha_Nacimiento = dateFormat.parse(text_fechaNacimiento);
        }catch(Exception e) {
          System.out.println("Error occurred"+ e.getMessage());
        }
        if (contra == null || correo == null || nombres == null || apellidos == null || img == null|| fecha_Nacimiento==null) { 
        request.setAttribute("errorM", "Todos los campos son obligatorios.");
        request.getRequestDispatcher("/Edit.jsp").forward(request, response);
        return;
        }
        try {
            
           //Se crea un objeto del modelo para despues llenarlo con los datos capturados
           Usuarios usuario1 = new Usuarios();
     usuario1.setIdUsu(id);
           usuario1.setContra(contra);
           usuario1.setCorreo(correo);
           usuario1.setNoms(nombres);
           usuario1.setAps(apellidos);
            usuario1.setImg(fileName);
           usuario1.setNac(fecha_Nacimiento);
           
       
        Conexion conn =  new Conexion();
         
   
            UsuarioDAO uDao = new UsuarioDAO(conn.Conectar());
                
         
           boolean update = uDao.updateUsuario(usuario1);

            if(update)
            {
                //Metodo para redireccionar a otra vista/Servlet
                request.setAttribute("mensaje", "Usuario Modificado Correctamente");
                request.getRequestDispatcher("/PerfilServlet").forward(request, response);
                
            }else{request.setAttribute("errorM", "Intentelo Nuevamente");
            request.getRequestDispatcher("/Edit.jsp").forward(request, response);}
            //Terminamos la conexion
            conn.Desconectar();
            
            
            
        } catch (SQLException ex) {
            Logger.getLogger(LoginServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(LoginServlet.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
