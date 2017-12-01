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
                <!--<asp:Label runat="server">Référence du projet :</asp:Label><br/>
                <asp:TextBox runat="server" ID="refProjet" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>-->
                <h2>Client :</h2>
                <asp:DropDownList ID="client" runat="server" class="form-control">
                </asp:DropDownList><br />
                <asp:Button runat="server" Text="Valider" CssClass="btn btn-primary btnVal" OnClick="continuer"/><br />
                <span id="valSum"><asp:ValidationSummary DisplayMode="BulletList" runat="server" HeaderText="Différentes erreurs trouvées : "/></span>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12">
                <h2>Adresse :</h2>
                <asp:Label runat="server">Numéro :</asp:Label><br/>
                <asp:TextBox runat="server" ID="numClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Adresse :</asp:Label><br/>
                <asp:TextBox runat="server" ID="adresseClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Code postal :</asp:Label><br/>
                <asp:TextBox runat="server" ID="postalClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Ville :</asp:Label><br/>
                <asp:TextBox runat="server" ID="villeClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox><br/>
                <asp:Label runat="server">Pays :</asp:Label><br/>
                <asp:TextBox runat="server" ID="paysClient" TextMode="SingleLine" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:RequiredFieldValidator id="reqNomProjet" ControlToValidate="nomProjet" Display="None" ErrorMessage="Veuillez renseigner un nom de projet !" runat="server"/> 
            <asp:RequiredFieldValidator id="reqNumClient" ControlToValidate="numClient" Display="None" ErrorMessage="Veuillez renseigner un numéro d'adresse !" runat="server"/> 
            <asp:RequiredFieldValidator id="reqAdresseClient" ControlToValidate="adresseClient" Display="None" ErrorMessage="Veuillez renseigner une adresse !" runat="server"/> 
            <asp:RequiredFieldValidator id="reqPostalClient" ControlToValidate="postalClient" Display="None" ErrorMessage="Veuillez renseigner un code postal !" runat="server"/> 
            <asp:RequiredFieldValidator id="reqVilleClient" ControlToValidate="villeClient" Display="None" ErrorMessage="Veuillez renseigner une ville !" runat="server"/> 
            <asp:RequiredFieldValidator id="reqPaysClient" ControlToValidate="paysClient" Display="None" ErrorMessage="Veuillez renseigner un pays !" runat="server"/> 
        </div>
    </div>
</asp:Content>