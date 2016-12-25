' MIT License

' Copyright (c) 2016 Intis Telecom

' Permission is hereby granted, free of charge, to any person obtaining a copy
' of this software and associated documentation files (the "Software"), to deal
' in the Software without restriction, including without limitation the rights
' to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
' copies of the Software, and to permit persons to whom the Software is
' furnished to do so, subject to the following conditions:

' The above copyright notice and this permission notice shall be included in all
' copies or substantial portions of the Software.

' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
' IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
' FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
' AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
' LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
' OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
' SOFTWARE.

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
