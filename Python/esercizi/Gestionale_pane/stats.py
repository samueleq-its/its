import io_utils

trans_file = "./data/transazioni.txt"

def crea_report():
	data = io_utils.read_file(trans_file)
	if data == None:
		utils.errore("ERRORE: file transazioni.txt mancante")
		return
	tot_transazioni = 0
	tot_ricavo = 0
	pane_venduto = dict()
	#	>timestamp , totale_transazione
	#		codice_pane, quantità, subtotale
	#		...
	for line in data:
		if line.startswith(">"): #inizio di una transazione
			tot_transazioni += 1
			tot_ricavo += float(line.split(",")[1].strip())
			continue
		elementi = line.split(",")
		pane_venduto[elementi[0]] = pane_venduto.get(elementi[0], 0) + int(elementi[1])
	report = (
		"Totale transazioni: " + str(tot_transazioni) + "\n"
		"Tipi di pane venduto:\n"
		)
	for tipo in pane_venduto:
		report += tipo +" x "+ str(pane_venduto[tipo]) +"\n"
	report += "Ricavo totale: " + str(tot_ricavo) + "€\n"
	return report