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

Namespace Intis.SDK.Entity

    Public Class BirthdayGreetingSettings

        Public Property Enabled As Integer

        Public Property DaysBefore As Integer

        Public Property Originator As String

        Public Property TimeToSend As String

        Public Property UseLocalTime As Integer

        Public Property Template As String

        Public Sub New(enabled As Integer, daysBefore As Integer, originator As String, timeToSend As String, useLocalTime As Integer, template As String)
            enabled = enabled
            daysBefore = daysBefore
            originator = originator
            timeToSend = timeToSend
            useLocalTime = useLocalTime
            template = template
        End Sub
    End Class
End Namespace
