Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(0, 8)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(328, 152)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = ""
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(336, 88)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(208, 32)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Sort and Import Data"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(336, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(208, 32)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Import Data"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(336, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Create Spreadsheet"
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(336, 128)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(208, 32)
        Me.Button4.TabIndex = 0
        Me.Button4.Text = "Calculate Expression"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(552, 173)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.Button3, Me.Button2, Me.TextBox1, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Excel Demo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim EXL As New Excel.Application()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If EXL Is Nothing Then
            MsgBox("Couldn't start Excel")
            Exit Sub
        End If

        Dim WSheet As New Excel.Worksheet()
        WSheet = EXL.Workbooks.Add.Worksheets.Add ' CType(EXL.Workbooks.Add.Worksheets.Add, Excel.Worksheet)
        With WSheet
            .Cells(2, 1).Value = "1st Quarter"
            .Cells(2, 2).Value = "2nd Quarter"
            .Cells(2, 3).Value = "3rd Quarter"
            .Cells(2, 4).Value = "4th Quarter"
            .Cells(2, 5).Value = "Year Total "
            .Cells(3, 1).Value = 123.45
            .Cells(3, 2).Value = 435.56
            .Cells(3, 3).Value = 376.25
            .Cells(3, 4).Value = 425.75
            .Range("A2:E2").Select()
            With EXL.Selection.Font
                .Name = "Verdana"
                .FontStyle = "Bold"
                .Size = 12
            End With
        End With
        WSheet.Range("A2:E2").Select()
        EXL.Selection.Columns.AutoFit()
        WSheet.Range("A2:E2").Select()
        With EXL.Selection
            .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        End With
        ' Format numbers
        WSheet.Range("A3:E3").Select()
        With EXL.Selection.Font
            .Name = "Verdana"
            .FontStyle = "Regular"
            .Size = 11
        End With
        WSheet.Cells(3, 5).Value = "=Sum(A3:D3)"

        Dim R As Excel.Range
        R = WSheet.UsedRange
        Dim row, col As Integer
        For row = 1 To R.Rows.Count
            TextBox1.AppendText("ROW " & row & vbCrLf)
            For col = 1 To R.Columns.Count
                TextBox1.AppendText("[" & row & ", " & col & _
                     " : " & vbTab & R.Cells(row, col).value & "]" & vbCrLf)
            Next
            TextBox1.AppendText(vbCrLf)
        Next
        Try
            WSheet.SaveAs("C:\TEST.XLS")
        Catch
        End Try
        Me.Text = "File Created"
        EXL.Workbooks.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        Dim WSheet As New Excel.Worksheet()
        WSheet = EXL.Workbooks.Open("C:\TEST.XLS").Worksheets.Item(1)
        EXL.Range("A2:E3").Select()
        Dim CData As Excel.Range
        CData = EXL.Selection
        Dim iCol, iRow As Integer
        For iCol = 1 To 5
            For iRow = 1 To 2
                TextBox1.Text = TextBox1.Text & _
                             CData(iRow, iCol).value & vbTab
            Next
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        EXL.Workbooks.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim WSheet As New Excel.Worksheet()
        WSheet = EXL.Workbooks.Open("C:\TEST.XLS").Worksheets.Item(1)

        EXL.Range("A2:E3").Select()
        Dim CData As Excel.Range
        CData = EXL.Selection
        CData.Sort(Key1:=CData.Range("A2"), _
                     order1:=Excel.XlSortOrder.xlAscending)
        TextBox1.Clear()
        Dim iCol, iRow As Integer
        For iCol = 1 To 5
            For iRow = 1 To 2
                TextBox1.Text = TextBox1.Text & _
                                CData(iRow, iCol).value & vbTab
            Next
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        EXL.Workbooks.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim mathStr As String
        mathStr = InputBox("Enter math expression to evaluate", , _
                           "cos(3.673/4)/exp(-3.333)")
        If mathStr <> "" Then
            Try
                MsgBox(EXL.Evaluate(mathStr).ToString)
            Catch exc As Exception
                MsgBox(exc.Message)
            End Try
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        EXL.Workbooks.Close()
        EXL.Quit()
    End Sub

End Class
