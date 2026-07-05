<?php

namespace App\Http\Controllers;

use App\Models\pokemon;
use Illuminate\Http\Request;

define('API', 'https://pokeapi.co/api/v2/pokemon/');

class PokemonController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index(Request $request)
    {
        $title = 'Elenco Pokemon';

        $selectedType = $request->query('type');

        if ($selectedType == null) {
            $pokemons = Pokemon::all();
        } else {
            $pokemons = pokemon::where('Type_1', $selectedType)->orWhere('Type_2', '=', $selectedType)->get();
        }

        $types = Pokemon::query()->select('Type_1')->distinct()->orderBy('Type_1')->pluck('Type_1');
        // $types_2 = Pokemon::query()->select('Type_2')->distinct()->orderByDesc('Type_2')->pluck('Type_2');

        return view('pokemon.index', compact('title', 'pokemons', 'types', 'selectedType'));
    }

    // public function filter(string $type)
    // {
    //     $title = 'Elenco Pokemon';

    //     $pokemons = pokemon::where('Type_1', $type)->orWhere('Type_2', '=', $type)->get();

    //     $types = Pokemon::query()->select('Type_1')->distinct()->orderByDesc('Type_1')->pluck('Type_1');

    //     return view('pokemon.index', compact('title', 'pokemons', 'types'));
    // }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        $title = 'Nuovo Pokemon';
        return view('pokemon.create', compact('title'));
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        // pokemon::create($request);
        // return response($request);
        // TODO: check no valori NULL
    }

    /**
     * Display the specified resource.
     */
    public function show(pokemon $pokemon)
    {
        $title = 'Dettaglio Pokemon';

        $json = json_decode(file_get_contents(API . $pokemon->Name), true);

        $img = $json['sprites']['front_default'];

        return view('pokemon.show', compact('title', 'pokemon', 'img'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(pokemon $pokemon)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, pokemon $pokemon)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(pokemon $pokemon)
    {
        //
    }
}
