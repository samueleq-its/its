import utils
import io_utils

FILE_LIBRI = "DB_libri.txt"

def read_DB():
    '''
    restituisce dizionario dei libri
    {isbn: {"titolo": str, "autore": str, "n_copie": int}}
    '''
    file_data = io_utils.read_file(FILE_LIBRI)
    if file_data == None:
        utils.errore("ERRORE: file"+ FILE_LIBRI +"non trovato")
        exit()
    books = dict()
    for line in file_data:
        entry = line.strip().split(",")
        #ISBN = entry[0]
        #titolo = entry[1]
        #autore = entry[2]
        #n_copie = entry[3]
        books[int(entry[0])] = {
             "titolo":entry[1],
             "autore":entry[2],
             "n_copie":int(entry[3])
             }
    return books     

if __name__ == "__main__":
	print(read_DB())