<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VacationDenied._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <div class="jumbotron">
        <h1>Vacation Request</h1>
        <p class="lead">Login to continue.</p>
        <p><a href="/Account/Login" class="btn btn-primary btn-lg">Log In &raquo;</a></p>
    </div>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="jumbotron">
        <h1>Vacation Request</h1>
        <p class="lead">Request Off Page.</p>
        <p><a href="/Account/Calendar" class="btn btn-primary btn-lg">Request off. &raquo;</a></p>
    </div>
        </LoggedInTemplate>
    </asp:LoginView>


</asp:Content>
