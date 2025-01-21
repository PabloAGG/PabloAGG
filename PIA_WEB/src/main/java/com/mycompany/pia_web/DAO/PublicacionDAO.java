/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.pia_web.DAO;

import com.mycompany.pia_web.Modelos.Publicaciones;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;

import java.util.List;

/**
 *
 * @author pablo
 */
public class PublicacionDAO {
    Connection conn;
    
    
        public PublicacionDAO(Connection conn) {
        this.conn = conn;
        }
    
        public boolean InsertPublicacion(Publicaciones publi) throws SQLException{
            PreparedStatement ps=null;
                    try{
                    ps=conn.prepareStatement("Insert into Publicaciones(fechaC,fechaM,titulo,descripcion,idUsuario,categoria) values(curdate(),curdate(),?,?,?,?)");
                    ps.setString(1, publi.getTitulo());
                    ps.setString(2, publi.getDesc());
              
                    ps.setInt(3,publi.getUs_fk());
                     ps.setString(4, publi.getCat()); 
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
        public boolean updatePublicacion(Publicaciones publi){
    PreparedStatement ps=null;
    try{
    
    ps=conn.prepareStatement("Update Publicaciones set fechaM=curdate(),titulo=(?),descripcion=(?),categoria=(?) where idPubli=(?)");
            ps.setString(1, publi.getTitulo());
        ps.setString(2, publi.getDesc());
        ps.setString(3, publi.getCat());
        ps.setInt(4, publi.getIdpubli());
      
     
        
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
        
        
        public boolean deletePublicacion(Publicaciones publi){
    PreparedStatement ps=null;
    try{
    
    ps=conn.prepareStatement("Update Publicaciones set estado=1 where idPubli=(?)");
          
        ps.setInt(1, publi.getIdpubli());
      
     
        
        int delete=ps.executeUpdate();
        
        if(delete!=0){
        return true;
        }else{
        return false;
        }
        
    }catch(SQLException ex){
        return false;
        }
    }
        
        
public List<Publicaciones> getAll(){
    
    List<Publicaciones> listaPubli = new ArrayList<>();
    
    PreparedStatement ps=null;
      
        try{
        ps = conn.prepareStatement("Select * From Publicaciones where estado=0 ");
       
        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       Publicaciones publicacion = new Publicaciones();
       publicacion.setIdpubli(rs.getInt("idPubli"));
       publicacion.setCrea(new java.util.Date(rs.getDate("fechaC").getTime()));
       publicacion.setTitulo(rs.getString("titulo"));
       publicacion.setDesc(rs.getString("descripcion"));
       publicacion.setCat(rs.getString("categoria"));
       publicacion.setUs_fk(rs.getInt("idUsuario"));
       
       
       listaPubli.add(publicacion);
       }
        }catch(SQLException ex){
        
        }
       
    
    return listaPubli;
        
    }


public List<Publicaciones> getPUs(int idUs){
    
    List<Publicaciones> listaPubli = new ArrayList<>();
    
    PreparedStatement ps=null;
      
        try{
        ps = conn.prepareStatement("Select * From Publicaciones where estado=0 and idUsuario=(?)  ");
       ps.setInt(1,idUs);
        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       Publicaciones publicacion = new Publicaciones();
       publicacion.setIdpubli(rs.getInt("idPubli"));
       publicacion.setCrea(new java.util.Date(rs.getDate("fechaC").getTime()));
       publicacion.setTitulo(rs.getString("titulo"));
       publicacion.setDesc(rs.getString("descripcion"));
  
       publicacion.setUs_fk(rs.getInt("idUsuario"));
       
            publicacion.setCat(rs.getString("categoria"));
       listaPubli.add(publicacion);
       }
        }catch(SQLException ex){
        
        }
       
    
    return listaPubli;
        
    }

public List<Publicaciones> BusqP(String busqueda){
    
    List<Publicaciones> listaPubli = new ArrayList<>();
    
    PreparedStatement ps=null;
      
        try{
     ps = conn.prepareStatement("SELECT * FROM Publicaciones WHERE estado=0 AND descripcion LIKE (?)");
ps.setString(1, "%" + busqueda + "%");
        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       Publicaciones publicacion = new Publicaciones();
       publicacion.setIdpubli(rs.getInt("idPubli"));
       publicacion.setCrea(new java.util.Date(rs.getDate("fechaC").getTime()));
       publicacion.setTitulo(rs.getString("titulo"));
       publicacion.setDesc(rs.getString("descripcion"));
       publicacion.setUs_fk(rs.getInt("idUsuario"));
        publicacion.setCat(rs.getString("categoria"));
       
       
       listaPubli.add(publicacion);
       }
        }catch(SQLException ex){
        
        }
       
    
    return listaPubli;
        
    }

public List<Publicaciones> BusqAv(Date min, Date max){
    
    List<Publicaciones> listaPubli = new ArrayList<>();
    
    PreparedStatement ps=null;
      
        try{
     ps = conn.prepareStatement("SELECT * FROM Publicaciones WHERE estado=0 AND fechaC BETWEEN (?) AND (?)");
     java.sql.Date sqlmin = new java.sql.Date(min.getTime());
         java.sql.Date sqlmax = new java.sql.Date(max.getTime());
ps.setDate(1,sqlmin);
ps.setDate(2,sqlmax);
        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       Publicaciones publicacion = new Publicaciones();
       publicacion.setIdpubli(rs.getInt("idPubli"));
       publicacion.setCrea(new java.util.Date(rs.getDate("fechaC").getTime()));
       publicacion.setTitulo(rs.getString("titulo"));
       publicacion.setDesc(rs.getString("descripcion"));
       publicacion.setUs_fk(rs.getInt("idUsuario"));
        publicacion.setCat(rs.getString("categoria"));
       
       
       listaPubli.add(publicacion);
       }
        }catch(SQLException ex){
        
        }
       
    
    return listaPubli;
        
    }

public List<Publicaciones> BusqAv2(Date min, Date max, String categoria){
    
    List<Publicaciones> listaPubli = new ArrayList<>();
    
    PreparedStatement ps=null;
      
        try{
     ps = conn.prepareStatement("SELECT * FROM Publicaciones WHERE estado=0 AND categoria=(2) AND fechaC BETWEEN (?) AND (?)");
     ps.setString(1,categoria);
       java.sql.Date sqlmin = new java.sql.Date(min.getTime());
         java.sql.Date sqlmax = new java.sql.Date(max.getTime());
ps.setDate(2,sqlmin);
ps.setDate(3,sqlmax);
        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       Publicaciones publicacion = new Publicaciones();
       publicacion.setIdpubli(rs.getInt("idPubli"));
       publicacion.setCrea(new java.util.Date(rs.getDate("fechaC").getTime()));
       publicacion.setTitulo(rs.getString("titulo"));
       publicacion.setDesc(rs.getString("descripcion"));
       publicacion.setUs_fk(rs.getInt("idUsuario"));
        publicacion.setCat(rs.getString("categoria"));
       
       
       listaPubli.add(publicacion);
       }
        }catch(SQLException ex){
        
        }
       
    
    return listaPubli;
        
    }

public Publicaciones GetPub(int idP){
      PreparedStatement ps=null;
        Publicaciones publi = null;
        try{
        ps = conn.prepareStatement("Select * From Publicaciones where estado=0 and idPubli=(?)");
        ps.setInt(1, idP);

        
        ResultSet rs = ps.executeQuery();
        
       while(rs.next()){
       publi = new Publicaciones();
       publi.setIdpubli(rs.getInt("idPubli"));
       publi.setTitulo(rs.getString("titulo"));
       publi.setDesc(rs.getString("descripcion"));
      publi.setCat(rs.getString("categoria"));
      
      
       }
        }catch(SQLException ex){
        
        }
        return publi;
    }

}
