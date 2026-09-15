package repos;

import model.Prodotto;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

public class ProdottoRepoImpl implements ProdottoRepo{

    private List<Prodotto> prodotti = new ArrayList<>();

    @Override
    public List<Prodotto> getProdotti() {
        // query al db
        // scorro il resultset
        //foreach per ogni record creo un oggetto di tipo prodotto

        // aggiungo il prodotto alla lista di prodotti
        prodotti.add(new Prodotto(10,15.2,"Rossa","Bici",1));
        // ritorno la lista di prodotti
        return prodotti;
    }

    @Override
    public Optional<Prodotto> getProdottoById(int id) {
        return Optional.empty();
    }

    @Override
    public Prodotto addProdoto(Prodotto p) {
        return null;
    }

    @Override
    public Prodotto updateProdoto(Prodotto p) {
        return null;
    }

    @Override
    public void deleteProdotto(int id) {

    }

    @Override
    public void deleteProdotto(Prodotto prodotto) {

    }
}
