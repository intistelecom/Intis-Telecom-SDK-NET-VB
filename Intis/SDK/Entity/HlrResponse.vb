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

Imports System.Runtime.Serialization

Namespace Intis.SDK.Entity

    ''' <summary>
    ''' HLR response
    ''' </summary>
    <DataContract>
    Public Class HlrResponse

        ''' <summary>
        ''' Number ID
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="id")>
        Public Property Id As String

        ''' <summary>
        ''' Address
        ''' </summary>
        ''' <returns>integer</returns>
        <DataMember(Name:="destination")>
        Public Property Destination As Int64

        <DataMember(Name:="stat")>
        Private Property StatusString As String

        ''' <summary>
        ''' Status of subscriber
        ''' </summary>
        ''' <returns>string</returns>
        Public ReadOnly Property Status As Integer
            Get
                Return HlrResponseState.Parse(StatusString)
            End Get
        End Property

        ''' <summary>
        ''' IMSI of subscriber
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="IMSI")>
        Public Property Imsi As String

        <DataMember(Name:="mccmnc")>
        Private Property Mccmnc As String

        ''' <summary>
        ''' MCC of subscriber
        ''' </summary>
        ''' <returns>string</returns>
        Public ReadOnly Property Mcc As String
            Get
                Return Mccmnc.Substring(0, 3)
            End Get
        End Property

        ''' <summary>
        ''' MNC of subscriber
        ''' </summary>
        ''' <returns>string</returns>
        Public ReadOnly Property Mnc As String
            Get
                Return Mccmnc.Substring(3)
            End Get
        End Property

        ''' <summary>
        ''' The original code of the subscriber's country
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="ocn")>
        Public Property OriginalCountryName As String

        ''' <summary>
        ''' The original code of the subscriber's country
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="ocp")>
        Public Property OriginalCountryCode As String

        ''' <summary>
        ''' The original name of the subscriber's operator
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="orn")>
        Public Property OriginalNetworkName As String

        ''' <summary>
        '''  The original prefix of the subscriber's operator
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="onp")>
        Public Property OriginalNetworkPrefix As String

        ''' <summary>
        ''' Name of country in the subscriber's roaming
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="rcn")>
        Public Property RoamingCountryName As String

        ''' <summary>
        ''' Prefix of country in the subscriber's roaming
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="rcp")>
        Public Property RoamingCountryPrefix As String

        ''' <summary>
        ''' Operator in the subscriber's roaming
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="ron")>
        Public Property RoamingNetworkName As String

        ''' <summary>
        ''' Prefix of operator in the subscriber's roaming
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="rnp")>
        Public Property RoamingNetworkPrefix As String

        ''' <summary>
        ''' Name of country if the phone number of the subscriber is ported
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="pcn")>
        Public Property PortedCountryName As String

        ''' <summary>
        ''' Prefix of country if the phone number of the subscriber is ported
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="pcp")>
        Public Property PortedCountryPrefix As String

        ''' <summary>
        ''' Name of operator if the phone number of the subscriber is ported
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="pon")>
        Public Property PortedNetworkName As String

        ''' <summary>
        ''' Prefix of operator if the phone number of the subscriber is ported
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="pnp")>
        Public Property PortedNetworkPrefix As String

        ''' <summary>
        ''' Price for message
        ''' </summary>
        ''' <returns>float</returns>
        <DataMember(Name:="ppm")>
        Public Property PricePerMessage As Single

        ''' <summary>
        ''' Key that is responsible for identification of a ported number
        ''' </summary>
        ''' <returns>integer</returns>
        <DataMember(Name:="is_ported")>
        Public Property IsPorted As Boolean

        ''' <summary>
        ''' Key that is responsible for identification a subscriber in roaming
        ''' </summary>
        ''' <returns>string</returns>
        <DataMember(Name:="is_roaming")>
        Public Property IsInRoaming As Boolean
    End Class
End Namespace
