package com.querio.service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Service;

import com.querio.entity.Pokemon;
import com.querio.repo.PokemonRepo;

@Service
public class PokemonService {

	private final PokemonRepo repo;
	private Map<Integer, Pokemon> pokeMap = new HashMap<>();

	public PokemonService(PokemonRepo repo) {
		this.repo = repo;

		this.repo.findAll()
				.stream()
				.forEach(p -> pokeMap.put(p.getId(), p));
	}

	// restituisce mappa <id, pokemon>
	public Map<Integer, Pokemon> getAllMap() {
		return this.pokeMap;
	}

	// restituisce pokemon per dato id
	public Pokemon getById(int id) {
		return this.pokeMap.get(id);
	}

	// restituisce lista di tutti i tipi di pokemon
	public List<String> getTypes() {
		return this.pokeMap
				.values()
				.stream()
				.flatMap(p -> List.of(p.getType1(), p.getType2()).stream())
				.distinct()
				.filter(t -> !t.equals(""))
				.sorted()
				.toList();
	}

	public Map<Integer, Pokemon> getByType(String selectedType) {
		Map<Integer, Pokemon> pokemons = new HashMap<>();
		this.pokeMap
				.values()
				.stream()
				.filter(p -> p.getType1().equals(selectedType) || p.getType2().equals(selectedType))
				.forEach(p -> pokemons.put(p.getId(), p));

		return pokemons;
	}

}
