Imports System.Runtime.Serialization

Namespace Intis.SDK.Exceptions

    <Serializable>
    Public Class SdkException
        Inherits Exception

        Public Property Code As Integer

        Public Shared Function GetMessage(ByVal code As Integer) As String
            Dim messages = New Dictionary(Of Integer, String) From {{0, "Service is disabled"}, {1, "Signature is not specified"}, {2, "Login is not specified"}, {3, "Text is not specified"}, {4, "Phone number is not specified"}, {5, "Sender is not specified"}, {6, "Incorrect signature"}, {7, "Incorrect login"}, {8, "Incorrect sender name"}, {9, "Unregistered sender name"}, {10, "Sender name is not approved"}, {11, "There are forbidden words in the text"}, {12, "SMS sending error"}, {13, "Phone number is in stop-list. SMS sending to this number is blocked"}, {14, "There are more than 50 numbers in the request"}, {15, "List is not specified"}, {16, "Invalid number"}, {17, "SMS ID are not specified"}, {18, "Status is not received"}, {19, "Empty response"}, {20, "This number is already taken"}, {21, "No name"}, {22, "This template is already created"}, {23, "Month is not specified (format: YYYY-MM)"}, {24, "Time stamp is not specified"}, {25, "Error in access to list"}, {26, "There are no numbers in the list"}, {27, "There are no valid numbers"}, {28, "Initial date is not specified"}, {29, "Final date is not specified"}, {30, "Wrong or empty date (format: YYYY-MM-DD)"}, {31, "Unavailable direction"}, {32, "Low balance"}, {33, "Wrong phone number"}, {34, "Phone is in the global stop-list"}, {35, "Billing failed"}}
            Dim message = ""
            messages.TryGetValue(code, message)
            Return message
        End Function

        Public Sub New()
        End Sub

        Public Sub New(ByVal code As Integer)
            MyBase.New(GetMessage(code))

            MyClass.Code = code
        End Sub

        Public Sub New(ByVal format As String, ParamArray args As Object())
            MyBase.New(String.Format(format, args))
        End Sub

        Public Sub New(ByVal code As Integer, ByVal innerException As Exception)
            MyBase.New(GetMessage(code), innerException)

            MyClass.Code = code
        End Sub

        Public Sub New(ByVal format As String, ByVal innerException As Exception, ParamArray args As Object())
            MyBase.New(String.Format(format, args), innerException)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub
    End Class
End Namespace
