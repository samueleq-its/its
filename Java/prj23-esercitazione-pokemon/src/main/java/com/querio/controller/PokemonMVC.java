package com.querio.controller;

import java.util.List;
import java.util.Map;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.client.RestClient;

import com.querio.entity.Pokemon;
import com.querio.service.PokemonService;

import tools.jackson.databind.JsonNode;

@Controller
public class PokemonMVC {

	private final PokemonService service;

	public PokemonMVC(PokemonService service) {
		this.service = service;
	}

	@GetMapping("")
	public String getIndex(Model model, @RequestParam(name = "type", required = false) String selectedType) {

		Map<Integer, Pokemon> pokemons;
		List<String> types = service.getTypes();

		if (!types.contains(selectedType)) {
			pokemons = service.getAllMap();
		} else {
			pokemons = service.getByType(selectedType);
		}

		model.addAttribute("title", "Elenco Pokemon");
		model.addAttribute("pokemonMap", pokemons);
		model.addAttribute("types", service.getTypes());
		model.addAttribute("selectedType", selectedType);

		return "index";
	}

	@GetMapping("/{id}")
	public String getDetail(@PathVariable int id, Model model) {

		Pokemon pokemon = service.getById(id);

		RestClient restClient = RestClient
				.builder()
				.baseUrl("https://pokeapi.co/api/v2/pokemon")
				.build();

		String img = restClient.get()
				.uri("/{nome}", pokemon.getName())
				.retrieve()
				.body(JsonNode.class)
				.path("sprites")
				.path("front_default")
				.asString();

		model.addAttribute("title", "Dettagli Pokemon");
		model.addAttribute("pokemon", service.getById(id));
		model.addAttribute("img", img);

		return "detail";
	}

}
