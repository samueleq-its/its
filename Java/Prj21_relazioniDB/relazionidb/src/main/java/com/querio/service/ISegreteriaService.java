package com.querio.service;

import java.util.List;
import java.util.Map;
import java.util.Optional;

import com.querio.entities.Libretto;
import com.querio.entities.Studente;

public interface ISegreteriaService {

	Studente addStudente(Studente s);

	Libretto addLibretto(Libretto l);

	List<Studente> getStudenti();
	Map<Integer,Studente> getStudentiMap();

	Optional<Studente> getStudenteById(int id);

	Optional<Studente> getStudenteByMatricola(String matricola);



}
