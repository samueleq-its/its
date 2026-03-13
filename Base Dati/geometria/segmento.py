from punto import Punto
from math import sqrt, pow

'''  '''

class Segmento:
    def __init__(self, A:Punto, B:Punto) -> None:
        self.A = A
        self.B = B

    def lunghezza(self):
        return sqrt(pow(self.B.x - self.A.x, 2) + pow(self.B.y - self.A.y, 2))

    def __str__(self) -> str:
        return f"Segmento di coordinate {self.A} - {self.B}; ha lunghezza {self.lunghezza()}"