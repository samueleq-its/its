package it.corsojava.entity;


import jakarta.persistence.*;

@Entity
@Table(name = "contacts")
public class Contact {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	public Long id;

	@Column(nullable = false)
	public String nome;

	@Column(nullable = false)
	public String cognome;

	@Column(unique = true, nullable = false)
	public String email;

	public String telefono;

	public String azienda;

	public Boolean attivo = true;
}