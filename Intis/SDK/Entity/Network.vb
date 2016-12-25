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
