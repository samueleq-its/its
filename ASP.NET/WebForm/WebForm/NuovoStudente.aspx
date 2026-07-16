<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuovoStudente.aspx.cs" Inherits="WebForm.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2> Nuovo Studente</h2>

    <asp:SqlDataSource ID="sdsNuovoStudente" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" InsertCommand="INSERT INTO Studente(Matricola, Nome, Email, Cognome, Classe) VALUES (@matricola, @nome, @email, @cognome, @classe)" ></asp:SqlDataSource>

</asp:Content>
