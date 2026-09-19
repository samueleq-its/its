package com.samuele.dto;

import java.util.List;

import lombok.AllArgsConstructor;
import lombok.Data;

@Data
@AllArgsConstructor
public class Quiz {

	/*
	 * anno
	 * titolo
	 * luogo
	 * civilta
	 * categoria
	 * descrizione
	 * 
	 * titolo avvenne la <Nascita della scrittura>?
	 * -> anno quando
	 * -> luogo dove
	 * 
	 * anno avvenne nel <3500 bc>
	 * -> titolo cosa
	 * 
	 * luogo avvenne in <Mesopotamia>
	 * -> titolo cosa
	 * 
	 * controlli:
	 * non ci devono essere coincidenze (stesso anno, stesso luogo)
	 * il titolo non deve contenere il luogo
	 * 
	 * Session
	 * - storico domande
	 * 
	 * DomandaGenerator
	 * genera nuove domande a seconda di difficolta e categoria
	 */

	private String domanda;
	private List<String> risposte;
	private String rispostaCorretta;

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Quiz other = (Quiz) obj;
		if (domanda == null) {
			if (other.domanda != null)
				return false;
		} else if (!domanda.equals(other.domanda))
			return false;
		return true;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((domanda == null) ? 0 : domanda.hashCode());
		return result;
	}

	// public boolean equals(Quiz other) {
	// return this.domanda == other.domanda;
	// }
}
