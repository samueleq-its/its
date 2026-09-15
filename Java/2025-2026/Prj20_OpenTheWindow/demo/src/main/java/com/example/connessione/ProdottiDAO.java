package com.example.connessione;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.sql.Statement;

public class ProdottiDAO {

	private DBMysql db = new DBMysql();

	private Connection conn;

	private Statement statement;
	private PreparedStatement preparedStatement;

	public void addProdotto(
			String nome,
			String categoria,
			String giacenza,
			String prezzo) throws SQLException {

		this.conn = db.getConnessione();

		String query = """
				INSERT INTO prodotti (nome, categoria, giacenza, prezzo)
				VALUES (?,?,?,?)
				;
				""";

		this.preparedStatement = this.conn.prepareStatement(query);
		this.preparedStatement.setString(1, nome);
		this.preparedStatement.setString(2, categoria);
		this.preparedStatement.setString(3, giacenza);
		this.preparedStatement.setString(4, prezzo);

		this.preparedStatement.execute();
	}

	public static void main(String[] args) throws SQLException {
		ProdottiDAO dao = new ProdottiDAO();
		dao.addProdotto("test", "test", "1", "1.5");
	}

}
