Resoconto / Prompt: applicare tema scuro, brand centrato, nav a destra e pulsanti per azioni

Obiettivo
- Tema scuro globale (sfondo scuro, testo chiaro).
- Brand (titolo sito) centrato nella navbar.
- Link della navbar allineati a destra.
- Link d'azione (Create / Edit / Details / Delete) con aspetto di pulsanti.
- Tabelle scure con testo bianco.

File da modificare
- `Views/Shared/_Layout.cshtml`
- `wwwroot/css/site.css`
- Tutte le view `Index` che mostrano tabelle e link d'azione (es. `Views/Studenti/Index.cshtml`, `Views/Films/Index.cshtml`, ecc.)

Istruzioni passo-passo (da eseguire su ciascun progetto simile)

1) Layout (navbar)
- Cambiare la navbar a tema scuro (Bootstrap):
  - sostituire `navbar-light bg-white` con `navbar-dark bg-dark` (se presente).
- Allineare i link a destra:
  - assicurarsi che l`<ul>` usi `ms-auto`: `<ul class="navbar-nav ms-auto">` (Bootstrap 5).
- Centrare il brand (opzioni):
  - Metodo robusto: aggiungere CSS che posizioni `.navbar-brand` al centro (vedi snippet CSS sotto).
  - Metodo semplice (se compatibile): usare `class="navbar-brand mx-auto"`.

2) Convertire link in pulsanti nelle view Index
- Sostituire i link di azione con `<a>` che usano classi Bootstrap `btn`:
  - Create: da `<a asp-action="Create">Create New</a>` a `<a asp-action="Create" class="btn btn-primary">Create New</a>`.
  - Righe tabella (Edit/Details/Delete):
    - `<a asp-action="Edit" asp-route-id="@item.Id" class="btn btn-sm btn-primary">Edit</a>`
    - `<a asp-action="Details" asp-route-id="@item.Id" class="btn btn-sm btn-secondary">Details</a>`
    - `<a asp-action="Delete" asp-route-id="@item.Id" class="btn btn-sm btn-danger">Delete</a>`

3) CSS globale (appendere in `wwwroot/css/site.css`)
- Aggiungere queste regole (adattare i colori se necessario):

```css
/* Theme */
body { background-color: #121212; color: #e6e6e6; }

/* Center brand */
.navbar { position: relative; }
.navbar-brand { position: absolute; left: 50%; transform: translateX(-50%); z-index: 2; color: #fff !important; }
.navbar-dark .nav-link { color: rgba(255,255,255,0.9) !important; }

/* Dark table overrides */
.table { background-color: transparent !important; color: #e6e6e6; border-color: rgba(255,255,255,0.08); }
.table th, .table td { color: #ffffff !important; background-color: transparent !important; border-top: 1px solid rgba(255,255,255,0.04) !important; }
.table.table-striped tbody tr:nth-of-type(odd) { background-color: rgba(255,255,255,0.02) !important; }
.table.table-hover tbody tr:hover { background-color: rgba(255,255,255,0.04) !important; }

/* Buttons inside tables */
.table a, .table a.btn, .table a.btn-sm { color: #ffffff !important; }
```

4) Verifiche post-modifica
- Build della soluzione (Build > Build Solution).
- Forzare refresh nel browser (Ctrl+F5) o cancellare cache.
- In DevTools -> Network verificare che `wwwroot/css/site.css` sia caricato.
- Controllare che non esistano classi come `bg-white` su `table` o stili inline che sovrascrivono gli override; se presenti rimuoverli o usare selettori più specifici.

Suggerimenti e note
- Le utility `ms-auto` e le classi `btn` sono di Bootstrap 5; se il progetto usa una versione diversa adattare le classi (es. `ml-auto` per Bootstrap 4).
- Se si vuole centrare il brand solo su schermi larghi, avvolgere il CSS di centratura in una media query `@media (min-width: 768px) { ... }`.
- Commit message suggerito: `feat(ui): dark theme, center navbar brand, right-align nav links, convert action links to buttons, dark table styles`

Esempio rapido di replacement (Index view)
- Cerca queste righe:
  - `<a asp-action="Create">Create New</a>`
  - `<a asp-action="Edit" asp-route-id="@item.Id">Edit</a> | <a asp-action="Details" ...>Details</a> | <a asp-action="Delete" ...>Delete</a>`
- Sostituisci con versioni `btn` (vedi esempi sopra).

Fine del prompt

Usa questo file come base per applicare le stesse modifiche ad altri progetti. Adattalo ai colori e alla versione di Bootstrap del progetto target.