<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Studenti.aspx.cs" Inherits="PrestitiVideoTecaWebForm.Studenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Elenco Studenti</h1>
    <asp:SqlDataSource ID="dsStudenti" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Studente] ORDER BY [Cognome], [Nome]"></asp:SqlDataSource>
  

    <p>
        Cerca per <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">LinkButton</asp:LinkButton>
    </p>

    <asp:FormView ID="FormView1" runat="server"></asp:FormView>

    <asp:GridView ID="gvElencoStudenti" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Matricola" DataSourceID="dsStudenti" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="25" Width="90%">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Matricola" HeaderText="Matricola" ReadOnly="True" SortExpression="Matricola" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Cognome" HeaderText="Cognome" SortExpression="Cognome" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Classe" HeaderText="Classe" SortExpression="Classe" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleziona" PostBackUrl='<%# Eval("Matricola", "~/DettaglioStudente?matricola={0}") %>'></asp:LinkButton>
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
