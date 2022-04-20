<%@ Language=VBScript %>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
	<%=Application("line01")%><BR>
	<%=Application("line02")%><BR>
	<%=Application("line03")%><BR>
	<%=Application("line04")%><BR>
	<%=Application("line05")%><BR>
	<%=Application("line06")%><BR>
	<%=Application("line07")%><BR>
	<%=Application("line08")%><BR>
	<%=Application("line09")%><BR>
	<%=Application("line10")%><BR>
<script language=vbscript>
setTimeout "runReload",2000
sub runReload()
	window.location.reload	
end sub

</script>
</BODY>
</HTML>
