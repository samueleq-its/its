package controller;

import java.io.IOException;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import model.Automobile;

@WebServlet("/automobili")
public class AutosaloneController extends HttpServlet {

	private AutomobiliCtrl autoCtrl = new AutomobiliCtrl();

	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		/*
		 * resp.setContentType("application/json");
		 * resp.getWriter().print("{\"auto\":100}");
		 */

		String titolo = "Le nostre ultime novità";
		req.setAttribute("titolo", titolo);

		req.setAttribute("elenco", autoCtrl.getAutomobili());

		req.getRequestDispatcher("automobili.jsp").forward(req, resp);
	}

	@Override
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		if (request.getParameter("marca") != null && request.getParameter("modello")!=null) {
			String marca = request.getParameter("marca");
			String modello = request.getParameter("modello");
			
			Automobile a = new Automobile("automobile", marca,modello);
			autoCtrl.addAutomobile(a);
		}
		
		doGet(request, response);
	}

}
