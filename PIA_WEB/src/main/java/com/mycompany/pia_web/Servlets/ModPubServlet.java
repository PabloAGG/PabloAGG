/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/JSP_Servlet/Servlet.java to edit this template
 */
package com.mycompany.pia_web.Servlets;

import com.mycompany.pia_web.Clases.Conexion;
import com.mycompany.pia_web.DAO.PublicacionDAO;
import com.mycompany.pia_web.Modelos.Publicaciones;
import java.io.IOException;
import java.io.PrintWriter;
import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import jakarta.servlet.http.HttpSession;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author migue
 */
@WebServlet(name = "ModPubServlet", urlPatterns = {"/ModPubServlet"})
public class ModPubServlet extends HttpServlet {

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
            out.println("<title>Servlet ModPubServlet</title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet ModPubServlet at " + request.getContextPath() + "</h1>");
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
           Publicaciones publi = (Publicaciones) session.getAttribute("Publicacion");
             int idP=publi.getIdpubli();
         String titulo=request.getParameter("titulo");
          String descripcion=request.getParameter("descri");
         String categoria=request.getParameter("categoria");
         
                if (titulo==null||categoria==null||descripcion == null) {
    request.setAttribute("errorP", "Todos los campos son obligatorios.");
        request.getRequestDispatcher("/ModificarPubli.jsp").forward(request, response);
       
        }
            try {
            
           //Se crea un objeto del modelo para despues llenarlo con los datos capturados
           Publicaciones publicacion = new Publicaciones();
           publicacion.setIdpubli(idP);
           publicacion.setTitulo(titulo);
           publicacion.setDesc(descripcion);
           publicacion.setCat(categoria);
            Conexion conn =  new Conexion();
         
   
            PublicacionDAO pDao = new PublicacionDAO(conn.Conectar());
                
         
           boolean insert = pDao.updatePublicacion(publicacion);

            if(insert)
            {
                //Metodo para redireccionar a otra vista/Servle
                request.getRequestDispatcher("/PerfilServlet").forward(request, response);
                }
            else{request.setAttribute("Mensaje", "Intentelo Nuevamente");
            request.getRequestDispatcher("/Perfil.jsp").forward(request, response);
            }
            //Terminamos la conexio
              conn.Desconectar();
            
            
        } catch (SQLException ex) {
            Logger.getLogger(PublicarServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(PublicarServlet.class.getName()).log(Level.SEVERE, null, ex);
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
