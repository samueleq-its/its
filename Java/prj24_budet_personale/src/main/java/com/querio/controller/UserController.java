package com.querio.controller;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import com.querio.entity.User;
import com.querio.service.UserService;

import jakarta.servlet.http.HttpSession;

import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class UserController {

	private final UserService service;

	public UserController(UserService service) {
		this.service = service;
	}

	@GetMapping("/login")
	public String getLogin(HttpSession session, Model model) {
		if (session.getAttribute("userId") != null) {
			model.addAttribute("loggedIn", true);
		}

		model.addAttribute("title", "login");
		return "login";
	}

	@PostMapping("/login")
	public String login(HttpSession session,
			RedirectAttributes redirect,
			@RequestParam String email,
			@RequestParam String password) {

		User user = service.getByEmail(email);

		// TODO hash

		if (user == null || !user.getPassword().equals(password)) {
			redirect.addFlashAttribute("message", "login fallito");
			return "redirect:/login";
		}

		session.setAttribute("userId", user.getId());
		return "redirect:/home";
	}

	@GetMapping("/logout")
	public String logout(HttpSession session, RedirectAttributes redirect) {
		session.removeAttribute("userId");
		redirect.addFlashAttribute("message", "Logout Effettuato");
		return "redirect:/login";
	}

}
