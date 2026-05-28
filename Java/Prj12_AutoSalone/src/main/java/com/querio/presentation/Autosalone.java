package com.querio.presentation;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class Autosalone {
	
	@GetMapping("automobili")
	public String automobili() {
		return "automobili";
	}
}
