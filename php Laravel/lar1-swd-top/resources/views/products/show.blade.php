@extends("layouts.app")

@section("title", $title)

@section("content")
    <h1>Benvenuti nella pagina prodotti</h1>
    <p>questa è la sezione prodotti della nostra applicazione</p>

	<article>
		<header>
			<h1>{{$product->nome}}</h1>
		</header>
		<p>{{$product->categoria}}</p>
		<p>{{$product->prezzo}}</p>
		<p>{{$product->giacenza}}</p>
		<a href="{{ route('products.index') }}" class="btn">Vedi scheda products</a>
	</article>



@endsection


