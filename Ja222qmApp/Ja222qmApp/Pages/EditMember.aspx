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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Namn måste anges" Text="*" ControlToValidate="Name"></asp:RequiredFieldValidator>
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="40" />
            </div>

            <div>
                <label for="Address">Adress</label>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Adress måste anges" Text="*" ControlToValidate="Address"></asp:RequiredFieldValidator>
                <asp:TextBox ID="Address" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
            </div>

            <div>
                <label for="PostalCode">Postnummer</label>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Postnummer måste anges" ControlToValidate="PostalCode" Text="*"></asp:RequiredFieldValidator>
                <asp:TextBox ID="PostalCode" runat="server" Text='<%# BindItem.Postnr %>' MaxLength="5" />
            </div>

            <div>
                <label for="City">Ort</label>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ort måste anges" ControlToValidate="City" Text="*"></asp:RequiredFieldValidator>
                <asp:TextBox ID="City" runat="server" Text='<%# BindItem.City %>' MaxLength="25" />
            </div>

            <div>
                <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("MemberDetails", new { id = Item.MemberId })%>' />
            </div>
        </EditItemTemplate>
    </asp:FormView>

</asp:Content>
