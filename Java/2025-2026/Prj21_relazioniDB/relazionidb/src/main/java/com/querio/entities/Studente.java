package com.querio.entities;

import java.util.HashSet;
import java.util.Set;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import jakarta.persistence.ManyToOne;
import jakarta.persistence.OneToOne;
import jakarta.persistence.Table;
import lombok.Data;

@Entity
@Data
@Table(name = "studenti")
public class Studente {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Integer id;

	private String nome;
	private String cognome;

	@OneToOne(mappedBy = "studente") // questo non viene salvato sul DB
	private Libretto Libretto;

	@ManyToOne() // questo non viene salvato sul DB
	private Corso corso;

	
}
