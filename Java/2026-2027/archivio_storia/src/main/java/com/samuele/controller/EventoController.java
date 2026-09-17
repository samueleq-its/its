package com.samuele.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class EventoController {

	@GetMapping
	public String index(Model model) {
		return "eventi/index"; // templates/eventi/list.html
	}

	@GetMapping("/nuovo")
	public String create(Model model) {
		return "eventi/create"; // templates/eventi/create.html
	}

	@GetMapping("/{id}")
	public String details() {
		return "eventi/details"; // templates/eventi/details.html
	}

	@GetMapping("/statistiche")
	public String statistiche() {
		return "eventi/stats"; // templates/eventi/stats.html
	}
}
