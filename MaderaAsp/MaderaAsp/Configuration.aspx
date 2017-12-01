<%@ Page Title="" Language="C#" MasterPageFile="~/Madera.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="MaderaAsp.Configuration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenu" runat="server">
    <h1>Configuration de la maison :</h1>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:Label runat="server">Gamme de la maison :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="gammeMaison" CssClass="form-control"/><br/>
                <asp:Label runat="server">Choix du modèle :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="modeleMaison" CssClass="form-control"/><br/>
                <asp:Label runat="server">Ajout des options :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="choixOption" CssClass="form-control"/><br/>
                <asp:Button runat="server" Text="Ajouter" CssClass="btn btn-primary"/><br/>
                <br/>
                <asp:ListBox runat="server" CssClass="form-control" ID="listeOptions"/><br/>
                <br/>
                <asp:Button runat="server" Text="Valider" CssClass="btn btn-primary"/>
                <br/>
            </div>
        </div>
    </div>
</asp:Content>