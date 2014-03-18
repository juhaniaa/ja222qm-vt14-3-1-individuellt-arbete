<%@ Page Title="Ansvars detaljer" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckArea.aspx.cs" Inherits="Ja222qmApp.Pages.AreaPages.CheckArea" %>

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
    
    <%-- Meddelande för lyckad operation --%>
    <asp:PlaceHolder runat="server" ID="MessagePlaceholder" Visible="false">
        <asp:Literal runat="server" ID="MessageLiteral"></asp:Literal>
    </asp:PlaceHolder>

    <%-- Skriver ut det specifika ansvarsområdet och ger möjlighet att redigera och ta bort det --%>

    <asp:ValidationSummary runat="server" />
    <asp:FormView ID="AreaFormView" runat="server" ItemType="Ja222qmApp.Model.Area" 
        SelectMethod="AreaFormView_GetItem"
         RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <%#: Item.AreaName %>
            </div>                                   

            <div>
                <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("EditArea", new { id = Item.AreaId }) %>' />
                <asp:HyperLink runat="server" Text="Ta bort" NavigateUrl='<%# GetRouteUrl("DeleteArea", new { id = Item.AreaId }) %>' />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Areas", null)%>' />
            </div>
        </ItemTemplate>

    </asp:FormView>
    <br />
    <hr />

    <%-- Lista alla medlemmar med detta ansvarsområde --%>

    <asp:ListView ID="AreaMemberListView" runat="server" ItemType="Ja222qmApp.Model.Member" 
        SelectMethod="AreaMemberListView_GetData" DataKeyNames="MemberId">
        <LayoutTemplate>
            <label for="medlemmar">Medlemmar som ingår i ansvarsområdet:</label>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt>
                   <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("MemberDetails", new { id = Item.MemberId })  %>' Text='<%# Item.Name %>' /> 
                </dt>
            </dl>
    
        </ItemTemplate>        
    </asp:ListView>


</asp:Content>
