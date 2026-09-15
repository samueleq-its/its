package com.querio.entities;

import java.util.HashSet;
import java.util.Set;

import com.fasterxml.jackson.annotation.JsonIgnore;

import jakarta.persistence.CascadeType;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(name="corsi")
public class Corso {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private int id;

	private String nome;

	@JsonIgnore
	@OneToMany(mappedBy = "corso", cascade = CascadeType.ALL)
	private Set<Studente> studenti = new HashSet<>();

	@JsonIgnore
	@OneToMany(mappedBy = "corso", cascade = CascadeType.ALL)
	private Set<Insegnamento> insegnamenti = new HashSet<>();

}
