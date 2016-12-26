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
    ''' Class for analysis sender status
    ''' </summary>
    Module OriginatorState

        ''' <summary>
        ''' Constant for approved sender
        ''' </summary>
        Const Completed As Integer = 1

        ''' <summary>
        ''' Constant for sender in moderation queue
        ''' </summary>
        Const Moderation As Integer = 2

        ''' <summary>
        ''' Constant for rejected sender
        ''' </summary>
        Const Rejected As Integer = 3

        ''' <summary>
        ''' Parse string to OriginatorState constants 
        ''' </summary>
        ''' <param name="str">String presentation of sender status</param>
        ''' <returns></returns>
        Function Parse(str As String) As Integer?
            Select Case str
                Case "completed"
                    Return Completed
                Case "order"
                    Return Moderation
                Case "rejected"
                    Return Rejected
            End Select

            Return Nothing
        End Function
    End Module
End Namespace
