<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class DefaultController extends Controller
{
    public function home()
    {
        if (!session()->get('valid')) {
            session()->start();
            session()->put([
                'valid' => true,
                'games' => 0,
                'score' => 0,
                'difficulty' => 4
            ]);
        }

        $title = 'Home';
        $difficulty = session()->get('difficulty');
        return view('home', compact('title', 'difficulty'));
    }

    public function postDifficulty(Request $request)
    {
        session()->put('difficulty', $request['difficulty']);
        return redirect('/');
    }

    public function quit()
    {
        session()->flush();
        return redirect('/');
    }
}
