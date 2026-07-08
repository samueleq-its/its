@extends("layouts.app")

@section("title", $title)

@section("content")

	<h1>{{ $title }}</h1>

	@if ($errors->any())
		<article>
			<strong>Correggi i seguenti errori:</strong>
			<ul>
				@foreach ($errors->all() as $error)
					<li>{{ $error }}</li>
				@endforeach
			</ul>
		</article>
	@endif

	<form method="POST" action="{{ route('transactions.store') }}" enctype="multipart/form-data">
		@csrf

		<label for="description">Descrizione</label>
		<input type="text" id="description" name="description" value="{{ old('description') }}" required>

		<label for="date">Data</label>
		<input type="date" id="date" name="date" value="{{ old('date') }}" required>

		<label for="amount">Importo</label>
		<input type="number" id="amount" name="amount" step="0.01" value="{{ old('amount') }}" required>

		<label for="category">Categoria</label>
		<select id="category" name="category" required>
			<option value="">Seleziona una categoria</option>
			<option value="Affitto" @selected(old('category') === 'Affitto')>Affitto</option>
			<option value="Stipendio" @selected(old('category') === 'Stipendio')>Stipendio</option>
			<option value="Spese Generali" @selected(old('category') === 'Spese Generali')>Spese Generali</option>
			<option value="Altro" @selected(old('category') === 'Altro')>Altro</option>
		</select>

		<label for="receipt">Ricevuta</label>
		<input type="file" id="receipt" name="receipt" accept="image/*,.pdf">

		<button type="submit">Salva transazione</button>
	</form>



@endsection