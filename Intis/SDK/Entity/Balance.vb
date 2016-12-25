Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class Balance

        <DataMember(Name:="money")>
        Public Property Amount As String

        <DataMember(Name:="currency")>
        Public Property Currency As String
    End Class
End Namespace
