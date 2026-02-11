# Differenze tra compiler e interpreter
i linguaggi di programmazione si dividono principalmente tra **compilati** e **interpretati**  
i linguaggi compilati non sono direttamente eseguibili ma devono prima essere trasformati dal compilatore che legge l'intero file per poi tradurlo in linguaggio macchina mentre i linguaggi interpretati vengono direttamente eseguiti riga per riga dall'interprete

### principali differenze tra linguaggi compilati ed interpretati:
- i programmi fatti con linguaggi compilati hanno una velocità di esecuzione superiore in quanto sono già stati convertiti in codice binario e il compiler ha potuto ottimizarli mentre quelli scritti in linguaggi interpretati devono essere tradotti al momento dell'esecuzione
- il codice binario dei programmi compilati può essere eseguito direttamente sulla macchina mentre nei programmi interpretati è necessario prima installare l'interprete. Il codice sorgente dei programmi compilati non può essere eseguito
- non è necessario condividere il codice sorgente dei programmi compilati con l'utente finale e l'eseguibile in codice binario non permette di risalirci, mantenendo la confidenzialità del codice sorgente, mentre nei programmi interpretati il codice sorgente è necessariamente condiviso con chiunque debba eseguirlo
- i programmi compilati possono avere problemi di compatibilità su sistemi diversi da quelli per cui sono creati mentre i programmi interpretati possono essere lanciati su qualunque sistema sia disponibile il loro interprete
- in caso di errori il compilatori li restituisce tutti assieme, mentre l'interprete restituisce l'errore appena li trova, fermando l'esecuzione e rendendone più semplice la correzione
- i programmi interpretati possono essere rapidamente modificati o corretti senza doverne effettuare la compilazione dopo ogni modifica
- siccome il compilatore crea un nuovo file, richiede ulteriore spazio per memorizzarlo

<br>

# Livelli dei linguaggi di programmazione
i linguaggi di programmazione possono essere suddivisi a grandi linee tra linguaggi macchina, linguaggi assembly e linguaggy di alto livello  
- i linguaggi macchina sono gli unici comprensibili e quindi eseguibili dal computer, sono composti da stringe di 0 e 1 e ogni macchina ha la propria versione unica
- i linguaggi assembly sono una traduzione diretta delle istruzioni binarie del linguaggio macchina in stringhe leggibili da una persona. per poter essere eseguiti vengono tradotti in linguaggio macchina da un Assembler e come i linguaggi macchina sono unici per ogni macchina
- i linguaggi di alto livello sono i più vicini al normale linguaggio umano e di conseguenza i più facili da utilizzare per un programmatore. Per poter essere eseguti devono essere trasformati in linguaggio macchina o da un compilatore, che produce un file eseguibile dopo aver letto l'intero codice sorgente, o da un interprete, che traduce ed esegue una riga del codice alla volta



<br>

# Linguaggio Macchina e linguaggio Assembly

[link](https://www.spiceworks.com/soft-tech/machine-vs-assembly-language/)