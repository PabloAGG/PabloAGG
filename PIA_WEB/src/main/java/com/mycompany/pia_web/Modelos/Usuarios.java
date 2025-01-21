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
public class Usuarios {
    private int IdUsu;
    private String usname;
    private String noms;
    private String aps;
    private String contra;
    private String img;
    private String correo;
    private boolean Est = false ;
    private Date crea;
    private Date mod;
    private Date Nac;

    public Usuarios(String usname, String noms, String aps, String contra, String img, String correo, Date crea, Date Nac) {
        this.usname = usname;
        this.noms = noms;
        this.aps = aps;
        this.contra = contra;
        this.img = img;
        this.correo = correo;
        this.crea = crea;
        this.Nac = Nac;
    }

    public Usuarios() {
    }
    

    public String getUsname() {
        return usname;
    }

    public void setUsname(String usname) {
        this.usname = usname;
    }

    public String getNoms() {
        return noms;
    }

    public void setNoms(String noms) {
        this.noms = noms;
    }

    public String getAps() {
        return aps;
    }

    public void setAps(String aps) {
        this.aps = aps;
    }

    public String getContra() {
        return contra;
    }

    public void setContra(String contra) {
        this.contra = contra;
    }

    public String getImg() {
        return img;
    }

    public void setImg(String img) {
        this.img = img;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public boolean isEst() {
        return Est;
    }

    public void setEst(boolean Est) {
        this.Est = Est;
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

    public Date getNac() {
        return Nac;
    }

    public void setNac(Date Nac) {
        this.Nac = Nac;
    }

    public int getIdUsu() {
        return IdUsu;
    }

    public void setIdUsu(int IdUsu) {
        this.IdUsu = IdUsu;
    }
    
    
    
}
