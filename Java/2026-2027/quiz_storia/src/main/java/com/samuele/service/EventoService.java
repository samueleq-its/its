package com.samuele.service;

import java.util.Map;

import org.springframework.stereotype.Service;

import com.samuele.entity.Evento;

@Service
public interface EventoService {

	Map<Integer, Evento> findAll();

}
