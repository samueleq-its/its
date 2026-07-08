<?php

use App\Http\Controllers\LoginController;
use App\Http\Controllers\TransactionController;
use Illuminate\Support\Facades\Route;

Route::get('/', function () {
    if (!session()->has('login_id')) {
        return redirect()->route('logins.login');
    } else {
        return redirect()->route('transactions.index');
    }
});

Route::get('logins', [LoginController::class, 'login'])->name('logins.login');
Route::get('logins/register', [LoginController::class, 'register'])->name('logins.register');
Route::post('logins/store', [LoginController::class, 'store'])->name('logins.store');
Route::post('logins/authenticate', [LoginController::class, 'authenticate'])->name('logins.authenticate');

Route::resource('transactions', TransactionController::class);
