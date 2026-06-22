from typing import Sequence

import ollama

from config import *



def embed(documento: str) -> Sequence[float]:
    return ollama.embed(model=EMBEDDING_MODEL, input=documento, options={"num_ctx ": 8192}).embeddings[0]



def inizializzazioneDB(img_list : list [Path], agent, repo ):
    descriptions = []
    embeddings = []
    for image in img_list:
        response = agent.describe(image_path=image)

        print(f"\n\n{response}\n\n")

        descriptions.append(response)
        embeddings.append(embed(response))

    # embedding description

    for i in range(len(img_list)):
        repo.insert(embeddings=embeddings[i],
                    description=descriptions[i],
                    img_path=str(img_list[i]),
                    )