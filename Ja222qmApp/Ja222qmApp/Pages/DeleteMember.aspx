<%@ Page Title="Radera kund" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteMember.aspx.cs" Inherits="Ja222qmApp.Pages.DeleteMember" %>

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
    
    <p>Är du helt säker på att du vill radera medlemmen
        <asp:Literal runat="server" ID="MemberName" ViewStateMode="Enabled"></asp:Literal>?</p>
    <asp:LinkButton ID="DeleteMemberButton" runat="server" Text="Ja, radera medlemmen" 
        OnCommand="DeleteMemberButton_Command" CommandArgument='<%$ RouteValue:id %>'></asp:LinkButton>
    <asp:HyperLink runat="server" ID="CancelHyperLink" Text="Avbryt" />

</asp:Content>
