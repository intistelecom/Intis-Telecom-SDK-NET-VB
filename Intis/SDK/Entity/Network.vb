Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class Network

        <DataMember(Name:="operator")>
        Public Property Title As String

        <DataMember(Name:="currency")>
        Private Property Currency As String

        <DataMember(Name:="error")>
        Private Property [Error] As Integer

        <DataMember(Name:="mcc")>
        Private Property Mcc As String

        <DataMember(Name:="mnc")>
        Private Property Mnc As String

        <DataMember(Name:="phone")>
        Private Property Phone As String

        <DataMember(Name:="ported")>
        Private Property Ported As String

        <DataMember(Name:="price")>
        Private Property Price As String

        <DataMember(Name:="regionCode")>
        Private Property RegionCode As Integer

        <DataMember(Name:="timeZone")>
        Private Property TimeZone As Integer
    End Class
End Namespace
