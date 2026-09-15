package com.querio.model;

import org.springframework.stereotype.Component;

@Component
public class Maglia {

	private double prezzo;
	private String colore;
	private String logo;

	public double getPrezzo() {
		return prezzo;
	}

	public void setPrezzo(double prezzo) {
		this.prezzo = prezzo;
	}

	public String getColore() {
		return colore;
	}

	public void setColore(String colore) {
		this.colore = colore;
	}

	public String getLogo() {
		return logo;
	}

	public void setLogo(String logo) {
		this.logo = logo;
	}

	@Override
	public String toString() {
		return "Maglia [prezzo=" + prezzo + ", colore=" + colore + ", logo=" + logo + "]";
	}
}
