package repos;

import model.Prodotto;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public interface ProdottoRepo {
    public List<Prodotto> getProdotti();
    Optional<Prodotto> getProdottoById(int id);
    Prodotto addProdoto (Prodotto p);
    Prodotto updateProdoto (Prodotto p);
    void deleteProdotto(int id);
    void deleteProdotto(Prodotto prodotto);
}
