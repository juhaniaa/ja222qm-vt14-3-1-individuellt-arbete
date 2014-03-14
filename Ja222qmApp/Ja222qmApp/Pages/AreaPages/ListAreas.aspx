<%@ Page Title="Ansvarsområden" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAreas.aspx.cs" Inherits="Ja222qmApp.Pages.AreaPages.ListAreas" %>

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
    
    <asp:ListView ID="AreaListView" runat="server" 
        ItemType="Ja222qmApp.Model.Area" SelectMethod="AreaListView_GetData"
        DataKeyNames="AreaId">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </LayoutTemplate>
        <ItemTemplate>
            <dl>
                <dt>
                    <asp:HyperLink runat="server" NavigateUrl='<%# GetRouteUrl("AreaDetails", new { id = Item.AreaId })  %>' Text='<%# Item.AreaName %>' />
                </dt>                
            </dl>
    
        </ItemTemplate>        
        <EmptyDataTemplate>            
            <p>
                Medlemmar saknas.
            </p>
        </EmptyDataTemplate>

    </asp:ListView>

</asp:Content>
