<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioStudente.aspx.cs" Inherits="PrestitiVideoTecaWebForm.DettaglioStudente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Dettaglio Studente</h1>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Studente] WHERE ([Matricola] = @Matricola)">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="Matricola" QueryStringField="matricola" Type="Int32" />
        </SelectParameters>
</asp:SqlDataSource>

<asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" DataKeyNames="Matricola" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="50px" HorizontalAlign="Center" Width="60%">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
    <EditRowStyle BackColor="#999999" />
    <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
    <Fields>
        <asp:BoundField DataField="Matricola" HeaderText="Matricola" ReadOnly="True" SortExpression="Matricola" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
        <asp:BoundField DataField="Cognome" HeaderText="Cognome" SortExpression="Cognome" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="Classe" HeaderText="Classe" SortExpression="Classe" />
    </Fields>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

</asp:DetailsView>

    
    <asp:SqlDataSource ID="sdsPrestitiStutendteNonRestituiti" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT count(*) FROM [Studente] WHERE [Matricola] = @Matricola and DataRestituzione is not null">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="" Name="Matricola" QueryStringField="matricola" Type="Int32" />
        </SelectParameters>
</asp:SqlDataSource>

    <asp:FormView ID="fvNonRestituiti" runat="server" DataSourceID="sdsPrestitiStutendteNonRestituiti">
        Non Restituiti:
        <asp:Label ID="lblnonrestituiti" runat="server" text='<%# "non restituiti: {0}" %>'></asp:Label>

    </asp:FormView>


    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        SelectCommand="SELECT f.titolo, f.regista, p.id, p.dataprestito, p.datarestituzione FROM [Prestito] p  inner join film f on f.codice = p.idfilm WHERE ([matricola] = @matricola) ORDER BY [DataPrestito] DESC">
        <SelectParameters>
            <asp:QueryStringParameter Name="Matricola" QueryStringField="matricola" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
        <asp:BoundField DataField="DataPrestito" HeaderText="DataPrestito" SortExpression="DataPrestito" />
        <asp:BoundField DataField="DataRestituzione" HeaderText="DataRestituzione" SortExpression="DataRestituzione" />
        
        <!-- Sostituiti asp:DynamicField con asp:BoundField -->
        <asp:BoundField DataField="titolo" HeaderText="Titolo" SortExpression="titolo" />
        <asp:BoundField DataField="regista" HeaderText="Regista" SortExpression="regista" />
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
