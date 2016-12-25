Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class Originator

        Public Property Name As String

        Private Property StateText As String

        Public ReadOnly Property State As Integer?
            Get
                Return OriginatorState.Parse(StateText)
            End Get
        End Property

        Public Sub New(ByVal originator As String, ByVal state As String)
            Name = originator
            StateText = state
        End Sub
    End Class
End Namespace
