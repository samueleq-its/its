package com.samuele.dto;

import java.util.List;

import com.samuele.entity.Evento;

public record JsonDTO(
		String version,
		String epoca,
		List<Evento> eventi) {
}