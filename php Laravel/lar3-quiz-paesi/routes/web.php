<?php

use App\Http\Controllers\DefaultController;
use App\Http\Controllers\QuizController;
use App\Http\Controllers\TrainingController;
use Illuminate\Support\Facades\Route;

// TODO spostare logica nel controller
Route::get('/', [DefaultController::class, 'home'])->name('home.home');
Route::post('/', [DefaultController::class, 'postDifficulty'])->name('home.difficulty');

Route::get('/quit', [DefaultController::class, 'quit'])->name('home.quit');

Route::get('/quiz/capitali', [QuizController::class, 'getQuizCapital'])->name('quiz.getCapitals');
Route::post('/quiz/capitali', [QuizController::class, 'postQuizCapital'])->name('quiz.postCapitals');

Route::get('/quiz/bandiere', [QuizController::class, 'getQuizFlags'])->name('quiz.getFlags');
Route::post('/quiz/bandiere', [QuizController::class, 'postQuizFlags'])->name('quiz.postFlags');

Route::get('/allenamento', [TrainingController::class, 'index'])->name('training.index');
Route::get('/allenamento/{code}', [TrainingController::class, 'show'])->name('training.show');
