@extends("layouts.app")
@section("content")
<h1>Elenco Cinema</h1>
<ul>
	@foreach($cinemas as $cinema)
	<li>{{$cinema->nome_cinema}}</li>

	@endforeach
</ul>
@endsection
