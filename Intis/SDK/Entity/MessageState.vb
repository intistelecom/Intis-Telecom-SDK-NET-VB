Namespace Intis.SDK.Entity

    Module MessageState

        Const Scheduled As Integer = 0

        Const Enroute As Integer = 1

        Const Delivered As Integer = 2

        Const Expired As Integer = 3

        Const Deleted As Integer = 4

        Const Undeliverable As Integer = 5

        Const Accepted As Integer = 6

        Const Unknown As Integer = 7

        Const Rejected As Integer = 8

        Const Skipped As Integer = 9

        Function Parse(ByVal state As String) As Integer?
            Select Case state
                Case "deliver"
                    Return Delivered
                Case "expired"
                    Return Expired
                Case "not_deliver"
                    Return Undeliverable
                Case "partly_deliver"
                    Return Accepted
                Case Else
                    Return Nothing
            End Select
        End Function
    End Module
End Namespace
