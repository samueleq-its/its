package com.samuele.dto;

import java.util.List;

public record QuizDTO(
		String domanda,
		List<String> risposte) {
	public static QuizDTO fromQuiz(Quiz quiz) {
		return new QuizDTO(quiz.getDomanda(), quiz.getRisposte());
	}
}
