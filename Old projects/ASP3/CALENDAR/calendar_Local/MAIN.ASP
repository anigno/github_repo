<%@ Language=VBScript %>
<HTML>
<HEAD>
<META name=VI60_defaultClientScript content=VBScript>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<%
	'get data about the day to show
	showDay=Request.QueryString("showDay")
	if showDay="" then showDay=0
	date1=date()-showDay
%>
<%
	'draw the calendar
	showDate=date()-showDay
%>
<table border=1>
<tr><td colspan=7 align=center><a href=main.asp?showDay=0><font color=red>
	<%=date()%></font></a></td></tr>
<tr><td>א</td><td>ב</td><td>ג</td><td>ד</td><td>ה</td><td>ו</td><td>ש</td></tr>
<%
	'go back to first day of the month
	do while day(date1)>1
		date1=date1-1
	loop
	'go back to previous sunday
	do while Weekday(date1,1)>1
		date1=date1-1
	loop
	'write 6 weeks
	for a=1 to 6
%>
<tr>
<%
		for b=1 to 7
		dayColor="green"
		if date1=date() then dayColor="red"
		if date1=showDate then dayColor="blue"
		if month(date1)<>month(showDate) then dayColor="yellow"
%>
<td><a href=main.asp?showDay=<%=date()-date1%>><font color=<%=dayColor%>>
	<%=day(date1)%></font></a></td>
<%
		date1=date1+1
		next
%>
</tr>
<%
	next
%>
<%
	
%>
</table>
<BR>
<form id=form1 name=form1 method=post action=update.asp>
הוספת הודעה לתאריך 
<INPUT type="text" value=<%=showDate%> id=txtDate name=txtDate
 size=10 readonly>
<INPUT type="text" id=txtMessage name=txtMessage size=30><br><SELECT id=txtTime name=txtTime><OPTION value=7 selected>7:00</OPTION><OPTION value=8>8:00</OPTION><OPTION value=9>9:00</OPTION><OPTION value=10>10:00</OPTION><OPTION value=11>11:00</OPTION><OPTION value=12>12:00</OPTION><OPTION value=13>13:00</OPTION><OPTION value=14>14:00</OPTION><OPTION value=15>15:00</OPTION><OPTION value=16>16:00</OPTION><OPTION value=17>17:00</OPTION><OPTION value=18>18:00</OPTION><OPTION value=19>19:00</OPTION><OPTION value=20>20:00</OPTION><OPTION value=21>21:00</OPTION><OPTION value=22>22:00</OPTION><OPTION value=23>23:00</OPTION></SELECT>
<INPUT type="submit" value="הוסף" id=submit1 name=submit1>
</form>
</BODY >
</HTML>

<script language=vbscript>
	showDay=<%=showDay%>
	window.parent.frameData.navigate "data.asp?showDay=" & showDay
</script>

	