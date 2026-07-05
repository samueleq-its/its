<?php

use App\Http\Controllers\PokemonController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});

Route::resource('/pokemon', PokemonController::class);

// Route::get('/pokemon/type/{type}', [PokemonController::class, 'filter'])->name('pokemon.filter');
