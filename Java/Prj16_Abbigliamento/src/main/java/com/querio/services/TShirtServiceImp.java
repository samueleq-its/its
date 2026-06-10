package com.querio.services;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.querio.model.Maglia;

@Service
public class TShirtServiceImp implements TShirtService {

	@Autowired
	List<Maglia> magliette;

	@Override
	public List<Maglia> getmagliette() {
		
		Maglia m1 = new Maglia();
		m1.setColore("blu");
		m1.setLogo("ToP");
		m1.setPrezzo(15);
		
		Maglia m2 = new Maglia();
		m2.setColore("blu");
		m2.setLogo("ToP");
		m2.setPrezzo(15);
				
		Maglia m3 = new Maglia();
		m3.setColore("blu");
		m3.setLogo("ToP");
		m3.setPrezzo(15);
		
		return List.of(m1,m2,m3);
	}

	@Override
	public Maglia addMaglietta(String maglietta) {
		// TODO Auto-generated method stub
		return null;
	}

}
