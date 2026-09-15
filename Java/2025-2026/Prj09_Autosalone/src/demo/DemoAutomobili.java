package demo;

import java.sql.SQLException;
import java.util.List;

import model.Automobile;
import repos.AutomobiliDAO;

public class DemoAutomobili {

	public static void main(String[] args) throws SQLException {
		AutomobiliDAO dao = new AutomobiliDAO();
				
		List<Automobile> automobili = dao.findAll();
		
		for (Automobile a : automobili) {
			System.out.println(a);
		}
	}

}
