@extends("layouts.app")

@section("title", $title)

@section("content")
	<div>
		<a href="{{ route("quiz.getCapitals") }}" role="button">Quiz Capitali</a>
		<a href="{{ route("quiz.getFlags") }}" role="button">Quiz Bandiere</a>
		<a href="{{ route("training.index") }}" role="button">Allenamento</a>
	</div>
	<div>
		<form action="" method="POST">
			@csrf
			<label for="difficulty">Difficoltà</label>
			<select name="difficulty">
				<option value="2" @selected($difficulty == 2)>facile</option>
				<option value="3" @selected($difficulty == 3)>medio</option>
				<option value="4" @selected($difficulty == 4)>difficile</option>
			</select>
			<input type="submit" value="Imposta Difficoltà">
		</form>
	</div>
@endsection