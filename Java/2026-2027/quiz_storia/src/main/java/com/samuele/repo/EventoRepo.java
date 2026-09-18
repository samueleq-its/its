package com.samuele.repo;

import java.util.Map;

import org.springframework.stereotype.Repository;

import com.samuele.entity.Evento;

@Repository
public interface EventoRepo {

	Map<Integer, Evento> findAll();
}
