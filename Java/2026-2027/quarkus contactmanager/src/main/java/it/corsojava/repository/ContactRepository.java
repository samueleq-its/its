package it.corsojava.repository;

import jakarta.enterprise.context.ApplicationScoped;

import io.quarkus.hibernate.orm.panache.PanacheRepository;

import it.corsojava.entity.Contact;

@ApplicationScoped
public class ContactRepository
		implements PanacheRepository<Contact> {

}