<%@ Page Title="Medlemmar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Ja222qmApp.Pages.List" %>

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
    
    <%-- Listar upp alla medlemmar i databasen med länk till varje medlems detalj sida --%>

    <asp:ListView ID="MemberListView" runat="server" 
        ItemType="Ja222qmApp.Model.Member" 
        SelectMethod="ListView1_GetData" 
        DataKeyNames="MemberId">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("MemberDetails", new { id = Item.MemberId })  %>' Text='<%# Item.Name %>' />
                </dt>
                <dd>
                   <%#: Item.Address %>
                </dd>
                <dd>
                   <%#: Item.Postnr %> <%#: Item.City %>
                </dd>                
            </dl>
    
        </ItemTemplate>        
        <EmptyDataTemplate>            
            <p>
                Medlemmar saknas.
            </p>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>