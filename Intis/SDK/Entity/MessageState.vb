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

    Module MessageState

        Const Scheduled As Integer = 0

        Const Enroute As Integer = 1

        Const Delivered As Integer = 2

        Const Expired As Integer = 3

        Const Deleted As Integer = 4

        Const Undeliverable As Integer = 5

        Const Accepted As Integer = 6

        Const Unknown As Integer = 7

        Const Rejected As Integer = 8

        Const Skipped As Integer = 9

        Function Parse(state As String) As Integer?
            Select Case state
                Case "deliver"
                    Return Delivered
                Case "expired"
                    Return Expired
                Case "not_deliver"
                    Return Undeliverable
                Case "partly_deliver"
                    Return Accepted
                Case Else
                    Return Nothing
            End Select
        End Function
    End Module
End Namespace
