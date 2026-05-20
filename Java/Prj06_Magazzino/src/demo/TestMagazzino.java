package demo;

import model.*;

public class TestMagazzino {

	public static void main(String[] args) {
		Categoria c = new Categoria();
		Fornitore f = new Fornitore();
		Prodotto p = new Prodotto(1,"bici",1.99,10,c,f);
		
		System.out.println(p);

	}

}
