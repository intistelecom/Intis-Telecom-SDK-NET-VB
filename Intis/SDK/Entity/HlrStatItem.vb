Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class HlrStatItem
        Inherits HlrResponse

        <DataMember(Name:="message_id")>
        Public Property MessageId As String

        <DataMember(Name:="total_price")>
        Public Property TotalPrice As Single

        <DataMember(Name:="request_id")>
        Public Property RequestId As String

        <DataMember(Name:="request_time")>
        Public Property RequestTime As String
    End Class
End Namespace
