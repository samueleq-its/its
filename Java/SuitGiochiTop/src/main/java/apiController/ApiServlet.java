package apiController;

import java.io.IOException;
import java.io.PrintWriter;

import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;

public abstract class ApiServlet extends HttpServlet {
	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		// TODO Auto-generated method stub
		super.doGet(req, resp);
		resp.setContentType("application/json");
		resp.setCharacterEncoding("UTF-8");
        
        String jsonResponse = getContent(req, resp);
        
        PrintWriter out = resp.getWriter();
        out.print(jsonResponse);
        out.flush();
	}
	
	abstract protected String getContent(HttpServletRequest request, HttpServletResponse response);
}
