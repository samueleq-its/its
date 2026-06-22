from config import *
from utils import inizializzazioneDB
from repo import Repo
from agent import MultimodalAgent as Agent

img_list = [
    CURRENT_DIR / "images" / "cane.jpg",
    CURRENT_DIR / "images" / "gatto.jpg",
    CURRENT_DIR / "images" / "salotto.jpg",
]

repo = Repo()
agent = Agent()

# inizializzazione DB

usr_in = input("Reset DB? [y/N]")
match (usr_in.lower()):
    case "y":
        reset = True
    case "n":
        reset = False
    case _:
        reset = False

print(f"DB size: {repo.size()}")

if reset:
    repo.reset_collection()

if repo.size() != 0:
    print("DB già inizializzato")
else:
    print("inizializzazione DB")
    # image -> description
    inizializzazioneDB(
            img_list=img_list,
            agent=agent,
            repo=repo
            )

# in input riceve una descrizione o un immagine
# descrive l'immagine (se presente)
# restituisce un immagine simile
# aggiunge l'immagine al DB


# interrogazione DB
# image -> description
# ricerca per embedding
# aggiunta immagine a db?
