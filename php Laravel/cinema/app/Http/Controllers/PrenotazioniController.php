<?php

namespace App\Http\Controllers;

use App\Models\prenotazioni;
use Illuminate\Http\Request;

class PrenotazioniController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
    $prenotazionis = Prenotazioni::all();
    return view("prenotazionis.index", compact("prenotazionis"));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        //
    }

    /**
     * Display the specified resource.
     */
    public function show(prenotazioni $prenotazioni)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(prenotazioni $prenotazioni)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, prenotazioni $prenotazioni)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(prenotazioni $prenotazioni)
    {
        //
    }
}
