package com.querio.controllers;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import com.querio.model.Maglia;
import com.querio.services.TShirtService;

@Controller
public class AbbigliamentoMVC {

	@Autowired
	private TShirtService service;
	
	//@RequestMapping(path = { "", "home", "index" }, method = RequestMethod.GET)
	// equivalente
	@GetMapping(path = {"/","home","index"})
	public String home(Model m) {
		List<Maglia> magliette = service.getmagliette();
		m.addAttribute("magliette", magliette);
		return "home";
	}
}
