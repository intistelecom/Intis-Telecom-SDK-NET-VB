Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class DeliveryStatus

        Public Property MessageId As String

        <DataMember(Name:="status")>
        Public Property MessageStatus As String

        <DataMember(Name:="time")>
        Public Property CreatedAt As String
    End Class
End Namespace
