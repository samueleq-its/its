<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

/**
 * @property string $alpha2Code
 * @property string $name
 * @property string $capital
 * @property int $population
 */
class Country extends Model
{
    protected $table = 'countries';
}
