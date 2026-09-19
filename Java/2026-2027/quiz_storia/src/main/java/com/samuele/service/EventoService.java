package com.samuele.service;

import java.util.Map;
import java.util.Optional;
import java.util.Set;

import org.springframework.stereotype.Service;

import com.samuele.entity.Evento;

@Service
public interface EventoService {

	Map<Integer, Evento> findAll();

	Optional<Evento> findByAnno(int anno);

	Map<Integer, Evento> findAllByCategoria(String categoria);

	Set<String> findAllCategorie();

	Set<Integer> findAllAnni();
}
