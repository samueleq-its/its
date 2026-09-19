package com.samuele.controller;

import com.samuele.dto.PlayerSessionDTO;
import com.samuele.dto.QuizDTO;
import com.samuele.service.EventoService;
import com.samuele.service.QuizService;
import com.samuele.util.DifficoltaQuiz;

import org.springframework.web.bind.annotation.RestController;

import java.util.Set;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;

@RestController
@RequestMapping("api/quiz")
public class QuizController {

	/*
	 * modificatori:
	 * filtro per categoria
	 * difficoltà
	 * 
	 */

	private final EventoService eventoService;
	private final QuizService quizService;

	QuizController(QuizService quizService, EventoService eventoService) {
		this.quizService = quizService;
		this.eventoService = eventoService;
	}

	@GetMapping("")
	public ResponseEntity<QuizDTO> getQuiz() {
		return ResponseEntity.ok(quizService.getQuiz());
	}

	@PostMapping("")
	public ResponseEntity<String> postRisposta(@RequestBody String risposta) {
		return ResponseEntity.ok(quizService.checkRisposta(risposta));
	}

	@GetMapping("/difficolta")
	public ResponseEntity<DifficoltaQuiz[]> getDifficolta() {
		return ResponseEntity.ok(DifficoltaQuiz.values());
	}

	@PostMapping("/difficolta")
	public ResponseEntity<Boolean> selectDifficolta(@RequestBody DifficoltaQuiz difficolta) {
		return ResponseEntity.ok(quizService.selectDifficolta(difficolta));
	}

	@GetMapping("/categoria")
	public ResponseEntity<Set<String>> getCategorie() {
		return ResponseEntity.ok(eventoService.findAllCategorie());
	}

	@PostMapping("/categoria")
	public ResponseEntity<Boolean> selectCategoria(@RequestBody String difficolta) {
		return ResponseEntity.ok(quizService.selectCategoria(difficolta));
	}

	@GetMapping("/sessione")
	public ResponseEntity<PlayerSessionDTO> getMethodName(@RequestParam String param) {
		return ResponseEntity.ok(quizService.getPlayerStats());
	}

	@GetMapping("/sessione/reset")
	public ResponseEntity<Boolean> resetSessione(@RequestParam String param) {
		return ResponseEntity.ok(quizService.resetSessione());
	}

}
