# 6. Images

## JPG
formato immagine di tipo raster:  
viene descritto ogni pixel

utilizza compressione lossy (cioè con perdita di informazioni) per ridurre le dimensioni dell'immagine, rendendolo un formato adatto per foto, sfondi e imamgini in cui la precisione del singolo pixel non sia fondamentale, ma non è adatto per testi e loghi i cui contorni devono essere ben definiti  
rappresenta i colori con 24 bit (16 milioni di colori) ma non supporta trasparenza  
non è ideale se in futuro potrebbe essere necessario apportare modifiche all'immagine  

## PNG
formato immagine di tipo raster:  
viene descritto ogni pixel

utilizza compressione lossless, risultando in immagini di dimensioni superiori rispetto al JPG ma mantenendo tutti i dettagli
come il JPG supporta colori a 24 bit ma supporta anche la trasparenza, rendendolo superiore al JPG per immagini che contengono testi o loghi dove mantiene una definizione superiore o sia necessaria la trasparenza, non è altrettanto adatto per foto dove la qualità del singolo pixel non è altrettanto importante

## GIF
formato immagine di tipo raster:  
viene descritto ogni pixel

supporto limitato per colori (256) e trasparenza
permette semplici animazioni, mostrando immagini diverse in sequenza
data la qualità limitata e le dimensioni relativamente elevate (ogni 'frame' è un immagine separata) non è generalmente adatto all'utilizzo su pagine web (nonostante sia ampiamente supportato)


## SVG
formato immagine di tipo vettoriale:
il contenuto è descritto tramite formule matematiche (es. un cerchio avrà un raggio e una posizione)

di dimensioni ridotte e facilmente compressibile (essendo solo testo), supporta trasparenza ed animazioni, è facilmente modificabile e l'immagine mantiene sempre la stessa qualità anche ingrandendola
è ideale per loghi, icone e disegni tecnici mentre non è adatto ad foto e immagini complesse che non possono essere facilmente descritti con formule

## AVIF
formato immagine di tipo raster:  
viene descritto ogni pixel

supporta sia compressione lossy che lossless, risultando di dimensioni inferiori e qualità superiore al JPG
supporta trasparenza e colori HDR
anche se è supportato dalla maggior parte dei browser non è supportato da browser più vecchi o non aggiornati
adatto per immagini che richiedono alta qualità

## WeBP
formato immagine di tipo raster:  
viene descritto ogni pixel

come AVIF, supporta compressione sia lossy che lossless, con compressione e qualità superiori a PNG
supporta trasparenza e animazioni
anche se è supportato dalla maggior parte dei browser non è supportato da browser più vecchi o non aggiornati
adatto come alternativa a JPG e PNG se il minor supporto da parte dei browser è accettabile