package connessione;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBMysql {

	private final String DB_NAME = "esercitazioni";
	private final String HOST = "jdbc:mysql://localhost/" + DB_NAME;
	private final String USER = "root";
	private final String PASS = "root";

	private Connection conn;

	private void Connetti() {
		try {
			this.conn = DriverManager.getConnection(HOST, USER, PASS);
			System.out.println("Connessione OK");
		} catch (Exception e) {
			System.err.println("Oh no, Non sei connesso");
		}
	}

	private void disconnetti() {
		if (this.conn != null) {
			try {
				this.conn.close();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

	public Connection getConnessione() {
		if (this.conn == null) {
			this.Connetti();
		}

		return this.conn;
	}


}
