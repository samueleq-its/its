package com.samuele.component.quizGenerator;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import org.springframework.stereotype.Component;

import com.samuele.dto.Quiz;
import com.samuele.entity.Evento;
import com.samuele.service.EventoService;
import com.samuele.util.DifficoltaQuiz;

@Component
/** In quale luogo avvenne l'evento x */
public class QuizEventoLuogoStrategy implements QuizGeneratorStrategy {

	private final EventoService eventoService;

	public QuizEventoLuogoStrategy(EventoService eventoService) {
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

		String domanda = "In quale luogo avvenne l'evento storico '" + eventoQuiz.getTitolo() + "'?";
		String rispostaCorretta = eventoQuiz.getLuogo();
		List<String> risposte = new ArrayList<>();

		risposte.add(rispostaCorretta);

		// Sceglie le risposte sbagliate in base alla difficoltà:
		// FACILE: luoghi presi da eventi completamente casuali
		// DIFFICILE: solo una risposta aggiuntiva
		switch (difficoltà) {
			case FACILE:
				risposte.add(listEventi.removeFirst().getLuogo());
				risposte.add(listEventi.removeFirst().getLuogo());
				break;
			case DIFFICILE:
				risposte.add(listEventi.removeFirst().getLuogo());
				risposte.add(listEventi.removeFirst().getLuogo());
				risposte.add(listEventi.removeFirst().getLuogo());
				break;
			// case DIFFICILE:
			// final int SIZE_POOL_EVENTI = 20;
			// final int N_RISPOSTE_SBAGLIATE = 2;

			// listEventi.stream()
			// .filter(e -> !e.getLuogo().equalsIgnoreCase(rispostaCorretta))
			// .limit(SIZE_POOL_EVENTI)
			// .sorted((e1, e2) -> Math.abs(e1.getAnno() - eventoQuiz.getAnno())
			// - Math.abs(e2.getAnno() - eventoQuiz.getAnno()))
			// .map(Evento::getLuogo)
			// .distinct()
			// .limit(N_RISPOSTE_SBAGLIATE)
			// .forEach(risposte::add);
			// break;
		}

		Collections.shuffle(risposte);

		return new Quiz(domanda, risposte, rispostaCorretta);
	}
}