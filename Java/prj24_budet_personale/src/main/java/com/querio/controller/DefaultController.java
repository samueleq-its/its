package com.querio.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import jakarta.servlet.http.HttpSession;

@Controller
public class DefaultController {

	@GetMapping("")
	public String getRoot() {
		return "redirect:/home";
	}

	@GetMapping("/home")
	public String getHome(HttpSession session, Model model) {
		if (session.getAttribute("userId") != null) {
			model.addAttribute("loggedIn", true);
		}

		model.addAttribute("title", "Home");
		return "home";
	}

}
