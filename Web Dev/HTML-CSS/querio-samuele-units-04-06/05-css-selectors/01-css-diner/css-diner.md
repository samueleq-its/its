## CSS Diner - Selettori

Elenco dei selettori usati nell'esercizio "CSS Diner".

  
1. `plate`  
seleziona tutti gli elementi plate
  
2. `bento`  
seleziona tutti gli elementi bento e non quelli plate
  
3. `#fancy`  
seleziona l'elemento con attributo id="fancy"
  
4. `plate apple`  
seleziona gli elementi apple all'interno di un elemento plate
  
5. `#fancy pickle`  
seleziona gli elementi pickle all'interno di un elemento con attributo id="fancy"
  
6. `.small`  
seleziona tutti gli elementi con attributo class="small"
  
7. `orange.small`  
seleziona solo gli elementi orange con classe small
  
8. `bento orange.small`  
seleziona gli elementi orange con classe small all'interno di un elemento bento
  
9. `plate, bento`  
seleziona tutti gli elementi plate e bento
  
10. `*`  
seleziona ogni elemento
  
11. `plate *`  
seleziona ogni elemento contenuto dentro un elemento plate
  
12. `plate + apple`  
seleziona ogni elemento apple che sia immediatamente successivo ad un elemento plate
  
13. `pickle ~ pickle`  
seleziona ogni elemento pickle che sia successivo ad un altro elemento pickle
  
14. `plate > apple`  
seleziona ogni elemento apple che è figlio diretto di un elemento plate
  
15. `orange:first-child`  
seleziona gli elementi orange che sono i primi figli del proprio genitore
  
16. `plate *:only-child`  
seleziona gli elementi che sono l'unico figlio di un elemento plate
  
17. `:last-child.small`  
seleziona gli elementi con classe small che sono l'ultimo figlio del loro genitore
  
18. `plate:nth-child(3)`  
seleziona ogni elemento plate che è il terzo figlio del suo genitore
  
19. `bento:nth-last-child(3)`  
seleziona ogni elemento bento che è il terzo figlio contando dalla fine del suo genitore
  
20. `apple:first-of-type`  
seleziona ogni elemento apple quando è il primo del suo tipo tra i figli del genitore
  
21. `:nth-of-type(2n)`  
seleziona ogni secondo elemento dello stesso tipo
  
22. `plate:nth-of-type(2n+3)`  
seleziona ogni secondo elemento plate a partire dal terzo (3,5,7)
  
23. `apple:only-of-type`  
seleziona l'elemento apple se è l'unico del suo tipo all'interno del genitore
  
24. `:last-of-type.small`  
seleziona gli elementi con classe small che sono l'ultimo del loro stesso tipo nel genitore
  
25. `bento:empty`  
seleziona gli elementi bento che sono senza elementi figlio o contenuto
  
26. `apple:not(.small)`  
seleziona gli elementi apple che NON hanno la classe small
  
27. `[for]`  
seleziona gli elementi che possiedono l'attributo "for", indipendentemente dal suo valore
  
28. `plate[for]`  
seleziona gli elementi plate che hanno l'attributo "for", indipendentemente dal suo valore
  
29. `[for="Vitaly"]`  
seleziona gli elementi il cui attributo "for" è "Vitaly"
  
30. `[for^="S"]`  
seleziona gli elementi con attributo "for" che inizia con "S"
  
31. `[for$="to"]`  
seleziona gli elementi con attributo "for" che termina con "to"
  
32. `[for*="ob"]`  
seleziona gli elementi con attributo "for" che contengono la sottostringa "ob"  

