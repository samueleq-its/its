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
/** In quale anno avvenne l'evento x */
public class QuizEventoAnnoStrategy implements QuizGeneratorStrategy {

	private final EventoService eventoService;

	public QuizEventoAnnoStrategy(EventoService eventoService) {
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

		String domanda = "In quale anno avvenne l'evento storico '" + eventoQuiz.getTitolo() + "'?";
		String rispostaCorretta = formattaAnno(eventoQuiz.getAnno());
		List<String> risposte = new ArrayList<>();

		risposte.add(rispostaCorretta);

		// Sceglie le risposte sbagliate in base alla difficoltà:
		// FACILE: anni presi da eventi completamente casuali
		// DIFFICILE: anni presi da eventi avvenuti in periodi storici vicini
		switch (difficoltà) {
			case FACILE:
				risposte.add(formattaAnno(listEventi.removeFirst().getAnno()));
				risposte.add(formattaAnno(listEventi.removeFirst().getAnno()));
				break;
			case DIFFICILE:
				final int SIZE_POOL_EVENTI = 20;
				final int N_RISPOSTE_SBAGLIATE = 3;

				listEventi.stream()
						.filter(e -> e.getAnno() != eventoQuiz.getAnno())
						.limit(SIZE_POOL_EVENTI)
						.sorted((e1, e2) -> Math.abs(e1.getAnno() - eventoQuiz.getAnno())
								- Math.abs(e2.getAnno() - eventoQuiz.getAnno()))
						.map(e -> formattaAnno(e.getAnno()))
						.distinct()
						.limit(N_RISPOSTE_SBAGLIATE)
						.forEach(risposte::add);
				break;
		}

		Collections.shuffle(risposte);

		return new Quiz(domanda, risposte, rispostaCorretta);
	}

	private String formattaAnno(int anno) {
		String indicatore = anno >= 0 ? " d.C." : " a.C.";
		return Math.abs(anno) + indicatore;
	}
}
