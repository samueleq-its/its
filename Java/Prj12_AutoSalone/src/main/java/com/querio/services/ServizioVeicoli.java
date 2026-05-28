package com.querio.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.querio.entities.Automobile;
import com.querio.repos.AutomobiliRepo;

@Service
public class ServizioVeicoli implements VeicoliService {

	@Autowired
	private AutomobiliRepo repoAuto;
	
	public List<Automobile> getAutomobili(){
		return repoAuto.findAll();
	}

	@Override
	public Automobile addAutomobile(Automobile a) {
		return repoAuto.save(a);
	}

	@Override
	public Automobile updateAutomobile(Automobile a) {
		return repoAuto.save(a);
	}

	@Override
	public void deleteAutomobile(int id) {
		repoAuto.deleteById(id);
	}

	@Override
	public Automobile getAutomobileById(int id) {
		
		return repoAuto.findById(id).orElse(null);
	}

	@Override
	public List<Automobile> getAllAutomobili() {
		return repoAuto.findAll();
	}
	
}
