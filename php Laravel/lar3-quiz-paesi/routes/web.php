<?php

use App\Http\Controllers\QuizController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});

Route::get('/quiz', [QuizController::class, 'getQuizCapital'])->name('quiz.getCapitals');
Route::post('/quiz', [QuizController::class, 'postQuizCapital'])->name('quiz.postCapitals');
