<%@ Page Title="Nytt ansvarsområde" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewArea.aspx.cs" Inherits="Ja222qmApp.Pages.AreaPages.NewArea" %>

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

    <asp:FormView ID="AreaFormView" runat="server"
        ItemType="Ja222qmApp.Model.Area"
        DefaultMode="Insert" 
        RenderOuterTable="false" 
        InsertMethod="AreaFormView_InsertItem">
        <InsertItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.AreaName%>' />
            </div>            

            <div>
                <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Areas", null) %>' />
            </div>

        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
