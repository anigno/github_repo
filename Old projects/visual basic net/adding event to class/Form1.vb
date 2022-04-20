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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(408, 356)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    'declare class1 withEvents
    Public WithEvents myClass1 As Class1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'create new instance of class1
        myClass1 = New Class1
        myClass1.tmr.Interval = 1000
        myClass1.tmr.Enabled = True
    End Sub

    'class1 timer event (picked from events list)
    Private Sub myClass1_class1TimerEvent(ByVal sender As Object) Handles myClass1.class1TimerEvent
        myClass1.tmr.Enabled = False
        MsgBox("class1 tick")
    End Sub
End Class
