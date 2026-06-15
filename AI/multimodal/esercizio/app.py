from config import *
from repo import Repo
from agent import MultimodalAgent as Agent
from utils import embed

RESET = False


img_list = [
    CURRENT_DIR / "images" / "cane.jpg",
    CURRENT_DIR / "images" / "gatto.jpg",
    CURRENT_DIR / "images" / "salotto.jpg",
]

repo = Repo()
agent = Agent()

# inizializzazione DB

if RESET:
    repo.reset_collection()

# image -> description
descriptions = []
embeddings = []
for image in img_list:
    response = agent.describe(image_path=image)

    print(f"\n\n{response}\n\n")

    descriptions.append(response)
    embeddings.append(embed(response))

# embedding description



# interrogazione DB
# image -> description
# ricerca per embedding
#aggiunta immagine a db?

