Imports System.Globalization
Imports System.Management.Automation

Public Class RegisterOrSaveCultureAndRegionInfoCommandBase
	Inherits Cmdlet

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	<Parameter(Mandatory:=True)>
	Public Property CultureAndRegionModifier() As CultureAndRegionModifiers

	<Parameter()>
	Public Property SourceCultureInfo() As CultureInfo

	<Parameter()>
	Public Property SourceRegionInfo() As RegionInfo

	Protected Function CreateBuilder() As CultureAndRegionInfoBuilder
		Dim builder As New CultureAndRegionInfoBuilder(Name, CultureAndRegionModifier)

		If SourceCultureInfo IsNot Nothing Then
			builder.LoadDataFromCultureInfo(SourceCultureInfo)
		End If

		If SourceRegionInfo IsNot Nothing Then
			builder.LoadDataFromRegionInfo(SourceRegionInfo)
		End If

		Return builder
	End Function
End Class
