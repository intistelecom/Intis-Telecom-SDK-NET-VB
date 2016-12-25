Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Class MessageSending

        Public Property Phone As Int64

        <DataMember(Name:="id_sms")>
        Public Property MessageId As String

        <DataMember(Name:="cost")>
        Public Property Cost As Single

        <DataMember(Name:="currency")>
        Public Property Currency As String

        <DataMember(Name:="count_sms")>
        Public Property MessagesCount As Integer

        <DataMember(Name:="error")>
        Public Property [Error] As Integer
    End Class
End Namespace
