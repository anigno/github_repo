<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML >
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
	<body background=<%=backgroundImage%> bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>

<%
	productKey=Request.QueryString("iKey")
	itemCnt=Request.QueryString("itemCnt")
	'get counter from "productCounter" collection
	productCount=Request.Form("productCounter")(itemCnt)
	Response.Write("adding product " & productKey & " count=" & productCount)
%>

<%
	conn=openDB()
	set rs=getRS()
	set rs2=getRS()
	'get productPrise and productName from tblProducts by iKey
	sql="select * from tblProducts where iKey=" & productKey
	rs2.open sql,conn
	productName=rs2("iName")
	productPrise=rs2("iPrise")
%>

<br>
<%	
	'add product to tblBasket with session("userId")
	sql="insert into tblBasket (iUserId,iProductKey,iProductCount,iProductName,iProductPrise) values ("
	sql=sql & session("userId")
	sql=sql & "," & productKey
	sql=sql & "," & productCount
	sql=sql & ",'" & productName & "'"
	sql=sql & "," & productPrise & ")"
	rs.open sql,conn
%>
	</body>
</HTML>
<script language=vbscript>
	window.parent.frames(1).location="../basket/basket.asp"
	window.history.back
</script>
