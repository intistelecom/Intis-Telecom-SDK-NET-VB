Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class IncomingMessage

        Public Property MessageId As String

        <DataMember(Name:="date")>
        Public Property ReceivedAt As String

        <DataMember(Name:="sender")>
        Public Property Originator As String

        <DataMember(Name:="prefix")>
        Public Property Prefix As String

        <DataMember(Name:="text")>
        Public Property Text As String

        <DataMember(Name:="phone")>
        Public Property Destination As String
    End Class
End Namespace
