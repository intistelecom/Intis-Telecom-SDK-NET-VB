Imports System.Collections.Specialized

Namespace Intis.SDK.Exceptions

    Public Class IncomingMessageException
        Inherits Exception

        Public Property Parameters As NameValueCollection

        Public Sub New(ByVal parameters As NameValueCollection)
            MyClass.Parameters = parameters
        End Sub

        Public Sub New(ByVal parameters As NameValueCollection, ByVal innerException As Exception)
            MyBase.New(innerException.Message)
            MyClass.Parameters = parameters
        End Sub
    End Class
End Namespace
