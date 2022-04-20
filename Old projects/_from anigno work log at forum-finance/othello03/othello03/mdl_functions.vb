Module mdl_functions

    Public isDebugOn = False

    Public Sub writeTable(ByVal t As String, ByVal table As c_table)
        If isDebugOn = True Then
            Dim s = Now.Hour & ";" & Now.Minute() & ";" & Now.Second & ";" & Now.Millisecond & "-" & t & ".txt"
            Dim a, b
            FileOpen(1, s & ".txt", OpenMode.Output, OpenAccess.Write, OpenShare.Default)
            PrintLine(1, t)
            For a = 1 To 8
                For b = 1 To 8
                    Print(1, table.data(b, a) & " ")
                Next
                PrintLine(1, "")
            Next
            FileClose(1)
        End If
    End Sub
End Module
