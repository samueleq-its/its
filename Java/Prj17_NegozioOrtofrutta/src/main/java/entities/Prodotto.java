package entities;

public record Prodotto(
		int id,
		String nome,
		String categoria,
		String origine, 
		double prezzoKg, 
		String disponibilita
		) {}
