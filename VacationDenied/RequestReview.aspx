<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestReview.aspx.cs" Inherits="VacationDenied.RequestReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <asp:Label ID="Label1" runat="server" Text="" db="<%: Listbox1.SelectedItem.Text %>"></asp:Label>
</asp:Content>
