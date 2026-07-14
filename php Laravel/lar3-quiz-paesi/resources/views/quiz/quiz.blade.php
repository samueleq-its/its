@extends("layouts.app")

@section("title", $title)

@section("content")
	<h1>{{ $title }}</h1>

	<article class="card">
		<p>Giochi: {{ $sessionData["games"] }}</p>
		<p>Punteggio: {{ $sessionData["score"] }}</p>
		<p>Difficoltà: {{ $sessionData["difficulty"] }}</p>
	</article>

	@isset($message)
		<div @style(["color: $messageColor" => isset($messageColor)])>
			{{ $message }}
		</div>
	@endisset

	<h3>Qual'è la capitale di: {{ $subject }}</h3>
	<form action="" method="POST">
		@csrf
		<input type="hidden" name="subject" value="{{ $subject }}">
		@foreach ($answers as $answer)
			<button name="answer" value="{{ $answer }}">{{ $answer }}</button>
		@endforeach

	</form>

@endsection