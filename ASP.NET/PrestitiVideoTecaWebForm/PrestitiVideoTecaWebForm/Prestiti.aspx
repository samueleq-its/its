<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Prestiti.aspx.cs" Inherits="PrestitiVideoTecaWebForm.Prestiti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Elenco Prestiti</h1>

    <asp:SqlDataSource ID="sdsPrestiti" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>"
        SelectCommand="SELECT Prestito.Id, Prestito.IdFilm, Prestito.Matricola, Prestito.DataPrestito, Prestito.DataRestituzione, Film.Titolo, Studente.Cognome, Studente.Nome FROM Prestito INNER JOIN Film ON Prestito.IdFilm = Film.Codice INNER JOIN Studente ON Prestito.Matricola = Studente.Matricola ORDER BY Prestito.DataPrestito DESC, Prestito.DataRestituzione DESC"
        UpdateCommand="Update prestito set DataRestituzione = getdate() where id = @id"
        >

        <UpdateParameters>
            <asp:Parameter Name="id" Type="Int32" />
        </UpdateParameters>

    </asp:SqlDataSource>

    <asp:LinkButton ID="lntArchivio" runat="server" OnClick="lntArchivio_Click">Archivio</asp:LinkButton>
    <asp:LinkButton ID="lbnNonRestituiti" runat="server" OnClick="lbnNonRestituiti_Click">Non restituiti</asp:LinkButton>

<asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Id" DataSourceID="sdsPrestiti" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" Width="80%" PageSize="20">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" Visible="False" />
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
