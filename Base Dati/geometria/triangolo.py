from punto import Punto
from segmento import Segmento
from math import sqrt

class Triangolo:
    def __init__(self, A:Punto, B:Punto, C:Punto) -> None:
        self.A = A
        self.B = B
        self.C = C

        self.AB = Segmento(A,B)
        self.AC = Segmento(A,C)
        self.BC = Segmento(B,C)

    def perimetro(self):
        return self.AB.lunghezza() + self.AC.lunghezza() + self.BC.lunghezza()
    
    def area(self):
        sp = self.perimetro() / 2
        return sqrt(  sp * (sp -self.AB.lunghezza()) * (sp -self.AC.lunghezza()) * (sp -self.BC.lunghezza())  )

    def __str__(self) -> str:
        return f"Triangolo con perimentro di {self.perimetro()} e superficie di {self.area()}"