@extends("layouts.app")

@section("title", $title)

@section("content")
    <h1>{{$title}}</h1>
    <!-- <p>questa è la sezione prodotti della nostra applicazione</p> -->

    @foreach ($prodotti as $prodotto)
        <article>
            <header>
                <h1>{{$prodotto->nome}}</h1>
            </header>
            <a href="{{ route('categorie', $prodotto->categoria) }}" class="btn">{{$prodotto->categoria}}</a>
            <a href="{{ route('products.show', $prodotto->id) }}" class="btn">Vedi scheda prodotto</a>
        </article>
    @endforeach


@endsection


