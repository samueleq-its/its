package controller;

import java.io.IOException;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

@WebServlet("/home")
public class HomeController extends HttpServlet{
	
	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		// resp.getWriter().print("hai chiamato la servlet via GET");
		
		// resp.sendRedirect("index.jsp");
		if(req.getParameter("pagina") != null) {
			String pagina = req.getParameter("pagina");
			resp.getWriter().print("hai richiesto la pagina:" + pagina);
		} else {
			req.getRequestDispatcher("index.jsp").include(req, resp);
		}
	}
}
