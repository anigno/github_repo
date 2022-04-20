<%@ Language=VBScript %>
<HTML>
<HEAD>
<META name=VI60_defaultClientScript content=VBScript>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<form  action=newUser02.asp  name=form1 id=form1 method=post>
<table>
<TR>
	<TD>user name</TD>
	<TD><INPUT id=userName name=userName 
     ></TD>
</TR><TR>
	<TD>password</TD>
	<TD><INPUT type="password" id=password1 name=password1 ></TD>
</TR><TR>
	<TD>confirm password</TD>
	<TD><INPUT type="password" id=password2 name=password2 ></TD>
</TR><TR>
	<TD><INPUT type="button" value="sign in" id=button1 name=button1></TD>
	<TD><INPUT type="button" value="Cancel" id=button2 name=button2></td>
</TR>
</table>
</form>
<script language=vbscript>
	sub button1_onclick()
		if form1.password1.value="" or form1.password1.value<>form1.password2.value then
			MsgBox "no user name or password not identical or no password!",vbCritical
		else
			form1.submit
		end if
	end sub
	sub button2_onclick()
		window.navigate "login01.asp"
	end sub
</script>
</BODY>
</HTML>
