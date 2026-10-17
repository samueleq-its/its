# Esercizi sulle Pipeline di Aggregazione MongoDB

1. Contare gli studenti maggiorenni.
[
  {
    $match:
      /**
       * query: The query in MQL.
       */
      {
        eta: {
          $gte: 18
        }
      }
  },
  {
    $count:
      /**
       * Provide the field name for the count.
       */
      "studenti_maggiorenni"
  }
]
2. Mostrare nome, cognome ed email degli studenti della classe `3A`, ordinati per cognome e poi per nome, senza `_id`.
[
  {
    $match: {
      classe: "3A"
    }
  },
  {
    $project: {
      _id: 0,
      nome: 1,
      cognome: 1,
      email: 1
    }
  },
  {
    $sort: {
      cognome: 1,
      nome: 1,
    }
  }
]
3. Trovare i 10 studenti più grandi (a parità di età, ordine alfabetico per cognome).
[
  {
    $sort: { eta: -1, cognome: 1 },
  },
  {
    $limit: 10
  }
]
4. Contare gli studenti il cui nome inizia con la lettera `M`, senza distinzione tra maiuscole e minuscole.
[
  {
    $match: {
      nome: { $regex: "^[mM]"}
    }
  }
]
5. Ordinare gli studenti per cognome e nome e mostrare la terza pagina da 10 risultati.
[
  {
    $sort: {
      cognome: 1,
      nome: 1
    }
  },
  {
    $skip: 20
  },
  {
    $limit: 10
  }
]
6. Per gli studenti residenti a Torino creare il campo `nomeCompleto` (nome, spazio, cognome) mostrando anche `eta` e `classe`.
[
  {
    $match: {
      "indirizzo.citta": "Torino"
    }
  },
  {
    $addFields: {
      nomeCompleto: {$concat: ["$nome", " ", "$cognome"] }
    }
  },
  {
    $project: {
      _id: 0,
      nomeCompleto: 1,
      eta: 1,
      classe: 1
    }
  }
]
7. Calcolare l'età media di tutti gli studenti.
[
  {
    $unwind: "$voti"
  },
  {
    $group: {
      _id: null,
      mediaVoti: {
        $avg: "$voti.valore"
      }
    }
  }
]
8. Contare gli studenti per classe, ordinando dalla classe più numerosa.
[
  {
    $group: {
      _id: "$classe",
      studenti: {$sum: 1}
    }
  },
  {
    $sort: {
      studenti: -1
    }
  }
]
9. Sulle iscrizioni con esame sostenuto, calcolare in un'unica pipeline media, massimo e minimo di `votoFinale` e il numero di esami.
[
  {
    $group: {
      _id: "$corsoId",
      media: {$avg: "$votoFinale"},
      massimo: {$max: "$votoFinale"},
      minimo: {$min: "$votoFinale"},
      numeroEsami: {$sum: 1}
    }
  }
]
10. Per ogni città calcolare il numero di studenti e l'età media arrotondata a 2 decimali. Ordinare per numero di studenti decrescente.
[
  {
    $group: {
      _id: "$indirizzo.citta",
      numeroStudenti: {$sum: 1},
      etaMedia: {$avg: "$eta"},
    }
  },
  {
    $project: {
      _id: 0,
      citta: "$_id",
      etaMedia: {$round: ["$etaMedia", 2]}
    }
  }
]
11. Mostrare solo le classi con età media superiore a 17.
[
  {
    $group: {
      _id: "$classe",
      etaMedia: {$avg: "$eta"}
    }
  },
  {
    $match: {
      etaMedia: {$gt: 17}
    }
  }
]
12. Per ogni classe ottenere l'elenco senza duplicati delle città di residenza degli studenti e quante sono.

13. Calcolare la media dei voti di ogni studente e mostrare i 10 migliori.

14. Calcolare la media dei voti per materia, il voto massimo e il numero di voti registrati. Ordinare per media decrescente.

15. Contare gli studenti che hanno almeno un'insufficienza (voto minore di 6).

16. Mostrare nome, cognome e numero di voti degli studenti che hanno più di 5 voti.

17. Calcolare per ogni studente la media dei voti e assegnare l'esito `"promosso"` se la media è maggiore o uguale a 6, altrimenti `"bocciato"`. Contare quanti studenti ci sono per esito.

18. Calcolare l'anno di nascita di ogni studente (2026 meno l'età) e contare quanti studenti sono nati in ciascun anno, in ordine cronologico.

19. Trovare i 5 corsi con più iscritti, mostrando il nome del corso e il totale degli iscritti.

20. Per ogni corso calcolare la media del voto finale (solo esami sostenuti), mostrando nome del corso e docente. Ordinare dalla media più alta.

21. Trovare i 10 studenti iscritti a più corsi, mostrando nome, cognome, numero di iscrizioni e lista dei `corsoId`.

22. Calcolare i crediti totali conseguiti da ogni studente, considerando solo gli esami con `votoFinale` maggiore o uguale a 18, e mostrare i 10 studenti con più crediti.

23. Per ogni docente contare quanti studenti distinti seguono i suoi corsi.

24. Contare gli esami sostenuti per anno e mese, in ordine cronologico.

25. Calcolare, per ogni corso, il numero medio di giorni tra `dataIscrizione` e `dataEsame`, considerando solo gli esami sostenuti.

26. Per ogni classe calcolare il numero di studenti, la media dei voti scolastici, il numero totale di iscrizioni ai corsi e la media dei voti finali dei corsi (arrotondata a 2 decimali).

27. Per ogni corso calcolare la percentuale di iscritti che non ha ancora sostenuto l'esame, mostrando il nome del corso. Ordinare dalla percentuale più alta.

28. Assegnare a ogni esame sostenuto una fascia di voto (`"18-23"`, `"24-27"`, `"28-30"`) e contare quanti esami ricadono in ciascuna fascia.

29. Trovare quanti studenti non risultano iscritti a nessun corso.

30. Per ogni corso trovare lo studente con il voto finale più alto, mostrando nome e cognome dello studente, nome del corso e voto.
