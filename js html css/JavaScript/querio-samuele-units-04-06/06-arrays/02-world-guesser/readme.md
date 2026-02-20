# 2.Word Guesser
[Hangman game](https://en.wikipedia.org/wiki/Hangman_(game))
- Create two arrays:
    - one for the letters of the word (e.g. 'C', 'A', 'T')
    - Another for the current guessed letters (start with '_', '_', '_' and add the correct letters to it).
- Write a function called guessLetter that should:
    - Take one parameter, a letter.
    - Have a maximum number of guesses (e.g. 6)
    - Check if the letter is in the word array.
    - If the letter matches, add it in the correct position of the guessed array.
    - Show the user the current guessed letters.
    - Tell the user if they guessed a correct letter.
    - Tell the user how many guesses remain.
    - Tell the user if they won or lost the game.

Call your function to make guesses:  
guessLetter('G');  
guessLetter('I');  
guessLetter('O');  
guessLetter('A');  
guessLetter('T'); 
 
**Bonus**
- Add a random reward for correct guesses and subtract a random amount for failed
guesses.
- Show the user the total reward (positive or negative).
- Draw a hangman image to the console log after each guess.
- Add a function that generates the letters to guess randomly.
- Add a function that chooses the initial word to guess from an array of words.
