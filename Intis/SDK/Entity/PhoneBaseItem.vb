Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    <DataContract>
    Public Class PhoneBaseItem

        Public Property Phone As Int64

        <DataMember(Name:="name")>
        Public Property FirstName As String

        <DataMember(Name:="middle_name")>
        Public Property MiddleName As String

        <DataMember(Name:="last_name")>
        Public Property LastName As String

        <DataMember(Name:="date_birth")>
        Public Property BirthDay As String

        <DataMember(Name:="male")>
        Private Property GenderString As String

        Public ReadOnly Property Gender As Integer
            Get
                Return Entity.Gender.Parse(GenderString)
            End Get
        End Property

        <DataMember(Name:="region")>
        Public Property Area As String

        <DataMember(Name:="operator")>
        Public Property Network As String

        <DataMember(Name:="note1")>
        Public Property Note1 As String

        <DataMember(Name:="note2")>
        Public Property Note2 As String
    End Class
End Namespace
