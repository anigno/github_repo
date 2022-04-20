Public Class c_table

    Public data(9, 9) As Byte    'data stored 1 to 8 , with borders of 1

    Public Sub New()
        clearData()
    End Sub

    Public Sub New(ByVal srcTable As c_table)
        Dim a, b As Integer
        For a = 0 To 9
            For b = 0 To 9
                Me.data(a, b) = srcTable.data(a, b)
            Next
        Next
    End Sub


    'set data matrix to 0
    Public Sub clearData()
        Dim a, b
        For a = 0 To 9
            For b = 0 To 9
                data(a, b) = 0
            Next
        Next
    End Sub

End Class
