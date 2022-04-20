<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<form action=login02.asp id=form1 name=form1 method=post>

<table>
	<TR>
		<TD>user name</TD>
		<TD><INPUT type="text" id=txtUserName name=txtUserName></TD>
	</TR>
		<TD>password</TD>
		<TD><INPUT type="password" id=txtPassword name=txtPassword></TD>
	<TR>
		<TD><INPUT type="button" value="log in" id=button1 name=button1></TD>
	</TR>
</table>
<A href=newUser01.asp>new user</A><BR>
</form>

<script language=vbscript>
	sub button1_onclick()
		if form1.txtUserName.value<>"" then
			form1.submit
		else
			msgbox "no user name entered!",vbCritical
		end if
	end sub	
</script>

<%
	Session.Abandon
%>
</BODY>
</HTML>
