<?php
class Hangman
{
    public string $player1;
    public string $player2;

    /**
     * Summary of gioca
     * @param string $parola
     * @return string
     */
    public function gioca(string $parola): string
    {
        //logica del gioco
        return "Si gioca";
    }
}

$impiccato1 = new Hangman();
echo $impiccato1->player1 = "Mario";
echo $impiccato1->player2 = "PC";

echo $impiccato1->gioca("parametro");