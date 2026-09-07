<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prestiti.aspx.cs" Inherits="PrestitiVideotecaWebForm.Prestiti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Elenco Prestiti</h1>

    
    <asp:SqlDataSource ID="sdsPrestiti" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
        SelectCommand="SELECT Prestito.Id, Prestito.IdFilm, Prestito.Matricola, Prestito.DataPrestito, Prestito.DataRestituzione, Film.Titolo, Studente.Cognome, Studente.Nome FROM Prestito INNER JOIN Film ON Prestito.IdFilm = Film.Codice INNER JOIN Studente ON Prestito.Matricola = Studente.Matricola ORDER BY Prestito.DataPrestito DESC"
        UpdateCommand="UPDATE Prestito SET DataRestituzione = GETDATE() WHERE Id = @Id"
        >
        <UpdateParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
      
    
    <asp:LinkButton ID="lbtArchivio" runat="server" OnClick="lbtArchivio_Click">Archivio</asp:LinkButton>
    <asp:LinkButton ID="lbtNonRestituiti" runat="server" OnClick="lbtNonRestituiti_Click">Prestiti non restituiti</asp:LinkButton>

<asp:GridView ID="gvPrestiti" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="sdsPrestiti" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="25" Width="90%">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>  
        
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="False" InsertVisible="False" />
        <asp:BoundField DataField="Cognome" HeaderText="Cognome" SortExpression="Cognome" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
        <asp:BoundField DataField="Titolo" HeaderText="Titolo" SortExpression="Titolo" />
        <asp:BoundField DataField="DataPrestito" HeaderText="DataPrestito" SortExpression="DataPrestito" />
        <asp:BoundField DataField="DataRestituzione" HeaderText="DataRestituzione" SortExpression="DataRestituzione" />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="lbtRestituisci" runat="server" CausesValidation="False" CommandName="Update" Text="Restituisci"></asp:LinkButton>
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
