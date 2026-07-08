<?php

namespace App\Http\Controllers;

use App\Models\Login;
use Illuminate\Http\Request;
use Illuminate\Support\Facades\Hash;

class LoginController extends Controller
{
    public function login()
    {
        $title = 'Login';

        return view('logins.login', compact('title'));
    }

    public function register()
    {
        $title = 'Registrazione';

        return view('logins.register', compact('title'));
    }

    public function authenticate(Request $request)
    {
        $credentials = $request->validate([
            'email' => ['required', 'email'],
            'password' => ['required', 'string'],
        ]);

        $login = Login::where('email', $credentials['email'])->first();

        if (!$login || !Hash::check($credentials['password'], $login->password)) {
            return back()->withErrors([
                'email' => 'Credenziali non valide.',
            ])->onlyInput('email');
        }

        $request->session()->regenerate();

        $request->session()->put([
            'login_id' => $login->id,
            'login_name' => $login->name,
        ]);

        return redirect('');
    }

    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        //
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        //
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        $validated = $request->validate([
            'name' => ['required', 'string', 'max:100'],
            'email' => ['required', 'email', 'max:100', 'unique:logins,email'],
            'password' => ['required', 'string', 'min:8'],
        ]);

        $login = Login::create([
            'name' => $validated['name'],
            'email' => $validated['email'],
            'password' => Hash::make($validated['password']),
        ]);

        return redirect('logins');
    }

    /**
     * Display the specified resource.
     */
    public function show(Login $login)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Login $login)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Login $login)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Login $login)
    {
        //
    }
}
