@extends("layouts.app")
@section("content")
<h1>Elenco Film</h1>
<ul>
	@foreach($films as $film)
	<li>{{$film->titolo}}</li>

	@endforeach
</ul>
@endsection
