@extends("layouts.app")
@section("content")
<h1>Elenco Prenotazioni</h1>
<ul>
	@foreach($prenotazionis as $prenotazioni)
	<li>{{$prenotazioni->posti_prenotati}}</li>

	@endforeach
</ul>
@endsection
