@extends("layouts.app")

@section("title", $title)

@section("content")
	<h1>{{ $title }}</h1>

	<form action="{{ route("logins.store") }}" method="post">
		@csrf
		<input type="text" name="name" id="name" placeholder="name">
		<input type="email" name="email" id="email" placeholder="email">
		<input type="password" name="password" id="password" placeholder="password">
		<input type="submit" value="registrati">
	</form>
@endsection