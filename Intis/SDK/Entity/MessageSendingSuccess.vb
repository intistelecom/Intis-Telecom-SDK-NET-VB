Namespace Intis.SDK.Entity

    Public Class MessageSendingSuccess
        Inherits MessageSendingResult

        Public Property MessageId As String

        Public Property Cost As Single

        Public Property Currency As String

        Public Property MessagesCount As Integer

        Public Sub New()
            IsOk = True
        End Sub
    End Class
End Namespace
