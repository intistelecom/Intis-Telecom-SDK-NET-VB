Imports System.Collections.Specialized

Namespace Intis.SDK

    Public Interface IApiConnector

        Function GetContentFromApi(ByVal link As String, ByVal allParameters As NameValueCollection) As String

        Function GetTimestampFromApi(ByVal link As String) As String

    End Interface
End Namespace
