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
  },
  {
    $group: {
      _id: null,
      numero_studenti: {
        $sum: 1
      }
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
   $group: {
     _id: null,
     media_eta: {
       $avg: "$eta"
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
[
  {
    $group: {
      _id: "$classe",
      citta: {$addToSet: "$indirizzo.citta"}
    }
  }
]
13. Calcolare la media dei voti di ogni studente e mostrare i 10 migliori.
[
  {
    $unwind: {
      path: "$voti"
    }
  },
  {
    $group: {
      _id: "$studenteId",
      media: {$avg: "$voti.valore"}
    }
  },
  {
    $sort: {
    media: -1
  	}
  },
  {$limit: 10}
]
14. Calcolare la media dei voti per materia, il voto massimo e il numero di voti registrati. Ordinare per media decrescente.
[
  {
    $unwind: {
      path: "$voti"
    }
  },
  {
    $group: {
      _id: "$voti.materia",
      media: {$avg: "$voti.valore"},
      max: {$max: "$voti.valore"},
      numero_voti: {$sum: 1}
    }
  },
  {
    $sort: {
    	media: -1
  	}
  }
]
15. Contare gli studenti che hanno almeno un'insufficienza (voto minore di 6).
[
	{
	  $unwind: {
	    path: "$voti"
	  }
	},
  {
    $match: {
      "voti.valore": {$lt: 6}
    }
  },
  {
    $group: {
      _id: null,
      studenti_insufficienti: {
        $sum: 1
      }
    }
  }
]
16. Mostrare nome, cognome e numero di voti degli studenti che hanno più di 5 voti.
[
  {
    $addFields: {
      numero_voti: { $size: "$voti" }
    }
  },
  {
    $match: {
      numero_voti: { $gt: 5 }
    }
  },
  {
    $project: {
      _id: 0,
      nome: "$nome",
      cognome: "$cognome",
      numero_voti: "$numero_voti"
    }
  }
]
17. Calcolare per ogni studente la media dei voti e assegnare l'esito `"promosso"` se la media è maggiore o uguale a 6, altrimenti `"bocciato"`. Contare quanti studenti ci sono per esito.
[
  {
    $unwind: {
      path: "$voti"
    }
  },
  {
    $group: {
      _id: "$studenteId",
      media: {
        $avg: "$voti.valore"
      }
    }
  },
  {
    $addFields: {
      esito: {
        $cond: {
          if: {
            $gte: ["$media", 6]
          },
          then: "promosso",
          else: "bocciato"
        }
      }
    }
  },
  {
    $group: {
      _id: "$esito",
      numero_studenti: {
        $sum: 1
      }
    }
  }
]
18. Calcolare l'anno di nascita di ogni studente (2026 meno l'età) e contare quanti studenti sono nati in ciascun anno, in ordine cronologico.
[
  {
    $addFields: {
      anno_nascita: {$subtract: [2025, "$eta"]}
    }
  },
  {
    $group: {
      _id: "$anno_nascita",
      num_studenti: {
        $sum: 1
      }
    }
  }
]
19. Trovare i 5 corsi con più iscritti, mostrando il nome del corso e il totale degli iscritti.
[
  {
    $lookup: {
      from: "iscrizioni",
      localField: "corsoId",
      foreignField: "corsoId",
      as: "iscrizioni"
    }
  },
  {
    $unwind: {
      path: "$iscrizioni"
    }
  },
  {
    $group: {
      _id: "$nomeCorso",
      iscritti: {
        $sum: 1
      }
    }
  },
  {
    $sort:
      /**
       * Provide any number of field/order pairs.
       */
      {
        iscritti: -1
      }
  },
  {
    $limit:
      /**
       * Provide the number of documents to limit.
       */
      5
  }
]
20. Per ogni corso calcolare la media del voto finale (solo esami sostenuti), mostrando nome del corso e docente. Ordinare dalla media più alta.
[
  {
    $lookup: {
      from: "iscrizioni",
      localField: "corsoId",
      foreignField: "corsoId",
      as: "iscrizioni"
    }
  },
  {
    $unwind: {
      path: "$iscrizioni"
    }
  },
  {
    $group: {
      _id: {nomeCorso: "$nomeCorso", docente: "$docente"},
      mediaVotoFinale: {
        $avg: "$iscrizioni.votoFinale"
      }
    }
  },
  {
    $sort: {
      mediaVotoFinale: -1
    }
  },
 {
   $project: {
     _id: 0,
     nomeCorso: "$_id.nomeCorso",
     docente: "$_id.docente",
     mediaVotoFinale: "$mediaVotoFinale"
   }
 }
]
21. Trovare i 10 studenti iscritti a più corsi, mostrando nome, cognome, numero di iscrizioni e lista dei `corsoId`.
[
  {
    $group: {
      _id: "$studenteId",
      numCorsi: {
        $sum: 1
      },
      corsi: {
        $addToSet: "$corsoId"
      }
    }
  },
  {
    $sort: {
      numCorsi: -1
    }
  },
  {
    $limit: 10
  },
  {
    $lookup: {
      from: "studenti",
      localField: "_id",
      foreignField: "studenteId",
      as: "studente"
    }
  },
  {
    $unwind: {
      path: "$studente"
    }
  },
  {
    $project: {
      _id: 0,
      nome: "$studente.nome",
      cognome: "$studente.cognome",
      numCorsi: 1,
      corsi: 1
    }
  }
]
22. Calcolare i crediti totali conseguiti da ogni studente, considerando solo gli esami con `votoFinale` maggiore o uguale a 18, e mostrare i 10 studenti con più crediti.
[
  {
    $match: {
      votoFinale: {
        $gte: 18
      }
    }
  },
  {
    $lookup: {
      from: "corsi",
      localField: "corsoId",
      foreignField: "corsoId",
      as: "corsi"
    }
  },
  {
    $unwind: {
      path: "$corsi"
    }
  },
  {
    $group: {
      _id: "$studenteId",
      crediti: {
        $sum: "$corsi.crediti"
      }
    }
  },
  {
    $lookup: {
      from: "studenti",
      localField: "_id",
      foreignField: "studenteId",
      as: "studente"
    }
  },
  {
    $unwind:
      /**
       * path: Path to the array field.
       * includeArrayIndex: Optional name for index.
       * preserveNullAndEmptyArrays: Optional
       *   toggle to unwind null and empty values.
       */
      {
        path: "$studente"
      }
  }
]
23. Per ogni docente contare quanti studenti distinti seguono i suoi corsi.
[
  {
    $lookup: {
      from: "iscrizioni",
      localField: "corsoId",
      foreignField: "corsoId",
      as: "iscrizioni"
    }
  },
  {
    $unwind: {
      path: "$iscrizioni"
    }
  },
  {
    $group: {
      _id: {
        docente: "$docente",
        studenteId: "$iscrizioni.studenteId"
      }
    }
  },
  {
    $group: {
      _id: "$_id.docente",
      studenti: {
        $sum: 1
      }
    }
  }
]
24. Contare gli esami sostenuti per anno e mese, in ordine cronologico.
[
  {
    $match: {
      dataEsame: {
        $ne: null
      }
    }
  },
  {
    $addFields: {
      anno: {
        $year: "$dataEsame"
      },
      mese: {
        $month: "$dataEsame"
      }
    }
  },
  {
    $group: {
      _id: {
        anno: "$anno",
        mese: "$mese"
      },
      numeroEsami: {
        $sum: 1
      }
    }
  },
  {
    $sort: {
      _id: 1
    }
  },
  {
    $project: {
      _id: 0,
      anno: "$_id.anno",
      mese: "$_id.mese",
      numeroEsami: 1
    }
  }
]
25. Calcolare, per ogni corso, il numero medio di giorni tra `dataIscrizione` e `dataEsame`, considerando solo gli esami sostenuti.
[
  {
    $match: {
      dataEsame: {
        $ne: null
      }
    }
  },
  {
    $addFields: {
      tempoPassato: {
        $dateDiff: {
          startDate: "$dataIscrizione",
          endDate: "$dataEsame",
          unit: "day"
        }
      }
    }
  },
  {
    $group: {
      _id: "$corsoId",
      tempoMedio: {
        $avg: "$tempoPassato"
      }
    }
  }
]
26. Per ogni classe calcolare il numero di studenti, la media dei voti scolastici, il numero totale di iscrizioni ai corsi e la media dei voti finali dei corsi (arrotondata a 2 decimali).
[
  {
    $unwind: {
      path: "$voti"
    }
  },
  {
    $group:
      /**
       * _id: The id of the group.
       * fieldN: The first field name.
       */
      {
        _id: {
          studenteId: "$studenteId",
          classe: "$classe"
        },
        mediaVoti: {
          $avg: "$voti.valore"
        }
      }
  },
  {
    $lookup: {
      from: "iscrizioni",
      localField: "_id.studenteId",
      foreignField: "studenteId",
      as: "iscrizioni"
    }
  },
  {
    $unwind: {
      path: "$iscrizioni"
    }
  },
  {
    $match: {
      "iscrizioni.votoFinale": {
        $ne: null
      }
    }
  },
  {
    $group:
      /**
       * _id: The id of the group.
       * fieldN: The first field name.
       */
      {
        _id: "$_id.classe",
        mediaVoti: {
          $avg: "$mediaVoti"
        },
        mediaVotiEsame: {
          $avg: "$iscrizioni.votoFinale"
        },
        numeroIscrizioni: {
          $sum: 1
        }
      }
  },
  {
    $project: {
      _id: 0,
      classe: "$_id",
      mediaVoti: 1,
      mediaVotiEsame: 1,
      numeroIscrizioni: 1
    }
  }
]
27. Per ogni corso calcolare la percentuale di iscritti che non ha ancora sostenuto l'esame, mostrando il nome del corso. Ordinare dalla percentuale più alta.
[
  {
    $lookup: {
      from: "iscrizioni",
      localField: "corsoId",
      foreignField: "corsoId",
      as: "iscrizioni"
    }
  },
  {
    $unwind: {
      path: "$iscrizioni"
    }
  },
  {
    $group: {
      _id: "$corsoId",
      iscritti: {
        $sum: 1
      },
      esamiNonSostenuti: {
        $sum: {
          $cond: {
            if: {
              $eq: [
                "$iscrizioni.votoFinale",
                null
              ]
            },
            then: 1,
            else: 0
          }
        }
      }
    }
  },
  {
    $project:
      /**
       * specifications: The fields to
       *   include or exclude.
       */
      {
        _id: 0,
        nomeCorso: "$_id",
        percEsamiNonSostenuti: {
          $multiply: [
            100,
            {
              $divide: [
                "$esamiNonSostenuti",
                "$iscritti"
              ]
            }
          ]
        }
      }
  },
  {
    $sort:
      /**
       * Provide any number of field/order pairs.
       */
      {
        perEsamiNonSostenuti: 1
      }
  }
]
28. Assegnare a ogni esame sostenuto una fascia di voto (`"18-23"`, `"24-27"`, `"28-30"`) e contare quanti esami ricadono in ciascuna fascia.
???
29. Trovare quanti studenti non risultano iscritti a nessun corso.
[
  {
    $lookup: {
      from: "iscrizioni",
      localField: "studenteId",
      foreignField: "studenteId",
      as: "iscrizioni"
    }
  },
	{
	  $match: {
	    iscrizioni: {$size: 0}
	  }
	},
  {
    $group: {
      _id: null,
      studentiNonIscritti: {
        $sum: 1
      }
    }
  }
]
30. Per ogni corso trovare lo studente con il voto finale più alto, mostrando nome e cognome dello studente, nome del corso e voto.
[
  {
    $sort: {
      votoFinale: -1
    }
  },
  {
    $group: {
      _id: "$corsoId",
      votoMax: {
        $first: "$votoFinale"
      },
      studenteId: {
        $first: "$studenteId"
      }
    }
  },
  {
    $lookup: {
      from: "corsi",
      localField: "_id",
      foreignField: "corsoId",
      as: "corso"
    }
  },
  {
    $unwind: {
      path: "$corso"
    }
  },
  {
    $lookup: {
      from: "studenti",
      localField: "studenteId",
      foreignField: "studenteId",
      as: "studente"
    }
  },
  {
    $unwind: {
      path: "$studente"
    }
  },
  {
    $project: {
      _id:0,
      nome: "$studente.nome",
      cognome: "$studente.cognome",
      corso: "$corso.nomeCorso",
      voto: "$votoMax"
    }
  }
]