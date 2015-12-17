<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestTimeOff.aspx.cs" Inherits="VacationDenied.RequestTimeOff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label><%: currentUser.VacationDays %></label>
    </div>
    <div class="col-md-6 col-md-offset-3">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="black" BorderWidth="1px" Font-Names="Verdana" Font-Size="13pt" ForeColor="Black" Height="400px" NextPrevFormat="ShortMonth" OnSelectionChanged="Calendar1_SelectionChanged" Width="600px" BorderStyle="Dotted" Caption="Requested Days Off" CaptionAlign="Top" FirstDayOfWeek="Sunday" OnDayRender="Calendar1_DayRender" ShowGridLines="True">
            <DayHeaderStyle Font-Bold="True" Font-Size="12pt" />
            <NextPrevStyle Font-Bold="True" Font-Size="12pt" ForeColor="#2f4f4f" VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#2f4f4f" />
            <SelectedDayStyle BackColor="#2f4f4f" ForeColor="White" />
            <TitleStyle BackColor="White" BorderColor="black" BorderWidth="1px" Font-Bold="True" Font-Size="12pt" ForeColor="#2f4f4f" />
            <TodayDayStyle BackColor="#049175" />
        </asp:Calendar>
    </div>
    <div style="clear: both;"></div>
        <div class ="col-md-6 col-md-offset-3 padding">
            <asp:Button ID="Button2" class="btn btn-large" runat="server" Text="Clear" OnClick="Button2_Click" />
            <asp:Button ID="Button1" class="btn btn-large" runat="server" Text="Submit" OnClick="Button1_Click" />
        </div>
    <div style="clear: both;"></div>
</asp:Content>
