package com.querio.entities;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Entity
@Table(name = "prodotti_ortofrutticoli")

public class Prodotto {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	int id;
	String nome;
	String categoria;
	String origine;
	double prezzoKg;
	String disponibilita;
	
	public Prodotto() {
		// TODO Auto-generated constructor stub
	}
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getNome() {
		return nome;
	}
	public void setNome(String nome) {
		this.nome = nome;
	}
	public String getCategoria() {
		return categoria;
	}
	public void setCategoria(String categoria) {
		this.categoria = categoria;
	}
	public String getOrigine() {
		return origine;
	}
	public void setOrigine(String origine) {
		this.origine = origine;
	}
	public double getPrezzoKg() {
		return prezzoKg;
	}
	public void setPrezzoKg(double prezzoKg) {
		this.prezzoKg = prezzoKg;
	}
	public String getDisponibilita() {
		return disponibilita;
	}
	public void setDisponibilita(String disponibilita) {
		this.disponibilita = disponibilita;
	}
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder();
		builder.append("Prodotto [id=");
		builder.append(id);
		builder.append(", nome=");
		builder.append(nome);
		builder.append(", categoria=");
		builder.append(categoria);
		builder.append(", origine=");
		builder.append(origine);
		builder.append(", prezzoKg=");
		builder.append(prezzoKg);
		builder.append(", disponibilita=");
		builder.append(disponibilita);
		builder.append("]");
		return builder.toString();
	}
	
	
	
}
