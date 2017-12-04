<%@ Page Title="" Language="C#" MasterPageFile="~/Madera.Master" AutoEventWireup="true" CodeBehind="CreationPlan.aspx.cs" Inherits="MaderaAsp.CreationPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenu" runat="server">
    <h1>Configuration de la maison :</h1>
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:Label runat="server">Gamme de la maison :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="gammeMaison" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="getModelesModules"></asp:DropDownList><br/>
                <asp:Label runat="server">Choix du modèle :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="modeleMaison" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="setEtage"></asp:DropDownList><br/>
                <asp:Label runat="server">Choix de l'étage :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="choixEtage" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="setPlan"></asp:DropDownList><br/>
                <asp:Label runat="server">Ajout des options :</asp:Label><br/>
                <asp:DropDownList runat="server" ID="choixOption" CssClass="form-control"></asp:DropDownList>
                <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" CssClass="btn btn-primary" OnClick="btnAjouter_Click"/><br/>
                <br/>
                <asp:ListBox runat="server" CssClass="form-control" ID="listeOptions"></asp:ListBox>
                <asp:Button ID="btnSupprimer" runat="server" Text="Supprimer" CssClass="btn btn-primary" OnClick="btnSupprimer_Click"/><br /><br />
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:Image id="plan" runat="server" AlternateText="plan"/>
                <asp:Button ID="btnValider" runat="server" Text="Valider" CssClass="btn btn-primary form-control" OnClick="btnValider_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
