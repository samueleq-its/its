package controller;

import model.Libro;

import java.util.ArrayList;
import java.util.List;

public class Scaffale {

    List<Libro> libri = new ArrayList<>();

    public void addLibro(Libro libro){
        this.libri.add(libro);
    }

    public List<Libro> getLibri(){
        return this.libri;
    }
}
