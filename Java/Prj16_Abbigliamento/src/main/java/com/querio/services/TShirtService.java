package com.querio.services;

import java.util.List;

import com.querio.model.Maglia;

public interface TShirtService {
	
	List<Maglia> getmagliette();
	Maglia addMaglietta(String maglietta);

}
