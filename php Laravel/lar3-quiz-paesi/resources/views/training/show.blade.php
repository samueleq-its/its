@extends("layouts.app")

@section("title", $title)

@section("content")
	<article>
		<h1>{{ $countryData['name'] }}</h1>

		<p>Codice: {{ $countryData['code'] }}</p>
		<p>Capitale: {{ $countryData['capital'] }}</p>
		<p>Lingua: {{ $countryData['language'] }}</p>
		<p>Popolazione: {{ $countryData['population'] }}</p>
		<p>Continente: {{ $countryData['region'] }}</p>
		<img src="/flags/{{ $countryData['code'] }}.png" alt="">
	</article>
	<a href="{{ route("training.index") }}" role="button">Indietro</a>
@endsection