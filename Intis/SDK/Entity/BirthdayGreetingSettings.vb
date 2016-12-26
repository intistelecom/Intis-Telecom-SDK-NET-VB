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

    ''' <summary>
    ''' Class BirthdayGreetingSettings
    ''' Getting settings of birthday greetings
    ''' </summary>
    Public Class BirthdayGreetingSettings

        ''' <summary>
        ''' key that is responsible for sending birthday greeting
        ''' </summary>
        ''' <returns>integer</returns>
        Public Property Enabled As Integer

        ''' <summary>
        ''' number of days to send greetings before
        ''' </summary>
        ''' <returns>integer</returns>
        Public Property DaysBefore As Integer

        ''' <summary>
        ''' sender name of greeting SMS
        ''' </summary>
        ''' <returns>string</returns>
        Public Property Originator As String

        ''' <summary>
        ''' time for sending greetings
        ''' </summary>
        ''' <returns>string</returns>
        Public Property TimeToSend As String

        ''' <summary>
        ''' use local time of subscriber while SMS sending
        ''' </summary>
        ''' <returns>integer</returns>
        Public Property UseLocalTime As Integer

        ''' <summary>
        ''' text template for sending greetings
        ''' </summary>
        ''' <returns>string</returns>
        Public Property Template As String

        Public Sub New(enabled As Integer, daysBefore As Integer, originator As String, timeToSend As String, useLocalTime As Integer, template As String)
            MyClass.Enabled = enabled
            MyClass.DaysBefore = daysBefore
            MyClass.Originator = originator
            MyClass.TimeToSend = timeToSend
            MyClass.UseLocalTime = useLocalTime
            MyClass.Template = template
        End Sub
    End Class
End Namespace
