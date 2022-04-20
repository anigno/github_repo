Public Class Class1

    'declare timer control as class1 member, must be withEvents 
    Public WithEvents tmr As System.Timers.Timer

    Public Sub New()
        'create new instance of system.timer.timer
        tmr = New System.Timers.Timer
    End Sub

    'create an event
    Public Event class1TimerEvent(ByVal sender As Object)

    'use the timer tmr event to raise class1 event (picked form event list)
    Private Sub tmr_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles tmr.Elapsed
        RaiseEvent class1TimerEvent(Me)
    End Sub
End Class
