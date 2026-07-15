<?php

namespace App\Http\Controllers;

use App\Models\Country;
use Faker\Guesser\Name;
use Illuminate\Http\Request;

class TrainingController extends Controller
{
    public function index()
    {
        $title = 'allenamento';
        $countries = Country::all()->toArray();

        $countriesData = [];
        foreach ($countries as $country) {
            $countriesData[] = [
                'name' => $country['name'],
                'code' => $country['alpha2Code']
            ];
        }

        return view('training.index', compact('title', 'countriesData'));
    }

    public function show(string $code)
    {
        $title = 'allenamento';
        $country = Country::all()->where('alpha2Code', $code)->first();

        $countryData = [
            'name' => $country['name'],
            'code' => $country['alpha2Code'],
            'capital' => $country['capital'],
            'language' => json_decode($country['languages'])[0]->name,
            'population' => $country['population'],
            'region' => $country['region']
        ];

        return view('training.show', compact('title', 'countryData'));
    }
}
