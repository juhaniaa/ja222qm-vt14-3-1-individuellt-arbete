<%@ Page Title="Redigera medlem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditMember.aspx.cs" Inherits="Ja222qmApp.Pages.EditMember" %>

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

    <%-- redigeringsmöjligheter för specifik medlem --%>

    <asp:FormView ID="MemberFormView" runat="server"
        ItemType="Ja222qmApp.Model.Member" 
        DataKeyNames="MemberId"
        DefaultMode="Edit" 
        RenderOuterTable="false" 
        SelectMethod="MemberFormView_GetItem" 
        UpdateMethod="MemberFormView_UpdateItem">
        <EditItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' />
            </div>

            <div>
                <label for="Address">Adress</label>
            </div>
            <div>
                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' />
            </div>

            <div>
                <label for="PostalCode">Postnummer</label>
            </div>
            <div>
                <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.Postnr %>' />
            </div>

            <div>
                <label for="City">Ort</label>
            </div>
            <div>
                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' />
            </div>

            <div>
                <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("MemberDetails", new { id = Item.MemberId })%>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
