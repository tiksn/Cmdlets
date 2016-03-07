﻿<System.Management.Automation.Cmdlet("Get", "CurrencyInfo")> _
Public Class GetCurrencyInfoCommand
    Inherits System.Management.Automation.Cmdlet

    <System.Management.Automation.Parameter> _
    Public Property CurrencyRegions() As System.Management.Automation.SwitchParameter

    <System.Management.Automation.Parameter> _
    Public Property ISOCurrencySymbol() As String

    Protected Overrides Sub BeginProcessing()

        Dim ISOCodeSpecified As Boolean = Not String.IsNullOrEmpty(Me.ISOCurrencySymbol)

        If Me.CurrencyRegions.IsPresent Then

            If ISOCodeSpecified Then

                Dim RegionalCurrencies = Me.GetSpecificCurrencyRegions(Me.ISOCurrencySymbol)

                Me.WriteObject(RegionalCurrencies, True)
            Else

                Dim RegionalCurrencies = Me.GetAllCurrencyRegions()

                Me.WriteObject(RegionalCurrencies, True)
            End If
        Else

            If ISOCodeSpecified Then

                Dim Currencies = Me.GetSpecificCurrency(Me.ISOCurrencySymbol)

                Me.WriteObject(Currencies, True)
            Else

                Dim Currencies = Me.GetAllCurrencies()

                Me.WriteObject(Currencies, True)
            End If
        End If

    End Sub

    Private Function GetAllCurrencyRegions() As System.Collections.Generic.List(Of CurrencyRegions)
        Dim Regions = GetRegionInfoCommand.GetAllRegions()

        Dim RegionalCurrencies = New System.Collections.Generic.List(Of CurrencyRegions)

        For Each Region In Regions

            Dim Currency = New TIKSN.Finance.CurrencyInfo(Region)

            If RegionalCurrencies.Any(Function(RC) RC.Currency = Currency) Then

                Dim RegionalCurrency = RegionalCurrencies.Single(Function(RC) RC.Currency = Currency)

                RegionalCurrency.Regions.Add(Region)
            Else
                Dim RegionalCurrency = New CurrencyRegions

                RegionalCurrency.Currency = Currency
                RegionalCurrency.Regions.Add(Region)

                RegionalCurrencies.Add(RegionalCurrency)
            End If
        Next

        Return RegionalCurrencies
    End Function

    Private Function GetSpecificCurrencyRegions(ISOCode As String) As System.Collections.Generic.List(Of CurrencyRegion)

        Dim Regions = GetRegionInfoCommand.GetAllRegions()

        Dim Result = New System.Collections.Generic.List(Of CurrencyRegion)

        For Each Region In Regions

            If String.Compare(Region.ISOCurrencySymbol, ISOCode, System.StringComparison.InvariantCultureIgnoreCase) = 0 Then

                Result.Add(New CurrencyRegion(Region))
            End If
        Next

        Return Result
    End Function

    Private Function GetAllCurrencies() As System.Collections.Generic.HashSet(Of TIKSN.Finance.CurrencyInfo)
        Dim Regions = GetRegionInfoCommand.GetAllRegions()

        Dim Currencies As New System.Collections.Generic.HashSet(Of TIKSN.Finance.CurrencyInfo)

        For Each Region In Regions
            Currencies.Add(New TIKSN.Finance.CurrencyInfo(Region))
        Next

        Return Currencies
    End Function

    Private Function GetSpecificCurrency(ISOCode As String) As System.Collections.Generic.IEnumerable(Of TIKSN.Finance.CurrencyInfo)
        Dim Regions = GetRegionInfoCommand.GetAllRegions()

        Dim Currencies As New System.Collections.Generic.List(Of TIKSN.Finance.CurrencyInfo)

        For Each Region In Regions

            If String.Compare(Region.ISOCurrencySymbol, ISOCode, System.StringComparison.InvariantCultureIgnoreCase) = 0 Then

                Currencies.Add(New TIKSN.Finance.CurrencyInfo(Region))
            End If
        Next

        Return Currencies
    End Function
End Class