<%@ Page Title="" Language="C#" MasterPageFile="~/Madera.Master" AutoEventWireup="true" CodeBehind="CreationDevis.aspx.cs" Inherits="MaderaAsp.CreationDevis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenu" runat="server">
    <h1>Création d'un devis :</h1>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-sm-6 col-xs-12">
                <h2>Projet :</h2>
                <asp:Label runat="server">Nom du projet :</asp:Label><br/>
                <asp:TextBox runat="server" ID="nomProjet" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Référence du projet :</asp:Label><br/>
                <asp:TextBox runat="server" ID="refProjet" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <br/>
                <asp:Button runat="server" Text="Valider" CssClass="btn btn-primary"/>
            </div>   
            <div class="col-md-6 col-sm-6 col-xs-12">
                <h2>Client :</h2>
                <asp:Label runat="server">Nom :</asp:Label><br/>
                <asp:TextBox runat="server" ID="nomClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Prenom :</asp:Label><br/>
                <asp:TextBox runat="server" ID="prenomClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Adresse :</asp:Label><br/>
                <asp:TextBox runat="server" ID="adresseClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Code postal :</asp:Label><br/>
                <asp:TextBox runat="server" ID="postalClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Ville :</asp:Label><br/>
                <asp:TextBox runat="server" ID="villeClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Mail :</asp:Label><br/>
                <asp:TextBox runat="server" ID="mailClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Telephone :</asp:Label><br/>
                <asp:TextBox runat="server" ID="phoneClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
            </div>
        </div>
    </div>
</asp:Content>