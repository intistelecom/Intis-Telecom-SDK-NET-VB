Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class Stats

        Private Property StateText As String

        Public ReadOnly Property State As Integer?
            Get
                Return MessageState.Parse(StateText)
            End Get
        End Property

        <DataMember(Name:="cost")>
        Public Property Cost As Single

        <DataMember(Name:="currency")>
        Public Property Currency As String

        <DataMember(Name:="parts")>
        Public Property Count As Integer
    End Class
End Namespace
