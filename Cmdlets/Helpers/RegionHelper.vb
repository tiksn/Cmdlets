Imports System.Collections.Generic
Imports System.Globalization

Module RegionHelper

	Public Function GetAllRegions(Optional CultureOnly As Boolean = False) As List(Of RegionInfo)
		Dim RegionNames As New HashSet(Of String)
		For Each CI In CultureInfo.GetCultures(CultureTypes.SpecificCultures)
			RegionNames.Add(CI.Name)
		Next
		Dim Regions As New List(Of RegionInfo)
		For Each RegionName In RegionNames
			Regions.Add(New RegionInfo(RegionName))
		Next
		If Not CultureOnly Then
			For Each Region In Regions
				RegionNames.Add(Region.TwoLetterISORegionName)
			Next
			Regions.Clear()
			For Each RegionName In RegionNames
				Regions.Add(New RegionInfo(RegionName))
			Next
		End If

		Return Regions
	End Function

End Module
