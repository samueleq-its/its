<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Studenti.aspx.cs" Inherits="WebForm.Studenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Elenco Studenti</h2>

    <asp:SqlDataSource ID="sdsStudenti" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Studente] ORDER BY [Cognome], [Nome]"></asp:SqlDataSource>

    <asp:SqlDataSource ID="sdsClasse" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="select distinct classe from studente order by classe"></asp:SqlDataSource>

    Cerca per classe:<asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="sdsClasse" DataTextField="classe" DataValueField="classe"></asp:DropDownList>
    
    <asp:LinkButton ID="LinkButton1" runat="server">Cerca</asp:LinkButton>
    
    <asp:GridView ID="gvStudenti" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="4" DataSourceID="sdsStudenti" ForeColor="#333333" GridLines="None" Width="100%" PageSize="20">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
