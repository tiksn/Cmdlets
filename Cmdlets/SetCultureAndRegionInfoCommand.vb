Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Set", "CultureAndRegionInfo")>
Public Class SetCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	<Parameter()>
	Public Property Parent() As CultureInfo

	<Parameter()>
	Public Property SourceCultureInfo() As CultureInfo

	<Parameter()>
	Public Property SourceRegionInfo() As RegionInfo

	<Parameter()>
	Public Property CultureEnglishName() As String

	<Parameter()>
	Public Property CultureNativeName() As String

	<Parameter()>
	Public Property CurrencyEnglishName() As String

	<Parameter()>
	Public Property CurrencyNativeName() As String

	<Parameter()>
	Public Property RegionEnglishName() As String

	<Parameter()>
	Public Property RegionNativeName() As String


	Protected Overrides Sub BeginProcessing()
		Dim builder As CultureAndRegionInfoBuilder = CultureAndRegionInfoDictionary(Name)

		If SourceCultureInfo IsNot Nothing Then
			builder.LoadDataFromCultureInfo(SourceCultureInfo)
		End If

		If SourceRegionInfo IsNot Nothing Then
			builder.LoadDataFromRegionInfo(SourceRegionInfo)
		End If

		If Parent IsNot Nothing Then
			builder.Parent = Parent
		End If

		If CultureEnglishName IsNot Nothing Then
			builder.CultureEnglishName = CultureEnglishName
		End If

		If CultureNativeName IsNot Nothing Then
			builder.CultureNativeName = CultureNativeName
		End If

		If CurrencyNativeName IsNot Nothing Then
			builder.CurrencyNativeName = CurrencyNativeName
		End If

		If CultureEnglishName IsNot Nothing Then
			builder.CultureEnglishName = CultureEnglishName
		End If

		If RegionNativeName IsNot Nothing Then
			builder.RegionNativeName = RegionNativeName
		End If

	End Sub
End Class
