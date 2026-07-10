package com.querio.controller;

import com.querio.entity.Transaction;
import com.querio.service.TransactionService;

import jakarta.servlet.http.HttpSession;
import jakarta.websocket.server.PathParam;

import java.util.List;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/transactions")
public class TransactionController {

	private final TransactionService service;

	public TransactionController(TransactionService service) {
		this.service = service;
	}

	@GetMapping("")
	public String getTransactions(HttpSession session, Model model) {

		if (session.getAttribute("userId") != null) {
			model.addAttribute("loggedIn", true);
		}

		Long userId = (Long) session.getAttribute("userId");

		if (userId == null) {
			return "unauthorized";
		}

		List<Transaction> transactions = service.getByUserId(userId);

		model.addAttribute("title", "Transazioni");
		model.addAttribute("transactions", transactions);

		return "transactions";
	}

	@GetMapping("/{transId}")
	public String editTransaction(HttpSession session, Model model, @PathVariable long transId) {

		Long userId = (Long) session.getAttribute("userId");
		Transaction transaction = service.getById(transId);

		// TODO: check se transazione esiste

		// check user logged in
		if (userId == null) { // non autorizzato
			return "redirect:/unauthorized";
		}

		// check transaction di user
		if (transaction.getUser().getId() != userId) {
			return "redirect:/unauthorized";
		}

		model.addAttribute("title", "Dettagli Transazione");
		model.addAttribute("loggedIn", true);

		return ""; // TODO
	}

}

/*
 * TODO:
 * - modifica
 * - creazione
 * - eliminazione
 */
