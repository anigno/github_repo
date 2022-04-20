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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(248, 72)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(240, 260)
        Me.ListBox1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(736, 436)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnumWindows(AddressOf Report, 0)
    End Sub

    'callback function, for use in enumWindows
    Public Function Report(ByVal hwnd As Integer, ByVal lParam As Integer) As Boolean
        Dim title As String
        title = Space(80)

        If IsWindowVisible(hwnd) Then
            'GetWindowText(hwnd, title, 260)
            ListBox1.Items.Add(WindowText(hwnd))
        End If
        Report = True

    End Function

    Public Function WindowText(ByVal hWnd As Integer) As String
        ' Local Declarations
        Dim BufferText As String
        Dim TextLength As Short
        Dim RetValue As Integer
        On Error Resume Next

        ' Get the Length of the Window Caption
        TextLength = 260

        ' Create Buffer, Get the Caption of the Window
        BufferText = New String(CChar(" "), TextLength)
        RetValue = GetWindowText(hWnd, BufferText, TextLength)

        ' Finalize and Return the Caption of the Window
        WindowText = Trim(Microsoft.VisualBasic.Left(BufferText, InStr(BufferText, Chr(0)) - 1))
    End Function


End Class
