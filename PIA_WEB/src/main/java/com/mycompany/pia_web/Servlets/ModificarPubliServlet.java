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
import java.lang.System.Logger;
import java.sql.SQLException;
import java.util.logging.Level;

/**
 *
 * @author migue
 */
@WebServlet(name = "ModificarPubliServlet", urlPatterns = {"/ModificarPubliServlet"})
public class ModificarPubliServlet extends HttpServlet {

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
            out.println("<title>Servlet ModificarPubliServlet</title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<h1>Servlet ModificarPubliServlet at " + request.getContextPath() + "</h1>");
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
String idPString = request.getParameter("PubliT");

int idP = 0;
if (idPString != null) {
    try {
        idP = Integer.parseInt(idPString);
    } catch (NumberFormatException e) {
       
    }
} else {
    request.setAttribute("Mensaje", "Intentalo nuevamente");
                request.getRequestDispatcher("/Perfil.jsp").forward(request, response);
}
try{
         Conexion conn=new Conexion();
          PublicacionDAO pDao = new PublicacionDAO(conn.Conectar());
           Publicaciones publi = pDao.GetPub(idP);

            if(publi!=null)
            {
                request.getSession().setAttribute("Publicacion", publi);
              
                
                 //Metodo para redireccionar a otra vista/Servlet
               // request.setAttribute("MensajeHome", "bienvenido "+usuario.getNombre());
                request.getRequestDispatcher("/ModificarPubli.jsp").forward(request, response);
            }else{
            
                //request.setAttribute("MensajeLogin", "Usuario/Contraseña incorrectos");
                 request.setAttribute("Mensaje", "Intentalo nuevamente");
                request.getRequestDispatcher("/Perfil.jsp").forward(request, response);
            }
            conn.Desconectar();
            
            
            
        } catch (SQLException ex) {
            java.util.logging.Logger.getLogger(LoginServlet.class.getName()).log(Level.SEVERE, null, ex);
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(LoginServlet.class.getName()).log(Level.SEVERE, null, ex);
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
