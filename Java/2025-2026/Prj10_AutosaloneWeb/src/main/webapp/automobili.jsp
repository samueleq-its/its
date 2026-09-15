<%@page import="model.Automobile"%>
<%@page import="java.util.List"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>
<body>
	<h1>Automobili</h1>
	<h2><%=request.getAttribute("titolo")%></h2>

	<%
	List<Automobile> automobili = (List<Automobile>) request.getAttribute("elenco");
	%>

	<form method="post">
		<input type="text" name="marca" placeholder="marca">
		<input type="text" name="modello" placeholder="modello">
		<button>Add new car</button>
	</form>

	<table>
		<tr>
			<th>Marca</th>
			<th>Modello</th>
		</tr>
		<% for (var a : automobili){ %>
		<tr>
			<td><%=a.getMarca() %></td>
			<td><%=a.getModello() %></td>
		</tr>
		<% } %>
	</table>



</body>
</html>