<?php

// TODO il punteggio dovrebbe dipendere dalla difficultà
// TODO: non scegliere 2 volte lo stesso paese come risposta

namespace App\Http\Controllers;

use App\Models\Country;
use Illuminate\Http\Request;

class QuizController extends Controller
{
    /**
     * Prepara il soggetto e le risposte per il quiz
     * @param array $countries
     * @param int $answersNumber
     * @param string $subjectKey
     * @param callable $mappingFunc funzione passata a array_map
     * @return array{answers: array, subject: mixed}
     */
    private function prepareQuiz(array $countries, int $answersNumber, string $subjectKey, callable $mappingFunc)
    {
        // prende 4 indici casuali dell'array, poi vengono mischiati (array_rand li restituisce in ordine)
        $randomIndexes = array_rand($countries, $answersNumber);
        shuffle($randomIndexes);

        // recupera i valori dagli indici casuali
        $possibleAnswers = [];
        foreach ($randomIndexes as $i) {
            $possibleAnswers[] = $countries[$i];
        }

        // sceglie un valore causale come risposta corretta
        $correctIndex = array_rand($possibleAnswers);
        $correctAnswer = $possibleAnswers[$correctIndex];

        // imposta il soggetto della risposta in base a $subjectKey
        $subject = $correctAnswer[$subjectKey];
        // imposta le risposte in base a $mappingFunc
        $answers = array_map($mappingFunc, $possibleAnswers);

        return ['subject' => $subject, 'answers' => $answers];
    }

    public function getQuizCapital()
    {
        if (!session()->get('valid')) {
            return redirect(route('home'));
        }

        $title = 'Quiz Capitali';

        $countries = Country::all()->toArray();

        ['subject' => $subject, 'answers' => $answers] = $this->prepareQuiz($countries, 4, 'name', function ($country) {
            return $country['capital'];
        });

        $sessionData = [];
        $sessionData['games'] = session()->get('games');
        $sessionData['score'] = session()->get('score');
        $sessionData['difficulty'] = session()->get('difficulty');

        return view('quiz.quiz', compact('title', 'subject', 'answers', 'sessionData'));
    }

    public function postQuizCapital(Request $request)
    {
        if (!session()->get('valid')) {
            return redirect(route('home'));
        }

        $title = 'Quiz Capitali';

        $countries = Country::all()->toArray();

        // check risposta precedente
        $answerIsCorrect = array_any($countries, function ($country) use ($request) {
            return $country['name'] == $request['subject'] && $country['capital'] == $request['answer'];
        });

        // aggiorna dati sessione
        session()->increment('games');
        if ($answerIsCorrect) {
            session()->increment('score');
        }
        $sessionData = [];
        $sessionData['games'] = session()->get('games');
        $sessionData['score'] = session()->get('score');
        $sessionData['difficulty'] = session()->get('difficulty');

        // prepara messaggio esito risposta precedente
        $message = $answerIsCorrect ? 'risposta corretta' : 'risposta errata';
        $messageColor = $answerIsCorrect ? 'green' : 'red';

        // preparazione quiz
        ['subject' => $subject, 'answers' => $answers] = $this->prepareQuiz($countries, 4, 'name', function ($country) {
            return $country['capital'];
        });

        return view('quiz.quiz', compact(
            'title',
            'subject',
            'answers',
            'message',
            'messageColor',
            'sessionData'
        ));
    }

    public function getQuizFlags()
    {
        if (!session()->get('valid')) {
            return redirect(route('home'));
        }

        $title = 'Quiz Bandiere';

        $countries = Country::all()->toArray();

        ['subject' => $subject, 'answers' => $answers] = $this->prepareQuiz($countries, 4, 'name', function ($country) {
            return $country['alpha2Code'];
        });

        $sessionData = [];
        $sessionData['games'] = session()->get('games');
        $sessionData['score'] = session()->get('score');
        $sessionData['difficulty'] = session()->get('difficulty');

        return view('quiz.flags', compact('title', 'subject', 'answers', 'sessionData'));
    }

    public function postQuizFlags(Request $request)
    {
        if (!session()->get('valid')) {
            return redirect(route('home'));
        }

        $title = 'Quiz Bandiere';

        $countries = Country::all()->toArray();

        // check risposta precedente
        $answerIsCorrect = array_any($countries, function ($country) use ($request) {
            return $country['name'] == $request['subject'] && $country['alpha2Code'] == $request['answer'];
        });

        // aggiorna dati sessione
        session()->increment('games');
        if ($answerIsCorrect) {
            session()->increment('score');
        }
        $sessionData = [];
        $sessionData['games'] = session()->get('games');
        $sessionData['score'] = session()->get('score');
        $sessionData['difficulty'] = session()->get('difficulty');

        // prepara messaggio esito risposta precedente
        $message = $answerIsCorrect ? 'risposta corretta' : 'risposta errata';
        $messageColor = $answerIsCorrect ? 'green' : 'red';

        // preparazione quiz
        ['subject' => $subject, 'answers' => $answers] = $this->prepareQuiz($countries, 4, 'name', function ($country) {
            return $country['alpha2Code'];
        });

        $sessionData = [];
        $sessionData['games'] = session()->get('games');
        $sessionData['score'] = session()->get('score');
        $sessionData['difficulty'] = session()->get('difficulty');

        return view('quiz.flags', compact('title', 'subject', 'answers', 'sessionData', 'message', 'messageColor'));
    }
}
