Attribute VB_Name = "mdlService"
Option Explicit

Public Sub setPictureBoxesToCam1Size()
    Dim a As Byte
    With frmMain
        For a = 0 To 2
            .picCapture(a).Width = .cam1.Width
            .picCapture(a).Height = .cam1.Height
        Next a
        For a = 0 To 1
            .picSense(a).Width = .cam1.Width
            .picSense(a).Height = .cam1.Height
        Next a
    End With
End Sub
