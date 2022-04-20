<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<form id=form1 name=form1 methode=get action="chat02.asp">
<TABLE border=1 cellPadding=1 cellSpacing=1 >
  <TR>
    <TD>
    name<BR>
    <INPUT type="text" id=txtName name=txtName value=<%=Request.QueryString("txtName")%>><BR>
    
    </td><td>
    send line<br>
    <INPUT type="text" id=txtLine name=txtLine size=40>
	</td>
	<tr>
	<td>
	<INPUT type="submit" value="Send" id=submit1 name=submit1>
	</TD>
   </TR>
  </TABLE>
</form>
<%
%>

</BODY>
</HTML>
<script language=vbscript>
	form1.txtLine.focus
</script>