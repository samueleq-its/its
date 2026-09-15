package controller;

import java.util.ArrayList;
import java.util.List;

import model.Automobile;

public class AutomobiliCtrl {

	List<Automobile> automobili = new ArrayList<>();
	
	//viene eseguito prima del costruttore
	//può anche essere definito static (a che server?)
	{
		automobili.add(new Automobile("pandina","Fiat","Panda"));
		automobili.add(new Automobile("ferrarina","Ferrari","G450"));
		automobili.add(new Automobile("lamborghina","Lamborghini","Gialla"));
		automobili.add(new Automobile("audina","Audi","A2"));
	}
	
	
	public void addAutomobile(Automobile a) {
		automobili.add(a);
	}
	
	public List<Automobile> getAutomobili(){
		return automobili;
	}
}
