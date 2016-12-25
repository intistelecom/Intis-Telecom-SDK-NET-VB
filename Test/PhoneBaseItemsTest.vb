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

Imports Intis.SDK
Imports Intis.SDK.Exceptions
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace Test

    <TestClass>
    Public Class PhoneBaseItemsTest

        Const Login As String = "your api login"

        Const ApiKey As String = "your api key here"

        Const ApiHost As String = "http://api.host.com/get/"

        <TestMethod>
        Public Sub TestGetPhoneBaseItems()
            Dim connector As IApiConnector = New LocalApiConnector(getData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            Dim bases = client.GetPhoneBaseItems(125480, 2)
            For Each one In bases
                Dim phone = one.Phone
                Dim firstName = one.FirstName
                Dim middleName = one.MiddleName
                Dim lastName = one.LastName
                Dim birthDay = one.BirthDay
                Dim area = one.Area
                Dim gender = one.Gender
                Dim network = one.Network
                Dim note1 = one.Note1
                Dim note2 = one.Note2
            Next

            Assert.IsNotNull(bases)
        End Sub

        <TestMethod>
        <ExpectedException(GetType(PhoneBaseItemException))>
        Public Sub TestGetPhoneBaseItemsException()
            Dim connector As IApiConnector = New LocalApiConnector(getErrorData())
            Dim client = New IntisClient(Login, ApiKey, ApiHost, connector)
            client.GetPhoneBaseItems(125480, 2)
        End Sub

        Private Function getData() As String
            Return "{""442073238000"":{""name"":""Jon"",""last_name"":""Voight"",""middle_name"":"""",""date_birth"":""0000-00-00"",""male"":""m"",""note1"":"""",""note2"":"""",""region"":null,""operator"":null}," & """442073238001"":{""name"":""Jon"",""last_name"":""Voight"",""middle_name"":"""",""date_birth"":""0000-00-00"",""male"":""m"",""note1"":"""",""note2"":"""",""region"":null,""operator"":null}}"
        End Function

        Private Function getErrorData() As String
            Return "{""error"":4}"
        End Function
    End Class
End Namespace
