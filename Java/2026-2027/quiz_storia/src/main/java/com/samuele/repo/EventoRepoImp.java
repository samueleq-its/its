package com.samuele.repo;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;
import java.util.stream.Collectors;

import org.springframework.core.io.Resource;
import org.springframework.core.io.support.ResourcePatternResolver;
import org.springframework.stereotype.Repository;

import com.samuele.dto.JsonDTO;
import com.samuele.entity.Evento;

import tools.jackson.databind.ObjectMapper;

@Repository
public class EventoRepoImp implements EventoRepo {

	private final ResourcePatternResolver resourceResolver;
	private final ObjectMapper objectMapper;

	private Map<Integer, Evento> cacheEventi;

	public EventoRepoImp(ResourcePatternResolver resourceResolver, ObjectMapper objectMapper) {
		this.resourceResolver = resourceResolver;
		this.objectMapper = objectMapper;

		this.cacheEventi = new HashMap<>();
	}

	@Override
	public Map<Integer, Evento> findAll() {

		if (cacheEventi.isEmpty()) {
			loadCacheEventi();
		}

		return cacheEventi;
	}

	private void loadCacheEventi() {
		try {
			for (Resource r : getResources()) {
				cacheEventi.putAll(readMapEventi(r));
			}
		} catch (IOException e) {
			System.err.println("impossibile caricare i file JSON");
			e.printStackTrace();
		}
	}

	private Map<Integer, Evento> readMapEventi(Resource r) throws IOException {
		JsonDTO jsonDTO = objectMapper.readValue(r.getInputStream(), JsonDTO.class);

		return jsonDTO.eventi().stream()
				.collect(
						Collectors.toMap(
								evento -> evento.getId(),
								evento -> evento,
								(existing, duplicate) -> existing));
	}

	private Resource[] getResources() throws IOException {
		Resource[] resources;
		resources = resourceResolver.getResources("classpath:json/*.json");
		return resources;
	}

	// utilizzando JsonNode non serve DTO
	// JsonNode json = objectMapper.readTree(r.getInputStream());
	// JsonNode jsonEventi = json.get("eventi");
	// if (jsonEventi == null) {
	// return ResponseEntity.internalServerError().build();
	// }
	// eventi.addAll(objectMapper.convertValue(jsonEventi, new
	// TypeReference<List<Evento>>() {
	// }));

	// Entry<Integer, Evento>[] entries = jsonDTO.eventi().stream()
	// .map(e -> Map.entry(e.getId(), e))
	// .toArray(Map.Entry[]::new);
	// Map.ofEntries(entries);
}
