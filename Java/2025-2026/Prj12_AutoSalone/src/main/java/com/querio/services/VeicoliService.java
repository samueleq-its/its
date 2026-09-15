package com.querio.services;

import java.util.List;

import com.querio.entities.Automobile;

public interface VeicoliService {

	Automobile addAutomobile(Automobile a);
	Automobile updateAutomobile(Automobile a);
	void deleteAutomobile(int id);
	Automobile getAutomobileById(int id);
	List<Automobile> getAllAutomobili();
	
}
