package presentation;

import model.Prodotto;
import services.ProdottiService;
import services.ProdottiServicesImpl;

public class MagazzinoMVC {

    public static void main(String[] args) {

        ProdottiService service = new ProdottiServicesImpl();

        for(Prodotto p : service.findAll()){
            System.out.println(p);
        }
    }
}
