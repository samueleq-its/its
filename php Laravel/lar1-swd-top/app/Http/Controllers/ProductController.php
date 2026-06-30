<?php

namespace App\Http\Controllers;

use App\Models\Product;
use Illuminate\Http\Request;

class ProductController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        $title = 'i nostri prodotti';

        $prodotti = Product::all();

        return view('products.index', compact('title', 'prodotti'));
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
    public function show(Product $product)
    {
        $title = 'dettaglio prodotto';

        return view('products.show', compact('title', 'product'));
    }

    public function categorie(string $categoria)
    {
        $title = "I prodotti della categoria $categoria";
        $prodotti = Product::where('categoria', $categoria)->get();

        return view('products.index', compact('title', 'prodotti'));
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(string $id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, string $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(string $id)
    {
        //
    }
}
