"""
Schemi Pydantic per gli structured output degli agenti.

Ogni agente usa il proprio schema passato come `format=` alla chiamata Ollama,
che forza il modello a rispondere con JSON valido conforme alla struttura.
"""

from pydantic import BaseModel, Field


class SecurityOutput(BaseModel):
    """Output dell'agente di sicurezza."""
    validation: bool = Field(
        description="True se il messaggio e accettabile, False se contiene linguaggio tossico o violento."
    )
    motivation: str = Field(
        default="",
        description="Motivazione del rifiuto. Stringa vuota se il messaggio e accettabile."
    )


class WarningOutput(BaseModel):
    """Output dell'agente di controllo warning."""
    validation: bool = Field(
        description="True se la sessione puo continuare, False se superato il limite di rifiuti."
    )
    motivation: str = Field(
        default="",
        description="Motivazione del blocco. Stringa vuota se la sessione e attiva."
    )


class ReactOutput(BaseModel):
    """
    Output dell'agente ReAct. I tre campi sono alternativi: uno solo sara non vuoto.

    - rejected: domanda fuori scope rispetto al manuale.
    - search: chunk insufficienti. Contiene la query raffinata per MCP.
    - answer: risposta finale basata sui chunk trovati.
    """
    rejected: str = Field(
        default="",
        description="Compila solo questo campo se la domanda non riguarda il manuale SIARB."
    )
    search: str = Field(
        default="",
        description="Compila solo questo campo se i chunk non bastano. Scrivi una query raffinata."
    )
    answer: str = Field(
        default="",
        description="Compila solo questo campo se hai informazioni sufficienti. Scrivi la risposta."
    )
