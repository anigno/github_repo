Imports System.Data.OleDb
Public Class WebForm3
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents names As System.Web.UI.WebControls.Repeater

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbconn, sql, dbcomm, dbread
        'create connection string for *.mdb and open it
        dbconn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;	data source=" & Server.MapPath("myData.mdb"))
        dbconn.Open()
        'create command from sql and run it
        sql = "SELECT * FROM tblData"
        dbcomm = New OleDbCommand(sql, dbconn)
        'create reader
        dbread = dbcomm.ExecuteReader()
        'use repeater object, bind the reader to it
        names.DataSource = dbread
        names.DataBind()
        'close the connection and command
        dbread.Close()
        dbconn.Close()
    End Sub
End Class
