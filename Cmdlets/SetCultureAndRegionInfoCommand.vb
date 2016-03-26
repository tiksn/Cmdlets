Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Set", "CultureAndRegionInfo")>
Public Class SetCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	Sub New()
		Dim builder As CultureAndRegionInfoBuilder = CultureAndRegionInfoDictionary(Name)

		'builder.AvailableCalendars
		'builder.CompareInfo
		'builder.ConsoleFallbackUICulture
		'builder.IetfLanguageTag
		'builder.NumberFormat
		'builder.TextInfo
	End Sub

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

	<Parameter()>
	Public Property ISOCurrencySymbol() As String

	<Parameter()>
	Public Property GeoId As Integer?

	<Parameter()>
	Public Property IsMetric As Boolean?

	<Parameter()>
	Public Property IsRightToLeft As Boolean?

	<Parameter()>
	Public Property KeyboardLayoutId As Integer?

	<Parameter()>
	Public Property ThreeLetterISOLanguageName As String

	<Parameter()>
	Public Property ThreeLetterISORegionName As String

	<Parameter()>
	Public Property ThreeLetterWindowsLanguageName As String

	<Parameter()>
	Public Property ThreeLetterWindowsRegionName As String

	<Parameter()>
	Public Property TwoLetterISOLanguageName As String

	<Parameter()>
	Public Property TwoLetterISORegionName As String

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

		If ISOCurrencySymbol IsNot Nothing Then
			builder.ISOCurrencySymbol = ISOCurrencySymbol
		End If

		If GeoId.HasValue Then
			builder.GeoId = GeoId.Value
		End If

		If IsMetric.HasValue Then
			builder.IsMetric = IsMetric.Value
		End If

		If IsRightToLeft.HasValue Then
			builder.IsRightToLeft = IsRightToLeft.Value
		End If

		If KeyboardLayoutId.HasValue Then
			builder.KeyboardLayoutId = KeyboardLayoutId.Value
		End If

		If ThreeLetterISOLanguageName IsNot Nothing Then
			builder.ThreeLetterISOLanguageName = ThreeLetterISOLanguageName
		End If

		If ThreeLetterISORegionName IsNot Nothing Then
			builder.ThreeLetterISORegionName = ThreeLetterISORegionName
		End If

		If ThreeLetterWindowsLanguageName IsNot Nothing Then
			builder.ThreeLetterWindowsLanguageName = ThreeLetterWindowsLanguageName
		End If

		If ThreeLetterWindowsRegionName IsNot Nothing Then
			builder.ThreeLetterWindowsRegionName = ThreeLetterWindowsRegionName
		End If

		If TwoLetterISOLanguageName IsNot Nothing Then
			builder.TwoLetterISOLanguageName = TwoLetterISOLanguageName
		End If

		If TwoLetterISORegionName IsNot Nothing Then
			builder.TwoLetterISORegionName = TwoLetterISORegionName
		End If
	End Sub
End Class
