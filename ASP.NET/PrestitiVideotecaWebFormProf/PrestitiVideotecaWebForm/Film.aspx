<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Film.aspx.cs" Inherits="PrestitiVideotecaWebForm.Film" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Elenco Film</h2>

    <asp:SqlDataSource ID="sdsFilm" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="Select * from Film ORDER BY [Titolo]">
        
    </asp:SqlDataSource>

    <p>
        Cerca per titolo <asp:TextBox ID="txtCerca" runat="server"></asp:TextBox><asp:Button ID="btnCerca" runat="server" Text="Cerca" OnClick="btnCerca_Click" />
    </p>





<asp:GridView ID="gvFilm" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codice" DataSourceID="sdsFilm" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="50" Width="90%">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Codice" HeaderText="Codice" InsertVisible="False" ReadOnly="True" SortExpression="Codice" Visible="False" />
        <asp:BoundField DataField="Titolo" HeaderText="Titolo" SortExpression="Titolo" />
        <asp:BoundField DataField="Supporto" HeaderText="Supporto" SortExpression="Supporto" Visible="False" />
        <asp:BoundField DataField="Regista" HeaderText="Regista" SortExpression="Regista" />
        <asp:BoundField DataField="Attori" HeaderText="Attori" SortExpression="Attori" />
        <asp:BoundField DataField="Genere" HeaderText="Genere" SortExpression="Genere" />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="lbtDettaglioFilm" runat="server" CausesValidation="False" Text="Dettaglio" PostBackUrl='<%# Eval("Codice","~/DettaglioFilm.aspx?codice={0}") %>'></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>


</asp:Content>
