﻿' MIT License

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

    <DataContract>
    Public Class HlrResponse

        <DataMember(Name:="id")>
        Public Property Id As String

        <DataMember(Name:="destination")>
        Public Property Destination As Int64

        <DataMember(Name:="stat")>
        Private Property StatusString As String

        Public ReadOnly Property Status As Integer
            Get
                Return HlrResponseState.Parse(StatusString)
            End Get
        End Property

        <DataMember(Name:="IMSI")>
        Public Property Imsi As String

        <DataMember(Name:="mccmnc")>
        Private Property Mccmnc As String

        Public ReadOnly Property Mcc As String
            Get
                Return Mccmnc.Substring(0, 3)
            End Get
        End Property

        Public ReadOnly Property Mnc As String
            Get
                Return Mccmnc.Substring(3)
            End Get
        End Property

        <DataMember(Name:="ocn")>
        Public Property OriginalCountryName As String

        <DataMember(Name:="ocp")>
        Public Property OriginalCountryCode As String

        <DataMember(Name:="orn")>
        Public Property OriginalNetworkName As String

        <DataMember(Name:="onp")>
        Public Property OriginalNetworkPrefix As String

        <DataMember(Name:="rcn")>
        Public Property RoamingCountryName As String

        <DataMember(Name:="rcp")>
        Public Property RoamingCountryPrefix As String

        <DataMember(Name:="ron")>
        Public Property RoamingNetworkName As String

        <DataMember(Name:="rnp")>
        Public Property RoamingNetworkPrefix As String

        <DataMember(Name:="pcn")>
        Public Property PortedCountryName As String

        <DataMember(Name:="pcp")>
        Public Property PortedCountryPrefix As String

        <DataMember(Name:="pon")>
        Public Property PortedNetworkName As String

        <DataMember(Name:="pnp")>
        Public Property PortedNetworkPrefix As String

        <DataMember(Name:="ppm")>
        Public Property PricePerMessage As Single

        <DataMember(Name:="is_ported")>
        Public Property IsPorted As Boolean

        <DataMember(Name:="is_roaming")>
        Public Property IsInRoaming As Boolean
    End Class
End Namespace
