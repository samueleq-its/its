<?php

use App\Http\Controllers\QuizController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    session()->start();
    session()->put([
        'valid' => true,
        'games' => 0,
        'score' => 0,
        'difficulty' => 4
    ]);

    return view('welcome');
})->name('home');

// non so se sta funzionando
Route::get('/quit', function () {
    session()->flush();

    return view('welcome');
})->name('home');

Route::get('/quiz/capitali', [QuizController::class, 'getQuizCapital'])->name('quiz.getCapitals');
Route::post('/quiz/capitali', [QuizController::class, 'postQuizCapital'])->name('quiz.postCapitals');

Route::get('/quiz/bandiere', [QuizController::class, 'getQuizFlags'])->name('quiz.getFlags');
Route::post('/quiz/bandiere', [QuizController::class, 'postQuizFlags'])->name('quiz.postFlags');
