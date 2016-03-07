Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Add", "CultureAndRegionInfo")>
Public Class AddCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	<Parameter(Mandatory:=True)>
	Public Property CultureAndRegionModifier() As CultureAndRegionModifiers


	Protected Overrides Sub BeginProcessing()
		Dim builder As New CultureAndRegionInfoBuilder(Name, CultureAndRegionModifier)

		CultureAndRegionInfoDictionary.Add(Name, builder)
	End Sub
End Class
