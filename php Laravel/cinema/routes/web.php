<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\FilmController;
use App\Http\Controllers\CinemaController;
use App\Http\Controllers\FilmInSalaController;
use App\Http\Controllers\PrenotazioniController;

Route::get('/', function () {
    return view('welcome');
});

// Route::get('/cinema', function () {
//     return view('cinema.index');
// });


Route::resource("films", FilmController::class);
Route::resource("cinemas", CinemaController::class);
Route::resource("film_in_salas", FilmInSalaController::class);
Route::resource("prenotazionis", PrenotazioniController::class);

