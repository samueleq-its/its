package com.samuele.component.quizGenerator;

import org.springframework.stereotype.Component;

import com.samuele.dto.Quiz;
import com.samuele.util.DifficoltaQuiz;

@Component
public interface QuizGeneratorStrategy {

	Quiz generateQuiz(DifficoltaQuiz difficoltà, String categoria);
}
