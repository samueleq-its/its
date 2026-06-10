"""
Test per utils/warning_guard.py

Usa tmp_path di pytest per isolare le scritture su file
senza toccare il WARNING.md reale del progetto.
"""

import pytest
from unittest.mock import patch


@pytest.fixture()
def tmp_warning(tmp_path):
    """Sovrascrive WARNING_FILE e MAX_WARNINGS con valori temporanei."""
    wf = tmp_path / "WARNING.md"
    with patch("utils.warning_guard.WARNING_FILE", wf), \
         patch("utils.warning_guard.MAX_WARNINGS", 3):
        yield wf


class TestWriteWarning:
    def test_creates_file_on_first_call(self, tmp_warning):
        from utils import warning_guard
        warning_guard.write_warning("ciao", "motivo test")
        assert tmp_warning.exists()

    def test_appends_entry(self, tmp_warning):
        from utils import warning_guard
        warning_guard.write_warning("msg1", "motivo1")
        warning_guard.write_warning("msg2", "motivo2")
        content = tmp_warning.read_text(encoding="utf-8")
        assert content.count("## [") == 2

    def test_contains_message_snippet(self, tmp_warning):
        from utils import warning_guard
        warning_guard.write_warning("messaggio speciale", "motivo")
        content = tmp_warning.read_text(encoding="utf-8")
        assert "messaggio speciale" in content

    def test_truncates_long_messages(self, tmp_warning):
        from utils import warning_guard
        long_msg = "x" * 1000
        warning_guard.write_warning(long_msg, "troppo lungo")
        content = tmp_warning.read_text(encoding="utf-8")
        assert "x" * 301 not in content


class TestCountWarnings:
    def test_zero_when_no_file(self, tmp_warning):
        from utils import warning_guard
        assert warning_guard.count_warnings() == 0

    def test_counts_entries(self, tmp_warning):
        from utils import warning_guard
        warning_guard.write_warning("a", "r1")
        warning_guard.write_warning("b", "r2")
        assert warning_guard.count_warnings() == 2


class TestRunWarning:
    def test_session_active_below_limit(self, tmp_warning):
        from utils import warning_guard
        for i in range(2):
            warning_guard.write_warning(f"msg{i}", "motivo")
        out = warning_guard.run()
        assert out.validation is True

    def test_session_blocked_above_limit(self, tmp_warning):
        from utils import warning_guard
        for i in range(4):   # > MAX_WARNINGS=3
            warning_guard.write_warning(f"msg{i}", "motivo")
        out = warning_guard.run()
        assert out.validation is False
        assert out.motivation != ""

    def test_session_active_at_limit(self, tmp_warning):
        from utils import warning_guard
        for i in range(3):   # esattamente MAX_WARNINGS, sessione ancora valida
            warning_guard.write_warning(f"msg{i}", "motivo")
        out = warning_guard.run()
        assert out.validation is True
