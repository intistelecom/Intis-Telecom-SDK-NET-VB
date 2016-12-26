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
    ''' SMS sending response
    ''' </summary>
    <DataContract>
    Class MessageSending

        ''' <summary>
        ''' Phone number
        ''' </summary>
        ''' <returns></returns>
        Public Property Phone As Int64

        ''' <summary>
        ''' Message ID
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="id_sms")>
        Public Property MessageId As String

        ''' <summary>
        ''' Message price
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="cost")>
        Public Property Cost As Single

        ''' <summary>
        ''' Name of currency
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="currency")>
        Public Property Currency As String

        ''' <summary>
        ''' Number of message parts
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="count_sms")>
        Public Property MessagesCount As Integer

        ''' <summary>
        ''' Error text in SMS sending
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="error")>
        Public Property [Error] As Integer
    End Class
End Namespace
