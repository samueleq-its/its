<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Studenti.aspx.cs" Inherits="PrestitiVideotecaWebForm.Studenti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Elenco Studenti</h1>

    
    <asp:SqlDataSource ID="sdsStudenti" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" 
        SelectCommand="Select * from Studente Where Cognome like '%' + @Cerca + '%' OR Nome like '%' + @Cerca + '%' OR Classe like '%' + @Cerca + '%' OR @Cerca IS NULL OR @Cerca='' ORDER BY Cognome, Nome">

        <SelectParameters>
            <asp:ControlParameter Name="Cerca" ControlID="txtCerca" PropertyName="Text" DefaultValue="NULL" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>


    <p>
    Cerca per <asp:TextBox ID="txtCerca" runat="server"></asp:TextBox>
        <asp:Button ID="btnCerca" runat="server" Text="Cerca"/>
</p>


<asp:GridView ID="gvElencoStudenti" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Matricola" DataSourceID="sdsStudenti" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" PageSize="25" Width="90%">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Matricola" HeaderText="Matricola" ReadOnly="True" SortExpression="Matricola" Visible="False" />
        <asp:BoundField DataField="Cognome" HeaderText="Cognome" SortExpression="Cognome" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
        <asp:BoundField DataField="Classe" HeaderText="Classe" SortExpression="Classe" />
        <asp:TemplateField ShowHeader="False">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="Seleziona" PostBackUrl='<%# Eval("Matricola","~/DettaglioStudente?matricola={0}") %>'></asp:LinkButton>
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
