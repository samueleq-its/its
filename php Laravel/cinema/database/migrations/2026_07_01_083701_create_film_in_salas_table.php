<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    /**
     * Run the migrations.
     */
    public function up(): void
    {
        Schema::create('film_in_salas', function (Blueprint $table) {
            $table->id();
            $table->foreignId('film_id')->constrained('films')->onDelete('cascade');
            $table->foreignId('cinema_id')->constrained('cinemas')->onDelete('cascade');
            $table->datetime('data');
            $table->integer('posti_rimanenti')->unsigned;
            $table->float('prezzo', 2)->unsigned;

            $table->timestamps();
        });
    }

    /**
     * Reverse the migrations.
     */
    public function down(): void
    {
        Schema::dropIfExists('film_in_salas');
    }
};
