<?php

namespace App\Http\Controllers;

use App\Models\Transaction;
use Illuminate\Http\Request;

class TransactionController extends Controller
{
    /**
     * Display a listing of the resource.
     */
    public function index()
    {
        if (!session()->has('login_id')) {
            return redirect('');
        }
        $login_id = session()->get('login_id');

        $title = 'Elenco Transazioni';

        $transactions = Transaction::where('login_id', $login_id)->get();

        return view('transactions.index', compact('title', 'transactions'));
    }

    /**
     * Show the form for creating a new resource.
     */
    public function create()
    {
        $title = 'Nuova transazione';

        return view('transactions.create', compact('title'));
    }

    /**
     * Store a newly created resource in storage.
     */
    public function store(Request $request)
    {
        if (!session()->has('login_id')) {
            return redirect('');
        }

        $validated = $request->validate([
            'description' => ['required', 'string', 'max:255'],
            'date' => ['required', 'date'],
            'amount' => ['required', 'numeric'],
            'category' => ['required', 'in:Affitto,Stipendio,Spese Generali,Altro'],
            'receipt' => ['nullable'],
        ]);

        $transaction = new Transaction();
        $transaction->login_id = session()->get('login_id');
        $transaction->description = $validated['description'];
        $transaction->date = $validated['date'];
        $transaction->amount = $validated['amount'];
        $transaction->category = $validated['category'];

        if ($request->hasFile('receipt')) {
            $transaction->receipt = $request->file('receipt')->store('receipts', 'public');
        } else {
            $transaction->receipt = $request->input('receipt');
        }

        $transaction->save();

        return redirect()->route('transactions.index');
    }

    /**
     * Display the specified resource.
     */
    public function show(Transaction $transaction)
    {
        //
    }

    /**
     * Show the form for editing the specified resource.
     */
    public function edit(Transaction $transaction)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     */
    public function update(Request $request, Transaction $transaction)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     */
    public function destroy(Transaction $transaction)
    {
        $transaction->delete();

        return redirect()->route('transactions.index');
    }
}
