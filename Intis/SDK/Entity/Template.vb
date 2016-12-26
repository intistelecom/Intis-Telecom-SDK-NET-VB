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
    ''' Class for getting user templates
    ''' </summary>
    <DataContract>
    Public Class Template

        ''' <summary>
        ''' Template ID
        ''' </summary>
        ''' <returns></returns>
        Public Property Id As Int64

        ''' <summary>
        ''' Template name
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="name")>
        Public Property Title As String

        ''' <summary>
        ''' Text of template
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="template")>
        Public Property template As String

        ''' <summary>
        ''' Time of template creating
        ''' </summary>
        ''' <returns></returns>
        <DataMember(Name:="up_time")>
        Public Property CreatedAt As String
    End Class
End Namespace
