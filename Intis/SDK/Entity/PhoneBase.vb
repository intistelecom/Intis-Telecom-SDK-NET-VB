Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class PhoneBase

        Public Property BaseId As Int64

        <DataMember(Name:="name")>
        Public Property Title As String

        <DataMember(Name:="count")>
        Public Property Count As Integer

        <DataMember(Name:="pages")>
        Public Property Pages As Integer

        <DataMember(Name:="on_birth")>
        Private Property Enabled As Integer

        <DataMember(Name:="day_before")>
        Private Property DaysBefore As Integer

        <DataMember(Name:="birth_sender")>
        Private Property Originator As String

        <DataMember(Name:="time_birth")>
        Private Property TimeToSend As String

        <DataMember(Name:="local_time")>
        Private Property UseLocalTime As Integer

        <DataMember(Name:="birth_text")>
        Private Property Template As String

        Public ReadOnly Property BirthdayGreetingSettings As BirthdayGreetingSettings
            Get
                Return New BirthdayGreetingSettings(Enabled, DaysBefore, Originator, TimeToSend, UseLocalTime, Template)
            End Get
        End Property
    End Class
End Namespace
