<?php

use App\Http\Controllers\HomeController;
use App\Http\Controllers\ProductController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    return view('welcome');
});

// Route::get('/swd/{nome}', [HomeController::class, 'index']);

Route::get('/categorie/{categoria}', [ProductController::class, 'categorie'])->name('categorie');
Route::resource('/products', ProductController::class);
