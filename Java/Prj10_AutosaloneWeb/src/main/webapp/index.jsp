<!DOCTYPE html>
<%@page import="java.util.List"%>
<%@page import="model.Veicolo"%>
<html>
<head>
<meta charset="UTF-8">
<title>Autosalone</title>
<link
  rel="stylesheet"
  href="https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.min.css"
>
</head>
<body>

	<div class = "container">
		<h1>Autosalone</h1>
		
		<%
			Veicolo v = new Veicolo("Moto da strada");
		
			//out.print("<h2>" + v + "</h2>");
			
			List<Veicolo> veicoli = List.of(v, new Veicolo("Auto top"));
			
			
		%>
		
		<% for (var x : veicoli){ %>
		
		<h2><%=x %></h2>
		
		<% } %>
		
	</div>

</body>
</html>