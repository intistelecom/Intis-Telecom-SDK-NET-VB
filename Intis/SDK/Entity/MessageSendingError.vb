Imports Intis.SDK.Exceptions

Namespace Intis.SDK.Entity

    Public Class MessageSendingError
        Inherits MessageSendingResult

        Public Property Code As Integer

        Public ReadOnly Property Message As String
            Get
                Return SdkException.GetMessage(Code)
            End Get
        End Property

        Public Sub New()
            IsOk = False
        End Sub
    End Class
End Namespace
