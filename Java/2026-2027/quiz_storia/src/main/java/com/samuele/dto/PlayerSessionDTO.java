package com.samuele.dto;

import com.samuele.component.PlayerSession;
import com.samuele.util.DifficoltaQuiz;

public record PlayerSessionDTO(
		int quizEffettuati,
		int risposteCorrette,
		DifficoltaQuiz difficolta,
		String categoria) {

	public static PlayerSessionDTO fromPlayerSession(PlayerSession session) {
		return new PlayerSessionDTO(
				session.getQuizEffettuati().size(),
				session.getRisposteCorrette(),
				session.getDifficolta(),
				session.getCategoria());
	}
}
