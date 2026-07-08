@extends("layouts.app")

@section("title", $title)

@section("content")

	<h1>{{ $title }}</h1>

	<a href="{{ route("transactions.create") }}" role="button">Nuova Transazione</a>

	<table>
		<thead>
			<th>Data</th>
			<th>Descrizione</th>
			<th>Importo</th>
			<th>Categoria</th>
			<th>Ricevute</th>
		</thead>
		<tbody>
			@foreach ($transactions as $transaction)

				<tr>
					<td>{{ $transaction->date }}</td>
					<td>{{ $transaction->description }}</td>
					<td>{{ $transaction->amount }}</td>
					<td>{{ $transaction->category }}</td>
					<td>{{ $transaction->receipt }}</td>
					<td><a href="" role="button">Modifica</a></td>
					<td>
						<form action="{{ route('transactions.destroy', $transaction->id) }}" method="post">
							@csrf
							@method('DELETE')
							<button type="submit" role="button">X</button>
						</form>
					</td>

				</tr>

			@endforeach
		</tbody>
	</table>

@endsection