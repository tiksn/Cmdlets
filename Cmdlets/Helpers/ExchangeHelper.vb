Imports System
Imports System.Collections.Generic
Imports TIKSN.Finance.ForeignExchange

Module ExchangeHelper

	Private bankCollection As New Lazy(Of IEnumerable(Of BankExchange))(AddressOf CreateBanksCollection)

	Private Function CreateBanksCollection() As IEnumerable(Of BankExchange)
		Dim banks As New List(Of BankExchange)

		banks.Add(New BankExchange("Bank of Canada", New BankOfCanada))
		banks.Add(New BankExchange("Bank of England", New BankOfEngland))
		banks.Add(New BankExchange("The Central Bank of the Russian Federation", New BankOfRussia))
		banks.Add(New BankExchange("The Central Bank of the Republic of Armenia", New CentralBankOfArmenia))
		banks.Add(New BankExchange("European Central Bank", New EuropeanCentralBank))
		banks.Add(New BankExchange("Federal Reserve System", New FederalReserveSystem))
		banks.Add(New BankExchange("National Bank of Ukraine", New NationalBankOfUkraine))
		banks.Add(New BankExchange("Reserve Bank of Australia", New ReserveBankOfAustralia))
		banks.Add(New BankExchange("Swiss National Bank", New SwissNationalBank))

		Return banks
	End Function

	Public Function GetSupportedBanks() As IEnumerable(Of BankExchange)
		Return bankCollection.Value
	End Function
End Module
