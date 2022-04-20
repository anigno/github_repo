<!--#INCLUDE virtual="anignoSolutions/_functions/functions01.asp" -->
<HTML dir="rtl">
	<HEAD>
		<title></title>
		<meta http-equiv="Content-Type" content="text/html; charset=windows-1255">
		<meta name="ms.locale" content="HE">
	</HEAD>
<%
	iKey=Request.QueryString("iKey")
	conn=openDB()
	set rs1=getRS()
	'get iKey's subject from tblProductsSubjects
	sql="select * from tblProductsSubjects where iKey=" & iKey 
	rs1.open sql,conn
%>
	<%
	set rs2=getRS()
	'display all product of current subject
	sql="select * from tblProducts where iSubject='" & rs1("iSubject") & "'"
	rs2.open sql,conn
	dim itemCnt
	itemCnt=1
%>
	<body background="../_images/<%=backgroundImage%>" bgcolor=<%=bgcolor%> text=<%=text%> link=<%=link%> alink=<%=alink%> vlink=<%=vlink%>>
<form id=formShowProducts method=post>
		<table background="../_images/<%=tableBackgroundImage%>" align=center border=1 width=400>
<%while not rs2.eof%>
			<tr>
				<td align=right valign=top><font size=2><%=rs2("iName")%></font>
				</td>
				<td align=right valign=top><font size=2><%=rs2("iText")%></font>
				</td>
<%

		tImage=rs2("iImage") & " "	'cast to string
		if len(tImage)<5 then
			tImage="defaultImage.jpg"
		end if
%>				
				<td align=center><img src="../_images/products/<%=tImage%>" width=80>
				</td>
				<td>
<%
	if rs2("iPrise")=0 then
%>
לא נקבע מחיר
<%else%>
<%=rs2("iPrise")%>ש"ח
<%end if%>
				</td>
			</tr>

<%if showBasket=true then%>
			<tr>
				<td colspan=4>
				<INPUT type="button" value="הוסף" ID="btnAdd<%=itemCnt%>" NAME="btnAdd<%=itemCnt%>">
				<script language=vbscript>
					sub btnAdd<%=itemCnt%>_onclick()
						formShowProducts.action="../basket/addProduct.asp?iKey=" & "<%=rs2("iKey")%>" & "&itemCnt=" & "<%=itemCnt%>"
						formShowProducts.submit
					end sub
				</script>
				כמות של 
				<SELECT ID="productCounter" name="productCounter">
	<%
	dim a
	for a=1 to 30
	%>
					<OPTION value=<%=a%>><%=a%></OPTION>
	<%next%>					
				</SELECT> לסל הקניות
				</td>
			</tr>
<%end if%>

			
<%
	rs2.movenext
	itemCnt=itemCnt+1
	wend
%>	

		</table>
</form>
	</body>
</HTML>
