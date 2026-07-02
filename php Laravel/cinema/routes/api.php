<?php

use Illuminate\Http\Request;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\FilmController;
use App\Http\Controllers\CinemaController;

Route::get('/user', function (Request $request) {
    return $request->user();
})->middleware('auth:sanctum');

Route::get("/films", function() {
    $films = \App\Models\Film::all();
    return response($films);
});

Route::get("/cinemas", function() {
    $cinemas = \App\Models\Cinema::all();
    return response($cinemas);
});