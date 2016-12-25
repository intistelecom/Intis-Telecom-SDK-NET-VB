Namespace Intis.SDK.Entity

    Public Class BirthdayGreetingSettings

        Public Property Enabled As Integer

        Public Property DaysBefore As Integer

        Public Property Originator As String

        Public Property TimeToSend As String

        Public Property UseLocalTime As Integer

        Public Property Template As String

        Public Sub New(ByVal enabled As Integer, ByVal daysBefore As Integer, ByVal originator As String, ByVal timeToSend As String, ByVal useLocalTime As Integer, ByVal template As String)
            enabled = enabled
            daysBefore = daysBefore
            originator = originator
            timeToSend = timeToSend
            useLocalTime = useLocalTime
            template = template
        End Sub
    End Class
End Namespace
