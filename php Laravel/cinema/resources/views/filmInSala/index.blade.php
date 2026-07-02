@extends("layouts.app")
@section("content")
<h1>Elenco Film in Sala	</h1>
<ul>
	@foreach($filmInSalas as $filmInSala)
	<li>{{$filmInSala->data}}</li>

	@endforeach
</ul>
@endsection
