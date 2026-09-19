package com.samuele.component.quizGenerator;

import com.samuele.service.EventoService;
import com.samuele.util.DifficoltaQuiz;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import org.springframework.stereotype.Component;

import com.samuele.dto.Quiz;
import com.samuele.entity.Evento;

@Component
/** cosa avvenne nel anno x */
public class QuizAnnoEventoStrategy implements QuizGeneratorStrategy {

	private final EventoService eventoService;

	QuizAnnoEventoStrategy(EventoService eventoService) {
		this.eventoService = eventoService;
	}

	@Override
	public Quiz generateQuiz(DifficoltaQuiz difficoltà, String categoria) {
		Map<Integer, Evento> eventi;
		if (categoria != null && !categoria.isEmpty()) {
			eventi = eventoService.findAllByCategoria(categoria);
		} else {
			eventi = eventoService.findAll();
		}

		var listEventi = eventi.values().stream().collect(Collectors.toList());
		Collections.shuffle(listEventi);
		Evento eventoQuiz = listEventi.removeFirst();

		String indicatoreAnnoACDC = eventoQuiz.getAnno() >= 0 ? " d.C." : " a.C.";
		String domanda = "Che evento storico avvenne nell'anno " + Math.abs(eventoQuiz.getAnno())
				+ indicatoreAnnoACDC;
		String rispostaCorretta = eventoQuiz.getTitolo();
		List<String> risposte = new ArrayList<>();

		risposte.add(rispostaCorretta);

		// sceglie le risposte sbagliate in base alla difficolta
		// facile sono completamente casuali
		// difficile hanno anni simili
		switch (difficoltà) {
			case FACILE:
				risposte.add(listEventi.removeFirst().getTitolo());
				risposte.add(listEventi.removeFirst().getTitolo());
				break;
			case DIFFICILE:
				final int SIZE_POOL_EVENTI = 20;
				final int N_RISPOSTE = 3;

				listEventi.stream()
						.limit(SIZE_POOL_EVENTI)
						.sorted((e1, e2) -> Math.abs(e1.getAnno() - eventoQuiz.getAnno())
								- Math.abs(e2.getAnno() - eventoQuiz.getAnno()))
						.limit(N_RISPOSTE)
						.forEach(e -> risposte.add(e.getTitolo()));
				break;
		}

		Collections.shuffle(risposte);
		return new Quiz(domanda, risposte, rispostaCorretta);
	}

}
