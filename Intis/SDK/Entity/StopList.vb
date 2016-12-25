Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class StopList

        Public Property Id As Int64

        <DataMember(Name:="time_in")>
        Public Property TimeAddedAt As String

        <DataMember(Name:="description")>
        Public Property Description As String
    End Class
End Namespace
