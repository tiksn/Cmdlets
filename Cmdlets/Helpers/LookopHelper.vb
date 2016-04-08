Imports System.Collections.Generic

Module LookopHelper

	Public Function GetCountableList(Of TKey, TValue)(lookup As ILookup(Of TKey, TValue)) As IEnumerable(Of LookupCounterItem(Of TKey, TValue))
		Dim countableItems As New List(Of LookupCounterItem(Of TKey, TValue))

		For Each item In lookup
			countableItems.Add(New LookupCounterItem(Of TKey, TValue)(item.Key, item.Count, item))
		Next

		Return countableItems
	End Function

End Module
