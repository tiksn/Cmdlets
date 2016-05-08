Imports System
Imports System.Collections.Generic
Imports System.Management.Automation
Imports TIKSN.Finance

<Cmdlet("Get", "ExchangeRate")>
Public Class GetExchangeRateCommand
	Inherits Cmdlet

	<Parameter(Mandatory:=True)>
	Public Property BaseCurrency As String

	<Parameter(Mandatory:=True)>
	Public Property CounterCurrency As String

	<Parameter(Mandatory:=False)>
	Public Property AsOn As DateTimeOffset?

	Protected Overrides Sub BeginProcessing()
		Dim banks = GetSupportedBanks()
		Dim exchangeDate = If(AsOn.HasValue, AsOn.Value, DateTimeOffset.Now)

		Dim result As New List(Of BankExchangeRate)

		Dim pair As New CurrencyPair(New CurrencyInfo(BaseCurrency), New CurrencyInfo(CounterCurrency))
		Dim BankProgressRecord As New ProgressRecord(0, "Retrieving exchange rates from bank", "Bank name")

		For Each bank In banks

			BankProgressRecord.StatusDescription = bank.BankName
			WriteProgress(BankProgressRecord)

			WriteVerbose(String.Format("Retrieving supported currencies from {0}", bank.BankName))

			Try
				Dim pairs = bank.Exchange.GetCurrencyPairsAsync(exchangeDate).Result

				If pairs.Any(Function(item) item.Equals(pair)) Then
					WriteVerbose(String.Format("Retrieving {1} exchange rate from {0}", bank.BankName, pair))
					Dim rate = bank.Exchange.GetExchangeRateAsync(pair, exchangeDate).Result
					result.Add(New BankExchangeRate(bank.BankName, pair, rate))
				End If
			Catch ex As Exception
				WriteError(New ErrorRecord(ex, "", ErrorCategory.InvalidResult, Nothing))
			End Try
		Next

		WriteObject(result, True)

		If result.Count = 0 Then
			WriteWarning(String.Format("Exchange rate for {0} is not found.", pair))
		End If

		BankProgressRecord.RecordType = ProgressRecordType.Completed
		WriteProgress(BankProgressRecord)
	End Sub
End Class
