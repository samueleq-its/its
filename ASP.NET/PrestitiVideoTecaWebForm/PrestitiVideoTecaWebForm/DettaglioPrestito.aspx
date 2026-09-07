<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DettaglioPrestito.aspx.cs" Inherits="PrestitiVideoTecaWebForm.DettaglioPrestito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Dettaglio Prestito</h1>

    <asp:SqlDataSource ID="dsDettaglioPrestito" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Prestito] WHERE ([Id] = @Id)">
        <SelectParameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>


    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" DataKeyNames="Id" DataSourceID="dsDettaglioPrestito" ForeColor="#333333" GridLines="None" Height="50px" HorizontalAlign="Center" Width="60%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="IdFilm" HeaderText="IdFilm" SortExpression="IdFilm" />
            <asp:BoundField DataField="Matricola" HeaderText="Matricola" SortExpression="Matricola" />
            <asp:BoundField DataField="DataPrestito" HeaderText="DataPrestito" SortExpression="DataPrestito" />
            <asp:BoundField DataField="DataRestituzione" HeaderText="DataRestituzione" SortExpression="DataRestituzione" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>


</asp:Content>
