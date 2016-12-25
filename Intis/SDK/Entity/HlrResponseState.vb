Namespace Intis.SDK.Entity

    Module HlrResponseState

        Const Success As Integer = 1

        Const Failed As Integer = 2

        Function Parse(ByVal str As String) As Integer
            Return If(str.ToLower() = "delivrd", Success, Failed)
        End Function
    End Module
End Namespace
