<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestReview.aspx.cs" Inherits="VacationDenied.RequestReview" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" EnableViewState="true" AppendDataBoundItems="true"></asp:DropDownList>
    <asp:UpdatePanel ID="update1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID ="DropDownList1" />
        </Triggers>
        <ContentTemplate>
            <fieldset>
                <legend>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    <asp:Button ID="Button1" runat="server" Text="Accept" OnClick="Button1_Click"/>
                    <asp:Button ID="Button2" runat="server" Text="Deny" OnClick="Button2_Click"/>
                </legend>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
