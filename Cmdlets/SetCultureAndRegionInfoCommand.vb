Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Set", "CultureAndRegionInfo")>
Public Class SetCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	<Parameter()>
	Public Property SourceCultureInfo() As CultureInfo

	<Parameter()>
	Public Property SourceRegionInfo() As RegionInfo

	Protected Overrides Sub BeginProcessing()
		Dim builder As CultureAndRegionInfoBuilder = CultureAndRegionInfoDictionary(Name)

		If SourceCultureInfo IsNot Nothing Then
			builder.LoadDataFromCultureInfo(SourceCultureInfo)
		End If

		If SourceRegionInfo IsNot Nothing Then
			builder.LoadDataFromRegionInfo(SourceRegionInfo)
		End If
	End Sub
End Class
