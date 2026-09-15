package com.querio.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.GetMapping;



@Controller
@RequestMapping("/prodotti")
public class ProdottoMVC {

	@GetMapping("")
	public String getProdotti() {
		return "prodotti";
	}
	
}
