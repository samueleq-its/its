# Modello OSI/ISO
- Livello 1: Fisico , trasmissione bit
- Livello 2: Datalink, data frames, MAC
- Livello 3: Network, packets, IP
- Livello 4: Transport, TCP, UDP
- Livello 5: Session
- Livello 6: Presentation
- Livello 7: Application

# TCP vs UDP
**TCP**: con controllo errori, affidabile e ordinato, con connessione (statefull) 
**UDP**: più veloce, senza controllo errori (best effort), di ordine e senza connessione (stateless)

**TCP**  
durante la comunicazione vengono scambiati **sequence number** e **acknowledgement number**, valori incrementali per che identificano a quale messaggio si sta rispondendo (es client invia segmento con sequence number 31, serve risponde con sequence number 76 e acknowledgement number 31)

# Varie
**socket**: IP + Porta + Protocollo  
**Multiplexing**: più applicazioni condividono la stessa connessione di rete (es piu connessioni domestiche passano sullo stesso cavo fibra / rame)  
**Stateful vs Stateless**: statefull mantiene una connessione aperta (ha uno stato) mentre stateless ogni richiesta esiste a se stante
**URI** indentifica una risorsa, **URL** identifica una posizione

# INDIRIZZI IP

la quantita di indirizzi disponibili all'interno di una rete è dato da:  
2 ^<sup>n. bit host</sup> - 2 (indirizzo broadcast e identificativo di rete)

es: 192.168.1.0/24  
ha 8 bit dedicati agli host  
2^<sup>8</sup> - 2 = 254

oppure:  
indirizzo ip finale - indirizzo ip iniziale (+ 1 perchè si parte a contare da 0)
192.168.96.0/21  
iniziale => 192.168.96.0  
finale => 192.168.103.255  
totale disponibili = (103 - 96 + 1) * 256 - 2 = 2046  

# URI: URL / URN

**URL**  
Schema://user:password@host:porta/percorso?query#fragment

**URN** (Uniform Resource Locator)  
identifica una risorsa dal nome a priori dalla posizione  
es: urn:isbn:978-0-13-110362-7  
identifica un libro dall' isbn   

# Codici di stato HTTP

**1xx** informazione  
**2xx** successo (200 OK, 201 Created, 204 No content)
**3xx** Redirection (301, 302, 304)
**4xx** Client Error (400 bad request, 401 Unauthorized , 403 Forbidden, 404 Not Found )
**5xx** Server Error (500 Internal Server Error, 502 Bad Gateway, 503 Service Unavailable)

401 Unauthorized indica che è necessario fare il login  
403 Forbidden invece indica mancanza di permessi (anche a seguito di login)
