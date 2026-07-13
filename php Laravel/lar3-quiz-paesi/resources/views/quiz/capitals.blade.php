@extends("layouts.app")

@section("title", $title)

@section("content")
	<h1>{{ $title }}</h1>

	@isset($message)
		<div @style(["color: $messageColor" => isset($messageColor)])>
			{{ $message }}
		</div>
	@endisset

	<h3>Qual'è la capitale di: {{ $country }}</h3>
	<form action="" method="POST">
		@csrf
		<input type="hidden" name="country" value="{{ $country }}">
		@foreach ($capitals as $capital)
			<button name="answer" value="{{ $capital }}">{{ $capital }}</button>
		@endforeach

	</form>

@endsection