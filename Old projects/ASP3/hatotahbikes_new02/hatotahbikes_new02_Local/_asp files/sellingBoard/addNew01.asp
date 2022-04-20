<!--#INCLUDE FILE="functions.asp" -->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
<%
conn=openDb()
set rs=getRs()
sql="insert into tblSell " &_
	"(iRegion,iType,iManuf,iSize,iModel,iYear,iHand," &_
	"iPrise,iDescription,iName,iPhone,iDate) values(" &_
	"'" & Request.Form("region") & "'," &_
	"'" & Request.Form("type") & "'," &_
	"'" & Request.Form("manuf") & "'," &_
	"" & Request.Form("size") & "," &_
	"'" & Request.Form("model") & "'," &_
	"" & Request.Form("year") & "," &_
	"" & Request.Form("hand") & "," &_
	"'" & Request.Form("prise") & "'," &_
	"'" & Request.Form("description") & "'," &_
	"'" & Request.Form("iname") & "'," &_
	"'" & Request.Form("phone") & "'," &_
	"'" & date() & "')"
	'Response.Write sql
	rs.open sql,conn
	set rs=nothing
%>
<body dir=rtl>
מודעה נוספה בהצלחה!<br>
<a href=index.asp>חזרה</a>
</body>


</HTML>
