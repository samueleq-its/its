package com.querio.entities;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
// import lombok.Data;

@Entity
@Table(name = "listino_bar")
//@Data // crea getter e setter in automatico, NON FUNZIONA IN ECLIPSE
public class ProdottoBar {
	
	@Id
	//indica che ci pensa il database ad assegnare un valore
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	private String sezione;
	private String prodotto;
	private String prezzo;
	
	public ProdottoBar() {
		// TODO Auto-generated constructor stub
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getSezione() {
		return sezione;
	}

	public void setSezione(String sezione) {
		this.sezione = sezione;
	}

	public String getProdotto() {
		return prodotto;
	}

	public void setProdotto(String prodotto) {
		this.prodotto = prodotto;
	}

	public String getPrezzo() {
		return prezzo;
	}

	public void setPrezzo(String prezzo) {
		this.prezzo = prezzo;
	}
	
	
}
