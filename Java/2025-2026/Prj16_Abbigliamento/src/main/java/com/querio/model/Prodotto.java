package com.querio.model;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Entity
@Table(name ="prodotti")
public class Prodotto {

	@Override
	public String toString() {
		return "Prodotto [id=" + id + ", nome=" + nome + ", categoria=" + categoria + ", prezzo=" + prezzo
				+ ", giacenza=" + giacenza + "]";
	}
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;
	
	private String nome;
	private String categoria;
	private double prezzo;
	private int giacenza;
	
	public Prodotto() {
		// TODO Auto-generated constructor stub
	}
	
	//region GETTER E SETTERS 
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
	public double getPrezzo() {
		return prezzo;
	}
	public void setPrezzo(double prezzo) {
		this.prezzo = prezzo;
	}
	public int getGiacenza() {
		return giacenza;
	}
	public void setGiacenza(int giacenza) {
		this.giacenza = giacenza;
	}
	//endregion
	
	
}
