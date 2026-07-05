@extends("layouts.app")

@section("title", $title)

@section("content")

	<h1>{{ $title }}</h1>

	<article class="card">
		<header>
			<h1>{{ $pokemon->Name }}</h1>
			<img src="{{ $img }}">
			<p>Tipo 1: {{ $pokemon->Type_1 }}</p>
			<p>Tipo 2: {{ $pokemon->Type_2 }}</p>
			<p>Hp: {{ $pokemon->HP }}</p>
			<p>Attacco: {{ $pokemon->Attack }}</p>
			<p>Difesa: {{ $pokemon->Defense }}</p>
			<p>Velocità: {{ $pokemon->Speed }}</p>
			<p>Generazione: {{ $pokemon->Generation }}</p>
			<a href="{{ route("pokemon.index") }}" role="button">indietro</a>
		</header>
	</article>

@endsection