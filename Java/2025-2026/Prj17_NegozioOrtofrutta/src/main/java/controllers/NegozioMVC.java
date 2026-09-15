package controllers;

import java.io.IOException;

import jakarta.servlet.ServletException;
import jakarta.servlet.annotation.WebServlet;
import jakarta.servlet.http.HttpServlet;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import services.NegozioService;
import services.NegozioServiceImp;

@WebServlet("/negozio")
public class NegozioMVC extends HttpServlet {

	private NegozioService service;
	
	public NegozioMVC() {
		this.service = new NegozioServiceImp();
		System.out.println("Negozio servlet costruito");
	}
	
	@Override
	protected void doGet(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
		// TODO Auto-generated method stub
		super.doGet(req, resp);
		var prodotti = this.service.getProdotti();
		System.out.println(prodotti);
	}
}
