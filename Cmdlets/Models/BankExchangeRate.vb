Imports TIKSN.Finance

Public Class BankExchangeRate

	Public Sub New(BankName As String, CurrencyPair As CurrencyPair, Rate As Decimal)
		Me.BankName = BankName
		Me.CurrencyPair = CurrencyPair
		Me.Rate = Rate
	End Sub

	Public ReadOnly Property BankName As String

	Public ReadOnly Property CurrencyPair As CurrencyPair

	Public ReadOnly Property Rate As Decimal
End Class
