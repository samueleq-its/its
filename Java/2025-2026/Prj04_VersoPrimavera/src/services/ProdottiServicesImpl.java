package services;

import model.Prodotto;
import repos.ProdottoRepo;
import repos.ProdottoRepoImpl;

import java.util.List;

public class ProdottiServicesImpl implements ProdottiService{

    private ProdottoRepo prodottoRepo = new ProdottoRepoImpl();

    @Override
    public List<Prodotto> findAll() {
        return prodottoRepo.getProdotti();
    }
}
