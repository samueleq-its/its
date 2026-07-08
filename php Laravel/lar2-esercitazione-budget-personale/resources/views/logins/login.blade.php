@extends("layouts.app")

@section("title", $title)

@section("content")
	<h1>{{ $title }}</h1>

	<form action="{{ route("logins.authenticate") }}" method="post">
		@csrf
		<input type="email" name="email" id="email" placeholder="email">
		<input type="password" name="password" id="password" placeholder="password">
		<input type="submit" value="log in">
	</form>
	<a href="{{ route("logins.register") }}" , role="button">registrati</a>
@endsection