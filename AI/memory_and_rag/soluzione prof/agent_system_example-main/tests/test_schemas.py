"""
Test per schemas.py — validazione Pydantic.

Verifica che i tre schemi accettino i valori attesi e che
i campi opzionali abbiano i default corretti.
"""

import pytest
from schemas import SecurityOutput, WarningOutput, ReactOutput


class TestSecurityOutput:
    def test_valid_acceptance(self):
        o = SecurityOutput(validation=True)
        assert o.validation is True
        assert o.motivation == ""

    def test_valid_rejection(self):
        o = SecurityOutput(validation=False, motivation="Linguaggio offensivo")
        assert o.validation is False
        assert "offensivo" in o.motivation

    def test_from_json(self):
        o = SecurityOutput.model_validate_json('{"validation": true, "motivation": ""}')
        assert o.validation is True

    def test_missing_motivation_defaults_empty(self):
        o = SecurityOutput.model_validate_json('{"validation": false}')
        assert o.motivation == ""


class TestWarningOutput:
    def test_session_active(self):
        o = WarningOutput(validation=True)
        assert o.validation is True
        assert o.motivation == ""

    def test_session_blocked(self):
        o = WarningOutput(validation=False, motivation="Troppi rifiuti")
        assert not o.validation
        assert o.motivation

    def test_from_json(self):
        raw = '{"validation": false, "motivation": "Sessione bloccata"}'
        o = WarningOutput.model_validate_json(raw)
        assert not o.validation


class TestReactOutput:
    def test_empty_defaults(self):
        o = ReactOutput()
        assert o.rejected == ""
        assert o.search == ""
        assert o.answer == ""

    def test_answer_field(self):
        o = ReactOutput(answer="La risposta è X.")
        assert o.answer == "La risposta è X."
        assert o.search == ""

    def test_search_field(self):
        o = ReactOutput(search="bandi regionali SIARB")
        assert o.search == "bandi regionali SIARB"
        assert o.answer == ""

    def test_rejected_field(self):
        o = ReactOutput(rejected="Non pertinente al manuale")
        assert o.rejected
        assert o.answer == ""

    def test_from_json_partial(self):
        raw = '{"rejected": "", "search": "", "answer": "Risposta trovata."}'
        o = ReactOutput.model_validate_json(raw)
        assert o.answer == "Risposta trovata."
