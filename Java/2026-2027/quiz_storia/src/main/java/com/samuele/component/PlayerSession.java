package com.samuele.component;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Component;
import org.springframework.web.context.annotation.SessionScope;

import com.samuele.dto.Quiz;
import com.samuele.util.DifficoltaQuiz;

import lombok.Data;

@Component
@SessionScope
@Data
public class PlayerSession {

	private List<Quiz> quizEffettuati;
	private Quiz quizCorrente;
	private int risposteCorrette;

	private DifficoltaQuiz difficolta;
	private String categoria;

	public PlayerSession() {
		this.quizEffettuati = new ArrayList<>();
		this.risposteCorrette = 0;
		this.difficolta = DifficoltaQuiz.FACILE;
		this.categoria = null;
	}

	public void addQuizEffetuato(Quiz q) {
		quizEffettuati.add(q);
	}

	public void reset() {
		getQuizEffettuati().clear();
		setQuizCorrente(null);
		setRisposteCorrette(0);
	}
}
