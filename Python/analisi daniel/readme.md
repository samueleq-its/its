# ANALISI: Gestine Parcheggio Aziendale

## Struttura:
`main`: Gestione interfaccia e interconnettore per gli oggetti (menù principale).

`dipentendi`: Posizionamento della classe Dipendenti con tutto il necessario per interagire con questo oggetto.

`postoParcheggio`: Posizionamento della classe PostoParcheggio con all'interno tutti i metodi per interagire con oggetto.

`db_utils`: Script dedicato all'interazione con il db, nessun altro file può interagire senza passare dalle funzioni di db_utils.

`dump`: Script per creare/resettare il database a 0.

`config`: Script per cose aggiuntive come un file di log e i colori all'interfaccia grafica.

---
## Funzionamento:

Il programma sarà scritto con il presupposto che sarà accessibile solo da un operatore specializzato che gestirà i posti assegnati, quindi **non** accessibile ai dipendenti direttamente.
Il programma permetterà la gestione dei dipendenti (creazione/rimozione/visualizzazione), dei posti (crazione/modifica/rimozione/visualizzazione) e delle assegnazioni (creazione/modifica/rimozione/visualizzazione).

## Database:

Nel database saranno presenti varie Entità e relazioni tra loro:
- `dipendenti`:
    - `cf` -> PRIMARY KEY - Utilizzato come ID
    - `nome` -> NOT NULL
    - `cognome` -> NOT NULL
    - `data_nascita` -> NOT NULL - gestito come stringa per semplicità
- `postiParcheggio`:
    - `id` -> Primary Key
    - `stato` -> NOT NULL DEFAULT ('libero') CHECK (IN('libero', 'assegnato'))- viene impostato alla creazione come libero e controlla sempre che il valora sia *libero* o *assegnato*.
- `assegnazioni`: 
    - `cf_dipendente` -> PRIMARY KEY UNIQUE FOREIGN KEY
    - `id_parcheggio` -> PRIMARY KEY UNIQUE FOREIGN KEY

> Si sarebbe anche potuto non creare una tabella *assegnazioni* e creare un campo aggiuntivo nel parcheggio che ha come foreign key il cf dei dipendenti, però si sarebbero dovute creare dei controlli aggiuntivi tramite back-end prima di inserire il valore dall'applicazione per non permettere duplicati, preferendo quindi una modifica fisica (nel caso di cambiamento di posto) invece che logica. Il tutto anche scelto perché lo trovo più ordinato e penso sia organizzato meglio e facile da leggere.

> Per il Codice Fiscale del dipendente si sarebbe anche potuto impostare il limite di 16 per essere più restrittivi, ma ho deciso di mantenerlo non specificato, così che nel caso il dipendente sia straniero e non abbia un codice fiscale italiano, ma utilizzi sulla carta d'identità un sistema del tutto differente sia comunque possibile inseriro all'interno senza conflitti.

## Cose aggiuntive:
