package repos;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import entities.Prodotto;

public class ProdottoRepoImp implements ProdottoRepo{

	private final String URL = "jdbc:mysql://localhost:3306/prj17";
	private final String USER = "root";
	private final String PASS = "root";
	
	private Connection conn;
	private Statement statement;
	private PreparedStatement ps;
	
	private ResultSet resultSet;
	
	
	public ProdottoRepoImp() {
		this.connetti();
	}
	
	private void connetti() {
		try {
			Class.forName("com.mysql.cj.jdbc.Driver");
			this.conn = DriverManager.getConnection(URL, USER, PASS);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	
	@Override
	public List<Prodotto> getProdotti() {
		List<Prodotto> prodotti = new ArrayList<Prodotto>();
		try {
			this.statement = this.conn.createStatement();
			this.resultSet = this.statement.executeQuery(FIND_ALL);
			while (resultSet.next()) {
				Prodotto p = new Prodotto(
						resultSet.getInt("id"),
						resultSet.getString("nome"),
						resultSet.getString("categoria"),
						resultSet.getString("origine"),
						resultSet.getDouble("prezzo_kg"),
						resultSet.getString("disponibilita")
						);
				prodotti.add(p);
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}		
		return prodotti;
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
