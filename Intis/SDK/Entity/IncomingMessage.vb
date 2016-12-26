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
    ''' Class for getting incoming message
    ''' </summary>
    <DataContract>
    Public Class IncomingMessage

        ''' <summary>
        ''' Message ID
        ''' </summary>
        ''' <returns></returns>
        Public Property MessageId As String

        ''' <summary>
        ''' Date of message receipt
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="date")>
        Public Property ReceivedAt As String

        ''' <summary>
        ''' Sender name
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="sender")>
        Public Property Originator As String

        ''' <summary>
        ''' Prefix of incoming message
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="prefix")>
        Public Property Prefix As String

        ''' <summary>
        ''' SMS text
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="text")>
        Public Property Text As String

        ''' <summary>
        ''' Message destination
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="phone")>
        Public Property Destination As String
    End Class
End Namespace
