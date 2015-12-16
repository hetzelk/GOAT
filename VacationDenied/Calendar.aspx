<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="VacationDenied.Calendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<link href="Scripts/fullcalendar.css" rel="stylesheet" type="text/css" />
<link href="Scripts/jquery-ui.min.css" rel="stylesheet" type="text/css" />
<link href="Content/bootstrap.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Scripts/jquery-1.10.2.js"></script>
<script type="text/javascript" src="Scripts/moment.min.js"></script>
<script type="text/javascript" src="Scripts/fullcalendar.js"></script>
        <script>
            $(document).ready(function () {

                $('#calendar').fullCalendar({
                    theme: true,
                    themeButtonIcons: false,
                    events: [
                        {
                            allDay: true,
                            title: 'Goat',
                            start: '2015-12-21',
                            end: '2015-12-26'
                        },
                        {
                            allDay: true,
                            title: 'John Cena Off',
                            start: '2015-12-12',
                            end: '2015-12-15'
                        },
                        {
                            allDay: true,
                            title: 'jBreezy Off',
                            start: '2015-12-12',
                            end: '2015-12-15'
                        }
                ]
                })

            });
        </script>
    <div id='calendar' class="col-md-12"></div>
</asp:Content>
