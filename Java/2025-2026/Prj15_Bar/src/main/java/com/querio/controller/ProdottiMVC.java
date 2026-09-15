package com.querio.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

import com.querio.entities.ProdottoBar;
import com.querio.services.ProdottoBarService;

@Controller
public class ProdottiMVC {
	@Autowired
	private ProdottoBarService service;
	
	@GetMapping("/prodotti")
	public String getProdotti(Model model) {
		model.addAttribute("sezioni", service.getSezioni());
		model.addAttribute("prodotti", service.GetAllProdotti());
		model.addAttribute("title","listino prezzi bar");
		return "prodotti";
	}
	
	@PostMapping("/prodotti")
	public String postProdotti(ProdottoBar p) {
		service.addProdotto(p);
		
		return "redirect:/prodotti";
	}
	

}
