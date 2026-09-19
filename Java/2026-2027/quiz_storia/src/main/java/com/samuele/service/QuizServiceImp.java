package com.samuele.service;

import com.samuele.component.PlayerSession;
import com.samuele.component.quizGenerator.QuizGeneratorStrategy;
import com.samuele.dto.PlayerSessionDTO;
import com.samuele.dto.Quiz;
import com.samuele.dto.QuizDTO;
import com.samuele.util.DifficoltaQuiz;

import java.util.List;
import java.util.concurrent.ThreadLocalRandom;

import org.springframework.stereotype.Service;

@Service
public class QuizServiceImp implements QuizService {

	private final EventoService eventoService;
	private final PlayerSession session;
	private final List<QuizGeneratorStrategy> generatorStrategies;

	public QuizServiceImp(PlayerSession userSession, List<QuizGeneratorStrategy> generatorStrategies,
			EventoService eventoService) {
		this.session = userSession;
		this.generatorStrategies = generatorStrategies;
		this.eventoService = eventoService;
	}

	public QuizDTO getQuiz() {
		if (session.getQuizCorrente() != null) {
			return QuizDTO.fromQuiz(session.getQuizCorrente());
		}

		QuizGeneratorStrategy randomQuizGenerator = generatorStrategies
				.get(ThreadLocalRandom.current().nextInt(generatorStrategies.size()));

		final int MAX_ATTEMPTS = 20;
		int attempts = 0;
		Quiz quiz = null;
		while (quiz == null || attempts > MAX_ATTEMPTS) {
			attempts++;

			Quiz quizCandidate = randomQuizGenerator.generateQuiz(session.getDifficolta(),
					session.getCategoria());

			if (isValidQuiz(quizCandidate)) {
				quiz = quizCandidate;
			}
		}

		session.setQuizCorrente(quiz);
		session.addQuizEffetuato(quiz);
		return QuizDTO.fromQuiz(quiz);
	}

	public String checkRisposta(String risposta) {
		if (session.getQuizCorrente() == null) {
			return null;
		}

		String rispostaCorretta = session.getQuizCorrente().getRispostaCorretta();
		session.setQuizCorrente(null);

		if (rispostaCorretta.equals(risposta)) {
			session.setRisposteCorrette(session.getRisposteCorrette() + 1);
		}

		return rispostaCorretta;
	}

	public boolean selectDifficolta(DifficoltaQuiz difficolta) {
		session.reset();
		session.setDifficolta(difficolta);
		return true;
	}

	public boolean selectCategoria(String categoria) {

		if (categoria == null || categoria.isBlank() || eventoService.findAllCategorie().contains(categoria)) {
			session.reset();
			session.setCategoria(categoria);
			return true;
		}
		return false;
	}

	public boolean resetSessione() {
		session.reset();
		return true;
	}

	public PlayerSessionDTO getPlayerStats() {
		return PlayerSessionDTO.fromPlayerSession(session);
	}

	private boolean isValidQuiz(Quiz quizCandidate) {
		return !session.getQuizEffettuati().stream()
				.anyMatch(quizPrecedente -> quizPrecedente.equals(quizCandidate));
	}

}