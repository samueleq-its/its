@extends("layouts.app")

@section("title", $title)

@section("content")

	<h1>{{ $title }}</h1>

	<form action="{{ route("pokemon.store") }}" method="POST">
		@csrf
		<input type="text" name="Name" id="Name" placeholder="Nome">
		<input type="text" name="Type_1" id="Type_1" placeholder="Tipo 1">
		<input type="text" name="Type_2" id="Type_2" placeholder="Tipo 2">
		<input type="number" name="Total" id="Total" placeholder="Totale">
		<input type="number" name="HP" id="HP" placeholder="HP">
		<input type="number" name="Attack" id="Attack" placeholder="Attacco">
		<input type="number" name="Defense" id="Defense" placeholder="Difesa">
		<input type="number" name="Sp_Atk" id="Sp_Atk" placeholder="Attacco Speciale">
		<input type="number" name="Sp_Def" id="Sp_Def" placeholder="Difesa Speciale">
		<input type="number" name="Speed" id="Speed" placeholder="Velocità">
		<input type="number" name="Generation" id="Generation" placeholder="Generazione">
		<label for="Legendary">Leggendario <input type="checkbox" name="Legendary" id="Legendary"></label>
		<input type="submit" value="Crea">
	</form>

@endsection