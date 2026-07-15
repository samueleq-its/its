@extends("layouts.app")

@section("title", $title)

@section("content")
	<h1>{{ $title }}</h1>

	<table>
		<thead>
			<th></th>
		</thead>
		<tbody>
			@foreach ($countriesData as $countryData)
				<tr>
					<td><a href="{{ route("training.show", $countryData["code"]) }}">{{ $countryData["name"] }}</a></td>
				</tr>
			@endforeach

		</tbody>
	</table>

@endsection