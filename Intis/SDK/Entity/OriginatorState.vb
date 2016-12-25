Namespace Intis.SDK.Entity

    Module OriginatorState

        Const Completed As Integer = 1

        Const Moderation As Integer = 2

        Const Rejected As Integer = 3

        Function Parse(ByVal str As String) As Integer?
            Select Case str
                Case "completed"
                    Return Completed
                Case "order"
                    Return Moderation
                Case "rejected"
                    Return Rejected
            End Select

            Return Nothing
        End Function
    End Module
End Namespace
