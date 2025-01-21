/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.pia_web.Clases;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author pablo
 */
public class Conexion {
     Connection conn;
    String bd="PagWeb1";
    String url = "jdbc:mysql://localhost:3306/";
    String user = "root";
    String password ="contraseñaWeb123";
    String driver = "com.mysql.cj.jdbc.Driver";
    
   
   

    public Conexion() {
        
    }
  
        public Connection Conectar() throws SQLException,ClassNotFoundException{
                  
        try {
            Class.forName(driver);
            conn=DriverManager.getConnection(url+bd,user,password);  
            
        } catch(SQLException ex) {
            Logger.getLogger(Conexion.class.getName()).log(Level.SEVERE, null, ex);
        }
       
        return conn;
        }
        
        public void Desconectar() throws SQLException{
        
        conn.close();
        
        }

    
}
