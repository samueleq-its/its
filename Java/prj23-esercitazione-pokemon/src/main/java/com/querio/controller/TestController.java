package com.querio.controller;

import org.springframework.web.bind.annotation.RestController;

import com.querio.service.PokemonService;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@RestController
@RequestMapping("/test")
public class TestController {

	@Autowired
	private PokemonService service;

	@GetMapping("")
	public List<String> getMethodName() {
		return service.getTypes();
	}

}
