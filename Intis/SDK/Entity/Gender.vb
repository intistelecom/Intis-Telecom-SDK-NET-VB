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
    ''' Subscriber gender
    ''' </summary>
    Module Gender

        Const Male As Integer = 1

        Const Female As Integer = 2

        Const Undefined As Integer = 3

        ''' <summary>
        ''' Parsing a string for getting gender of subscriber
        ''' </summary>
        ''' <param name="str">String representation of subscriber gender</param>
        ''' <returns>integer</returns>
        Function Parse(str As String) As Integer
            Select Case str
                Case "m"
                    Return Male
                Case "f"
                    Return Female
            End Select

            Return Undefined
        End Function
    End Module
End Namespace
