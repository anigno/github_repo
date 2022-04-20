<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<!-- ******************** script *********************--><HTML><HEAD>
<meta NAME="GENERATOR" Content="Microsoft FrontPage 5.0">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
<meta name="ms.locale" content="HE">


<body bgcolor="#fefff6" text="#ff6600" link="#ff3300" vlink="#ff3300" alink="#ff3300">


<script language="vbscript">
txtAllow="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ" &_
"1234567890-_אבגדהוזחטיכלמנסעפצקרשתףךץןם"
'check if txt include chars from txtAllow only
'input: txt as string,txtAllow as string
'output: 0 not OK, 1 OK
function checkText(txt,txtAllow)
	dim txtOK
	txtOK=1
	for a=1 to len(txt)
		if instr(1,txtAllow,mid(txt,a,1))=0 then txtOK=0
	next
	checkText=txtOK
end function
</script>

<%
	'open DB
	mdbFile="db\nifgashim.mdb"
	set conn=Server.CreateObject("ADODB.connection")
	connString="provider=Microsoft.Jet.OLEDB.4.0;" & _
		"data source="	& _
		server.MapPath(mdbFile)& ";"
	conn.Open connString
	set rs=Server.Createobject("ADODB.RecordSet")
%>
<INPUT id=btnBack language=vbscript name=btnBack onclick=window.history.back style="BACKGROUND-COLOR: oldlace; COLOR: orangered" type=button value=חזרה></BODY></HTML>
