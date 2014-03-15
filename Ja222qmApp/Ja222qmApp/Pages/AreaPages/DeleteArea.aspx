<%@ Page Title="Radera ansvarsområde" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteArea.aspx.cs" Inherits="Ja222qmApp.Pages.AreaPages.DeleteArea" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Ordets magnifika medlems applikation</h2>
            </hgroup>            
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    <%-- Ger användaren möjlighet att bekräfta att denne verkligen vill radera ansvarsområdet eller avbryta --%>

    <p>Är du helt säker på att du vill radera ansvarsområdet
        <asp:Literal runat="server" ID="AreaName" ViewStateMode="Enabled"></asp:Literal>?</p>
    <asp:LinkButton ID="DeleteAreaButton" runat="server" Text="Ja, radera ansvarsområdet" 
        OnCommand="DeleteAreaButton_Command" CommandArgument='<%$ RouteValue:id %>'></asp:LinkButton>
    <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />

</asp:Content>
