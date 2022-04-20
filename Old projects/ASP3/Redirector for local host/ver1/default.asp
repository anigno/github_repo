<HTML>
	<HEAD>
		<TITLE>ipRedirector</TITLE>
	</HEAD>
	<body>
	<%
		key=Request.QueryString("key")
		if key="1" then
			currentIp=Request.ServerVariables("remote_addr")
			Application("ipAddress")=currentIp
			Application("counter")=Application("counter")+1
			Response.Write currentIp 
			Response.Write " counter=" & Application("counter") & " key=" & key
		else
			Response.Write " redirection!"
			Response.Redirect "http://" & Application("ipAddress")
		end if
	%>
	<script language=vbscript>
	setTimeout "reload",2000
	sub reload()
		window.location.reload
	end sub
	</script>
	</body>
</HTML>
