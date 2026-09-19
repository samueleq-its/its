package com.samuele.service;

import com.samuele.dto.PlayerSessionDTO;
import com.samuele.dto.QuizDTO;
import com.samuele.util.DifficoltaQuiz;

public interface QuizService {
	QuizDTO getQuiz();

	String checkRisposta(String risposta);

	boolean selectDifficolta(DifficoltaQuiz difficolta);

	boolean selectCategoria(String categoria);

	boolean resetSessione();

	PlayerSessionDTO getPlayerStats();
}
