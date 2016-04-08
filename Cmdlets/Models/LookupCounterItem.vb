Imports System.Collections.Generic

Public Class LookupCounterItem(Of TKey, TValue)

	Public Sub New(Key As TKey, Count As Integer, Values As IEnumerable(Of TValue))
		Me.Key = Key
		Me.Count = Count
		Me.Values = Values
	End Sub

	Public ReadOnly Property Key() As TKey

	Public ReadOnly Property Count() As Integer

	Public ReadOnly Property Values() As IEnumerable(Of TValue)
End Class
