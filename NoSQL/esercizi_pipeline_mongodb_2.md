	# Esercizi sulle Pipeline di Aggregazione MongoDB (parte 2)

## Facili

31. Contare gli studenti della classe `5B`.

32. Mostrare nome, cognome e città degli studenti di 19 anni, ordinati per cognome e poi per nome, senza `_id`.

33. Contare le iscrizioni per cui l'esame non è ancora stato sostenuto.

34. Mostrare nome e docente dei corsi da 9 crediti, ordinati per nome del corso, senza `_id`.

35. Mostrare i primi 15 studenti in ordine alfabetico di cognome, con il cognome in maiuscolo e il nome in minuscolo.

36. Contare gli studenti che non risiedono a Torino.

37. Per i primi 20 studenti in ordine di `studenteId`, mostrare `studenteId` e le iniziali (prima lettera del nome e prima lettera del cognome, in maiuscolo).

38. Calcolare il totale dei crediti di tutti i corsi.

39. Contare quanti corsi insegna ciascun docente, ordinando dal docente con più corsi.

40. Mostrare nome e cognome degli studenti di età inferiore a 16 anni che risiedono ad Asti o a Cuneo.

## Medi

41. Per ogni materia contare quante insufficienze (voto minore di 6) sono state registrate, ordinando dalla materia con più insufficienze.

42. Per ogni città calcolare la media di tutti i voti scolastici degli studenti residenti, arrotondata a 2 decimali. Ordinare dalla media più alta.

43. Per ogni classe contare quanti studenti hanno una media dei voti scolastici maggiore o uguale a 7.

44. Per ogni corso contare quanti esami sono stati sostenuti con voto finale maggiore o uguale a 27, mostrando il nome del corso e ordinando dal corso con più voti alti.

45. Mostrare i 10 studenti con la media di `votoFinale` più alta tra quelli che hanno sostenuto almeno 3 esami, indicando `studenteId`, numero di esami e media arrotondata a 2 decimali.

46. Contare le iscrizioni per giorno del mese (di `dataIscrizione`) e mostrare i 5 giorni con più iscrizioni.

47. Per ogni studente della classe `4A` mostrare nome, cognome e numero di corsi a cui è iscritto, includendo anche gli studenti senza iscrizioni.

48. Calcolare i crediti totali dei corsi a cui è iscritto ciascuno studente (indipendentemente dal fatto che l'esame sia stato sostenuto) e mostrare i 10 studenti con più crediti, con nome e cognome.

49. Per ogni docente calcolare la media dei voti finali degli esami sostenuti nei suoi corsi e il numero di esami, mostrando solo i docenti con almeno 100 esami sostenuti.

50. Mostrare le email degli studenti iscritti ad almeno 6 corsi, insieme al numero di iscrizioni.

## Difficili

51. Per ogni classe trovare la materia con la media dei voti scolastici più alta, mostrando classe, materia e media arrotondata a 2 decimali.

52. Per ogni docente calcolare la percentuale di esami sostenuti nei suoi corsi con voto finale maggiore o uguale a 27, mostrando solo i docenti con almeno 50 esami sostenuti. Ordinare dalla percentuale più alta.

53. Per ogni città trovare lo studente con la media dei voti scolastici più alta tra quelli che hanno almeno 4 voti, mostrando città, nome, cognome e media.

54. Per ogni corso trovare la classe degli studenti con più iscritti, mostrando nome del corso, classe e numero di iscritti.

55. Trovare gli studenti con media dei voti scolastici maggiore o uguale a 8 e media dei voti finali dei corsi maggiore o uguale a 27, mostrando nome, cognome e le due medie arrotondate a 2 decimali.

56. Per ogni anno solare trovare il corso con più esami sostenuti, mostrando anno, nome del corso e numero di esami.

57. Calcolare la distribuzione degli studenti per numero di iscrizioni: per ogni valore (0, 1, 2, ...) quanti studenti hanno esattamente quel numero di iscrizioni, in ordine crescente.

58. Per ogni docente trovare lo studente che ha sostenuto più esami nei suoi corsi, mostrando docente, nome e cognome dello studente e numero di esami.

59. Per ogni classe calcolare la percentuale di studenti iscritti ad almeno un corso del docente `Prof. Ferrari`, ordinando dalla percentuale più alta.

60. Per ogni corso mostrare nome, docente, numero di iscritti, numero di esami sostenuti, voto finale medio e numero medio di giorni tra iscrizione ed esame, ordinando per voto finale medio decrescente.
