<%@ Page Title="" Language="C#" MasterPageFile="~/Madera.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="MaderaAsp.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenu" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4 col-sm-4 col-xs-12">
                <asp:Button runat="server" CssClass="btn btnHome" Text="Visualiser Devis"/>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
                <asp:Button runat="server" CssClass="btn btnHome" Text="Dossier technique"/>
            </div>
            <div class="col-md-4 col-sm-4 col-xs-12">
                <asp:Button runat="server" CssClass="btn btnHome" Text="Page d'accueil"/>
            </div>
        </div>
    </div>
</asp:Content>
