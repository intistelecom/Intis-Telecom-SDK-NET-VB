Namespace Intis.SDK.Entity

    Module Gender

        Const Male As Integer = 1

        Const Female As Integer = 2

        Const Undefined As Integer = 3

        Function Parse(ByVal str As String) As Integer
            Select Case str
                Case "m"
                    Return Male
                Case "f"
                    Return Female
            End Select

            Return Undefined
        End Function
    End Module
End Namespace
