<%@ Page Title="" Language="C#" MasterPageFile="~/Madera.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="MaderaAsp.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenu" runat="server">
    <div class="btns">
        <div class="col-sm-6 col-xs-12 text-center"><asp:Button class="btn btnHome" ID="btnVisu" runat="server" OnClick="btnVisu_Click" Text="Visualiser les paiements" /></div>
        <div class="col-sm-6 col-xs-12 text-center"><asp:Button class="btn btnHome" ID="btnNew" runat="server" OnClick="btnNew_Click" Text="Nouveau devis" /></div>
    </div>
</asp:Content>
