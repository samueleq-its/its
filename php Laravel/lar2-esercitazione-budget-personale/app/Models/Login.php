<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Login extends Model
{
    protected $table = 'logins';

    public $timestamps = false;

    protected $fillable = [
        'name',
        'email',
        'password',
    ];
}
