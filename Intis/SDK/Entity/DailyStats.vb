Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class DailyStats

        <DataMember(Name:="date")>
        Public Property Day As String

        <DataMember(Name:="stats")>
        Public Property Stats As List(Of Stats)
    End Class
End Namespace
