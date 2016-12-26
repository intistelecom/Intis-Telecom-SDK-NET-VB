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

    ''' <summary>
    ''' Class of getting subscriber data in list
    ''' </summary>
    <DataContract>
    Public Class PhoneBaseItem

        ''' <summary>
        ''' Phone number of subscriber
        ''' </summary>
        ''' <returns></returns>
        Public Property Phone As Int64

        ''' <summary>
        ''' Subscriber first name
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="name")>
        Public Property FirstName As String

        ''' <summary>
        ''' Subscriber middle name
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="middle_name")>
        Public Property MiddleName As String

        ''' <summary>
        ''' Subscriber last name
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="last_name")>
        Public Property LastName As String

        ''' <summary>
        ''' Subscriber birth date
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="date_birth")>
        Public Property BirthDay As String

        <DataMember(Name:="male")>
        Private Property GenderString As String

        ''' <summary>
        ''' Gender of subscriber
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Gender As Integer
            Get
                Return Entity.Gender.Parse(GenderString)
            End Get
        End Property

        ''' <summary>
        ''' Region of subscriber
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="region")>
        Public Property Area As String

        ''' <summary>
        ''' Operator of subscriber
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="operator")>
        Public Property Network As String

        <DataMember(Name:="note1")>
        Public Property Note1 As String

        <DataMember(Name:="note2")>
        Public Property Note2 As String
    End Class
End Namespace
