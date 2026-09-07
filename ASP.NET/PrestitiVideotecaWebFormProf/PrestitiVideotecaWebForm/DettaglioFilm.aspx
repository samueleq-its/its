<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioFilm.aspx.cs" Inherits="PrestitiVideotecaWebForm.DettaglioFilm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Dettaglio Film<asp:DetailsView ID="dvDettaglioFilm" runat="server" AutoGenerateRows="False" CellPadding="4" DataKeyNames="Codice" DataSourceID="sdsFilm" ForeColor="#333333" GridLines="None" Height="50px" HorizontalAlign="Center" Width="60%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="Codice" HeaderText="Codice" InsertVisible="False" ReadOnly="True" SortExpression="Codice" />
            <asp:BoundField DataField="Titolo" HeaderText="Titolo" SortExpression="Titolo" />
            <asp:BoundField DataField="Supporto" HeaderText="Supporto" SortExpression="Supporto" />
            <asp:BoundField DataField="Regista" HeaderText="Regista" SortExpression="Regista" />
            <asp:BoundField DataField="Attori" HeaderText="Attori" SortExpression="Attori" />
            <asp:BoundField DataField="Genere" HeaderText="Genere" SortExpression="Genere" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        </asp:DetailsView>
    </h2>

<asp:SqlDataSource ID="sdsFilm" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
    SelectCommand="SELECT * FROM [Film] WHERE ([Codice] = @Codice)">
    <SelectParameters>
        <asp:QueryStringParameter Name="Codice" QueryStringField="codice" Type="Int32" />
    </SelectParameters>
    </asp:SqlDataSource>




</asp:Content>
