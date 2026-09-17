package com.samuele.repo;

import org.springframework.data.jpa.repository.JpaRepository;

import com.samuele.entity.Evento;

public interface EventoRepo extends JpaRepository<Evento, Integer> {

}