<%@ Page Title="Redigera ansvarsområde" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArea.aspx.cs" Inherits="Ja222qmApp.Pages.AreaPages.EditArea" %>

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

    <%-- Textfält för att redigera befintligt ansvarsområde --%>

    <asp:FormView ID="AreaFormView" runat="server"
        ItemType="Ja222qmApp.Model.Area" 
        DataKeyNames="AreaId"
        DefaultMode="Edit" 
        RenderOuterTable="false" 
        SelectMethod="AreaFormView_GetItem" 
        UpdateMethod="AreaFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Namn måste anges" Text="*" ControlToValidate="Name"></asp:RequiredFieldValidator>
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.AreaName %>' MaxLength="15" />
            </div>                     

            <div>
                <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("AreaDetails", new { id = Item.AreaId })%>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
