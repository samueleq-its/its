package it.corsojava.service;

import java.util.List;

import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import jakarta.transaction.Transactional;

import it.corsojava.entity.Contact;
import it.corsojava.repository.ContactRepository;

@ApplicationScoped
public class ContactService {

	@Inject
	ContactRepository repository;

	public List<Contact> findAll() {
		return repository.listAll();
	}

	public Contact findById(Long id) {
		return repository.findById(id);
	}

	@Transactional
	public Contact create(Contact contact) {
		repository.persist(contact);
		return contact;
	}

	@Transactional
	public Contact update(Long id, Contact data) {

		Contact contact = repository.findById(id);

		if (contact == null) {
			return null;
		}

		contact.nome = data.nome;
		contact.cognome = data.cognome;
		contact.email = data.email;
		contact.telefono = data.telefono;
		contact.azienda = data.azienda;
		contact.attivo = data.attivo;

		return contact;
	}

	@Transactional
	public boolean delete(Long id) {

		Contact contact = repository.findById(id);

		if (contact == null) {
			return false;
		}

		repository.delete(contact);
		return true;
	}
}