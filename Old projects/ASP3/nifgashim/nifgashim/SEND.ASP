<%@ Language=VBScript %>
<HTML>
<HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">
</HEAD>
<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">
<%
	iFriend=Request.QueryString("friend")
	iUsername=Request.Cookies("nifgashim")("username")
	Response.Write iUsername & " send to " &  iFriend
%>

<form name=form1 method=post action=sendData.asp?friend=<%=iFriend%>>
<TABLE border=1 cellPadding=1 cellSpacing=1 width="75%">
  <TR>
    <TD><INPUT id=txtSend name=txtSend style="BACKGROUND-COLOR: oldlace; COLOR: orangered; TEXT-ALIGN: right"  size="50"></TD></TR>
  <TR>
    <TD>
    <INPUT type="button" value="שלח" id=btnSend name=btnSend style="BACKGROUND-COLOR: oldlace; COLOR: orangered; FONT-WEIGHT: bold">

    </TD></TR>
</TABLE>
<div id=tError dir=rtl></div>
</form>

</BODY>
</HTML>
<!-- ********************** script ***************** -->
<script language=vbscript>
	'set the focus to txtSend
	form1.txtSend.focus

	sub btnSend_onclick()
		form1.submit
	end sub
</script>