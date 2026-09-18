package com.samuele.entity;

import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import lombok.Data;

@Entity
@Data
public class Evento {

	@Id
	private int id;
	private int anno;
	private String titolo;
	private String luogo;
	private String civilta;
	private String categoria;
	private String descrizione;

}
