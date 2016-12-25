Imports System.Collections.Specialized
Imports Intis.SDK

Namespace Test

    Class LocalApiConnector
        Implements IApiConnector

        Private _data As String

        Public Sub New(ByVal data As String)
            _data = data
        End Sub

        Public Function GetContentFromApi(ByVal link As String, ByVal allParameters As NameValueCollection) As String Implements IApiConnector.GetContentFromApi
            Return _data
        End Function

        Public Function GetTimestampFromApi(ByVal link As String) As String Implements IApiConnector.GetTimestampFromApi
            Return String.Empty
        End Function
    End Class
End Namespace
