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
    ''' Class for getting data of phone number list
    ''' </summary>
    <DataContract>
    Public Class PhoneBase

        ''' <summary>
        ''' List ID
        ''' </summary>
        ''' <returns></returns>
        Public Property BaseId As Int64

        ''' <summary>
        ''' Name of list
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="name")>
        Public Property Title As String

        ''' <summary>
        ''' Number of contacts in list
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="count")>
        Public Property Count As Integer

        ''' <summary>
        ''' Number of pages in list
        ''' </summary>
        ''' <returns></returns>
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

        ''' <summary>
        ''' Settings of birthday greeting for the list contacts
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property BirthdayGreetingSettings As BirthdayGreetingSettings
            Get
                Return New BirthdayGreetingSettings(Enabled, DaysBefore, Originator, TimeToSend, UseLocalTime, Template)
            End Get
        End Property
    End Class
End Namespace
