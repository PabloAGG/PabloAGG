/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.pia_web.DAO;
import com.mycompany.pia_web.Modelos.Usuarios;

import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
/**
 *
 * @author pablo
 */
public class UsuarioDAO {
    Connection conn;

    public UsuarioDAO(Connection conn) {
        this.conn = conn;
    } 
    public boolean bajaUsuario(Usuarios usuario){
    PreparedStatement ps=null;
    try{
    
    ps=conn.prepareStatement("Update Usuarios set estado=1 where idUsuario=(?)");
    ps.setInt(1,usuario.getIdUsu());
  
       int Baja=ps.executeUpdate();
     if(Baja!=0){
        return true;
        }else{
        return false;
        }
    }catch(SQLException ex){
        return false;
        }
    }
    
    public boolean updateUsuario(Usuarios usuario){
    PreparedStatement ps=null;
    try{
    
    ps=conn.prepareStatement("Update Usuarios set imagen=(?),contra=(?),correo=(?),nacimiento=(?),fechaM=curdate(),nom=(?),apellidos=(?)where idUsuario=(?)");
            ps.setString(1, usuario.getImg());
        ps.setString(2, usuario.getContra());
        ps.setString(3, usuario.getCorreo());
       java.sql.Date sqlFechaNacimiento = new java.sql.Date(usuario.getNac().getTime());
       ps.setDate(4, sqlFechaNacimiento);
        ps.setString(5, usuario.getNoms());
        ps.setString(6, usuario.getAps());
        ps.setInt(7, usuario.getIdUsu());
     
        
        int update=ps.executeUpdate();
        
        if(update!=0){
        return true;
        }else{
        return false;
        }
        
    }catch(SQLException ex){
        return false;
        }
    }
    
    public boolean insertUsuario(Usuarios usuario){
    
        PreparedStatement ps=null;
        
        try{
             //cada "?" es un valor almacenado en el modelo.
        ps = conn.prepareStatement("Insert Into Usuarios(imagen,nomUs,contra,correo,nacimiento,fechaC,fechaM,nom,apellidos) Values (?,?,?,?,?,curdate(),curdate(),?,?)");
        
        //Esos valores se llenan por medio del siguiente metodo y el primer argumento que se pide es la posicion del "?"
        //contando de izquierda a derecha, se tiene que espesificar que tipo de dato se va almacenar, ejemplo: setString, int setInt,etc.
        ps.setString(1, usuario.getImg());
        ps.setString(2, usuario.getUsname());
        ps.setString(3, usuario.getContra());
        ps.setString(4, usuario.getCorreo());
       java.sql.Date sqlFechaNacimiento = new java.sql.Date(usuario.getNac().getTime());
       ps.setDate(5, sqlFechaNacimiento);
        ps.setString(6, usuario.getNoms());
        ps.setString(7, usuario.getAps());
        
        int insert = ps.executeUpdate();
        
        if(insert!=0){
        
            return true;
        
        }else{
        
            return false;
        
        }
        }catch(SQLException ex){
        return false;
        }
        
    }
     public Usuarios getUsuario(String nombreUsuario,String password){
      PreparedStatement ps=null;
        Usuarios usuario = null;
        try{
        ps = conn.prepareStatement("Select * From Usuarios where nomUs=(?) and contra=(?) and estado=0" );
        ps.setString(1, nombreUsuario);
        ps.setString(2, password);
        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       usuario = new Usuarios();
       usuario.setIdUsu(rs.getInt("idUsuario"));
       usuario.setUsname(rs.getString("nomUs"));
       usuario.setContra(rs.getString("contra"));
      usuario.setAps(rs.getString("apellidos"));
      usuario.setCorreo(rs.getString("correo"));
     usuario.setNoms(rs.getString("nom"));
     usuario.setImg(rs.getString("Imagen"));
     usuario.setNac(new java.util.Date(rs.getDate("nacimiento").getTime()));
      
       }
        }catch(SQLException ex){
        
        }
        return usuario;
    }
    
}
