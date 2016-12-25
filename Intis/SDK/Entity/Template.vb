Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class Template

        Public Property Id As Int64

        <DataMember(Name:="name")>
        Public Property Title As String

        <DataMember(Name:="template")>
        Public Property template As String

        <DataMember(Name:="up_time")>
        Public Property CreatedAt As String
    End Class
End Namespace
