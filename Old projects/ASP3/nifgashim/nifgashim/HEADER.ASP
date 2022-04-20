<%@ Language=VBScript %>
<html>
<head>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</head>
<body bgcolor="#fefff6" text="#ff6600" link="#FF3300" vlink="#FF3300" alink="#FF3300" background="images/nifgashim.gif">

<%
	'get username from coockies
	username=Request.Cookies("nifgashim")("username")
%>

<table border="0" cellpadding="0" cellspacing="0" style="BORDER-COLLAPSE: collapse" bordercolor="#111111" width="100%" height="82">
  <tr>
    <td width="100%" height="46" colspan="5">&nbsp;</td>
  </tr>
  <tr>
    <td width="20%" height="35">
    &nbsp;<A href="exit.asp" target=_parent>יציאה</a>&nbsp;
    
      </td>
    <td width="20%" height="35">
    &nbsp;</td>
    <td width="20%" height="35">&nbsp;<A 
      href="calendar/index.asp?username=<%=username%>" target=frameData>יומן</A>
    </td>
    <td width="20%" height="35">
    <A href="search.asp" target=frameData>חפש חברים</a></td>
    <td width="20%" height="35">
    <A href="data.asp" target=frameData>ראשי</a></td>
  </tr>
</table>

</body>
</html>