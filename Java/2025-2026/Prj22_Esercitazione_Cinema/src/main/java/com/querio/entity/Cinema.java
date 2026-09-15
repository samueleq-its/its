package com.querio.entity;

import java.util.List;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import lombok.Data;

@Entity
@Data
public class Cinema {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@Column(name = "nome_cinema")
	private String nome;
	private String indirizzo;
	private String telefono;
	private int posti;

	@OneToMany(mappedBy = "cinema")
	private List<FilmInSala> filmInSala;
}
