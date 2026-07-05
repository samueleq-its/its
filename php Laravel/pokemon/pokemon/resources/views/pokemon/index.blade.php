@extends("layouts.app")

@section("title", $title)

@section("content")

    <h1>{{ $title }}</h1>

    <div class="group">
        <form action="" method="GET" role="group">
            <select name="type">
                <option value=""></option>
                @foreach ($types as $type)
                    <option value="{{ $type }}" @selected($selectedType === $type)>{{ $type }}</option>
                @endforeach
            </select>
            <input type="submit" value="Filtra">
        </form>
        <a href="{{ route("pokemon.index") }}" role="button">Tutti</a>
    </div>

    <table>
        <thead>
            <th>Nome</th>
            <th>Tipo 1</th>
            <th>Tipo 2</th>
            <th>Generazione</th>
        </thead>
        <tbody>

            @foreach ($pokemons as $pokemon)
                <tr>
                    <td>
                        <a href="{{ route("pokemon.show", $pokemon->Id) }}">{{ $pokemon->Name }}</a>
                    </td>
                    <td>
                        <a href="{{ route("pokemon.index", ["type" => $pokemon->Type_1]) }}">{{ $pokemon->Type_1}}</a>
                    </td>
                    <td>
                        <a href="{{ route("pokemon.index", ["type" => $pokemon->Type_2]) }}">{{ $pokemon->Type_2}}</a>
                    </td>
                    <td>{{ $pokemon->Generation}}</td>
                    <td></td>
                </tr>
            @endforeach

        </tbody>
    </table>
@endsection