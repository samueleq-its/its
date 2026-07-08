package com.querio.entity;

import java.time.LocalDateTime;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.JoinColumn;
import jakarta.persistence.ManyToOne;
import lombok.Data;

@Entity
@Data
public class FilmInSala {
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	@ManyToOne
	@JoinColumn(name = "id_cinema")
	@JsonIgnore
	private Cinema cinema;

	@ManyToOne
	@JoinColumn(name = "id_film")
	@JsonIgnore
	private Film film;

	private LocalDateTime data;
	private double prezzo;
	private int postiRimanenti;
}
