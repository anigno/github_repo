<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePicker.ascx.cs" Inherits="WebMainApplication.Library.DatePicker" %>
<asp:Panel ID="Panel1" runat="server" Width="169px">
    <asp:TextBox ID="TextBoxDate" runat="server" ReadOnly="True" Width="118px"></asp:TextBox>
    <asp:ImageButton ID="ImageButtonShowCalendar" runat="server" 
        BorderColor="#000001" Height="20px" 
        ImageUrl="~/Library/Images/Calendar - a.png" 
        onclick="ImageButtonShowCalendar_Click" />
    <asp:ImageButton ID="ImageButtonCancel" runat="server" BorderColor="#000001" 
        Height="20px" ImageUrl="~/Library/Images/button_cancel.png" 
        onclick="ImageButtonCancel_Click" Visible="False" Width="20px" />
    <asp:Calendar ID="CalendarDate" runat="server" BorderWidth="1px" 
        DayNameFormat="Shortest" FirstDayOfWeek="Sunday" Height="16px" 
        onselectionchanged="CalendarDate_SelectionChanged" Visible="False" Width="16px">
        <TodayDayStyle BorderStyle="Solid" BorderWidth="1px" />
    </asp:Calendar>
</asp:Panel>
<br />

