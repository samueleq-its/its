package services;

import java.util.List;

import entities.Prodotto;
import repos.ProdottoRepo;
import repos.ProdottoRepoImp;

public class NegozioServiceImp implements NegozioService {

	private ProdottoRepo repo = new ProdottoRepoImp();

	
	@Override
	public List<Prodotto> getProdotti() {
		return repo.getProdotti();
	}

	@Override
	public List<Prodotto> getProdottiByCategoria(String categoria) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Prodotto> getProdottiByOrigine(String origine) {
		// TODO Auto-generated method stub
		return null;
	}

}
