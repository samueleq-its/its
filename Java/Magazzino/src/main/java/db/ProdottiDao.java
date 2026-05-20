package db;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ProdottiDao {

    private Conessione conessione = new Conessione();
    private Statement statement;
    private ResultSet rs;

    public void stampaProdotti() throws SQLException {
        String query = "Select * from magazzino.prodotti";

        statement = conessione.getConn().createStatement();

        rs = statement.executeQuery(query);
        while (rs.next()){
            String nome = rs.getString("nome");
            double prezzo = rs.getDouble("prezzo_unitario");

            System.out.println("Prodotto " + nome + " Prezzo " + prezzo);
        }
    }

    public static void main(String[] args) throws SQLException {
        ProdottiDao dao = new ProdottiDao();
        dao.stampaProdotti();
    }

}
