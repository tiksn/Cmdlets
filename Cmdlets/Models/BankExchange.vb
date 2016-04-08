Imports TIKSN.Finance

Public Class BankExchange

	Public Sub New(BankName As String, Exchange As ICurrencyConverter)
		Me.BankName = BankName
		Me.Exchange = Exchange
	End Sub

	Public ReadOnly Property BankName As String

	Public ReadOnly Property Exchange As ICurrencyConverter

End Class
