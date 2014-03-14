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

</asp:Content>
