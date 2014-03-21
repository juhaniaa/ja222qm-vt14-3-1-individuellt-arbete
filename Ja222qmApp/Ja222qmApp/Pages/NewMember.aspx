<%@ Page Title="Ny medlem" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewMember.aspx.cs" Inherits="Ja222qmApp.Pages.NewMember" %>

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

    <%-- Formulär för skapande av ny medlem --%>

    <asp:FormView ID="MemberFormView" runat="server"
        ItemType="Ja222qmApp.Model.Member"
        DefaultMode="Insert" 
        RenderOuterTable="false"
        InsertMethod="MemberFormView_InsertItem">
        <InsertItemTemplate>
            <div>
                <label for="Name">Namn</label>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Namn måste anges" ControlToValidate="Name" Text="*"></asp:RequiredFieldValidator>
                <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="40" />
            </div>

            <div>
                <label for="Address">Adress</label>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Adress måste anges" ControlToValidate="Address" Text="*"></asp:RequiredFieldValidator>
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
                <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" />
                <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("Members", null) %>' />
            </div>

        </InsertItemTemplate>
    </asp:FormView>

</asp:Content>
