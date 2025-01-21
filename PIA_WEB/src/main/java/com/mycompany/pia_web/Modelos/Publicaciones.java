/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package com.mycompany.pia_web.Modelos;

import java.util.Date;

/**
 *
 * @author pablo
 */
public class Publicaciones {
    private int idpubli;
    private String Titulo;
    private String Desc;
    private Date crea;
    private Date mod;
    private boolean estado = false;
    private String img;
      private String cat;
    private int us_fk;

    public Publicaciones(String Titulo, String Desc, Date crea, boolean estado, String img, int us_fk) {
        this.Titulo = Titulo;
        this.Desc = Desc;
        this.crea = crea;
        this.estado = estado;
        this.img = img;
        this.us_fk = us_fk;
    }

    public String getCat() {
        return cat;
    }

    public void setCat(String cat) {
        this.cat = cat;
    }

    public Publicaciones() {
    }

    public int getIdpubli() {
        return idpubli;
    }

    public void setIdpubli(int idpubli) {
        this.idpubli = idpubli;
    }
    

    public String getTitulo() {
        return Titulo;
    }

    public void setTitulo(String Titulo) {
        this.Titulo = Titulo;
    }

    public String getDesc() {
        return Desc;
    }

    public void setDesc(String Desc) {
        this.Desc = Desc;
    }

    public Date getCrea() {
        return crea;
    }

    public void setCrea(Date crea) {
        this.crea = crea;
    }

    public Date getMod() {
        return mod;
    }

    public void setMod(Date mod) {
        this.mod = mod;
    }

    public boolean isEstado() {
        return estado;
    }

    public void setEstado(boolean estado) {
        this.estado = estado;
    }

    public String getImg() {
        return img;
    }

    public void setImg(String img) {
        this.img = img;
    }

    public int getUs_fk() {
        return us_fk;
    }

    public void setUs_fk(int us_fk) {
        this.us_fk = us_fk;
    }
    
    
    
    
}
