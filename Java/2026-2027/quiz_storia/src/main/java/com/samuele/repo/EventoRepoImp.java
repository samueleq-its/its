package com.samuele.repo;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Optional;
import java.util.stream.Collectors;

import org.springframework.core.io.Resource;
import org.springframework.core.io.support.ResourcePatternResolver;
import org.springframework.stereotype.Repository;

import com.samuele.dto.JsonDTO;
import com.samuele.entity.Evento;

import tools.jackson.core.JacksonException;
import tools.jackson.databind.ObjectMapper;

@Repository
public class EventoRepoImp implements EventoRepo {

	private final ResourcePatternResolver resourceResolver;
	private final ObjectMapper objectMapper;

	/**
	 * Mappa anno - evento <br>
	 * eventi con lo stesso anno sono scartati, gli unici presenti nel json sono
	 * doppioni
	 */
	private Map<Integer, Evento> cacheEventi;

	public EventoRepoImp(ResourcePatternResolver resourceResolver, ObjectMapper objectMapper) {
		this.resourceResolver = resourceResolver;
		this.objectMapper = objectMapper;

		this.cacheEventi = new HashMap<>();
	}

	@Override
	public Map<Integer, Evento> findAll() {
		return getEventi();
	}

	@Override
	public Optional<Evento> findByAnno(int anno) {
		Evento e = getEventi().get(anno);
		return Optional.of(e);
	}

	@Override
	public Map<Integer, Evento> findAllByCategoria(String categoria) {

		Map<Integer, Evento> eventiInCategoria = new HashMap<>();

		getEventi().forEach((year, evento) -> {
			if (evento.getCategoria() == categoria) {
				eventiInCategoria.put(year, evento);
			}
		});

		return eventiInCategoria;
	}

	private Map<Integer, Evento> getEventi() {
		if (cacheEventi.isEmpty()) {
			loadCacheEventi();
		}
		return Collections.unmodifiableMap(cacheEventi);
	}

	private void loadCacheEventi() {
		cacheEventi = Arrays.stream(getJsonResources())
				.map(this::mapJsonEventiToList)
				.flatMap(List::stream)
				.collect(Collectors.toMap(
						Evento::getAnno,
						e -> e,
						(present, replacement) -> present));
	}

	private List<Evento> mapJsonEventiToList(Resource r) {
		JsonDTO jsonDTO = null;
		try {
			jsonDTO = objectMapper.readValue(r.getInputStream(), JsonDTO.class);
		} catch (JacksonException | IOException e) {
			System.err.println("impossibile leggere il file " + r.getFilename());
			e.printStackTrace();
		}
		return jsonDTO != null ? jsonDTO.eventi() : new ArrayList<Evento>() {
		};
	}

	private Resource[] getJsonResources() {
		Resource[] resources = new Resource[0];
		try {
			resources = resourceResolver.getResources("classpath:json/*.json");
		} catch (IOException e) {
			System.err.println("impossibile leggere le risorse Json");
			e.printStackTrace();
		}
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
