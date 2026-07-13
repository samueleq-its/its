<?php

namespace App\Http\Controllers;

use App\Models\Country;
use Illuminate\Http\Request;

class QuizController extends Controller
{
    public function getQuizCapital()
    {
        $title = 'Quiz Capitali';

        $countries = Country::all()->toArray();

        $randomPicks = array_rand($countries, 4);
        shuffle($randomPicks);

        $answers = [];
        foreach ($randomPicks as $i) {
            $answers[] = $countries[$i];
        }

        $country = $answers[0]['name'];

        $capitals = array_map(function ($country) {
            return $country['capital'];
        }, $answers);

        return view('quiz.capitals', compact('title', 'country', 'capitals'));

        // TODO il numero di risposte errate dovrebbe essere deciso dalla difficoltà
        // TODO: non scegliere 2 volte lo stesso paese come risposta
    }

    public function postQuizCapital(Request $request)
    {
        // TODO non duplicare codice da getQuizCapital

        $title = 'Quiz Capitali';

        $countries = Country::all()->toArray();

        $randomPicks = array_rand($countries, 4);
        shuffle($randomPicks);

        $answers = [];
        foreach ($randomPicks as $i) {
            $answers[] = $countries[$i];
        }

        $country = $answers[0]['name'];

        $capitals = array_map(function ($country) {
            return $country['capital'];
        }, $answers);

        // Codice diverso da getQuizCapital da qui

        $answerIsCorrect = array_any($countries, function ($country) use ($request) {
            return $country['name'] == $request['country'] && $country['capital'] == $request['answer'];
        });

        $message = $answerIsCorrect ? 'risposta corretta' : 'risposta errata';
        $messageColor = $answerIsCorrect ? 'green' : 'red';

        return view('quiz.capitals', compact('title', 'country', 'capitals', 'message', 'messageColor'));
    }
}
