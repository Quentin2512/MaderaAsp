<%@ Page Title="" Language="C#" MasterPageFile="~/Madera.Master" AutoEventWireup="true" CodeBehind="ListeDevis.aspx.cs" Inherits="MaderaAsp.ListeDevis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenu" runat="server">
    <h1>Liste des devis client</h1>
  
        <asp:SqlDataSource ID = "F1Champs"
                            ConnectionString = "<%$ ConnectionStrings: F1Champs%>"
                            DataSourceMode="DataReader"
                            ProviderName = "System.Data.SQLite"
                            SelectCommand = "select * from client"
                            runat = "server">
        </asp:SqlDataSource>
        <asp:GridView ID="F1ChampsView"
                      DataSourceID="F1Champs"
                      AutoGenerateColumns="true"
                      runat="server">
        </asp:GridView>

</asp:Content>
