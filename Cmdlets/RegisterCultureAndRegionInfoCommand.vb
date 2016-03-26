Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Register", "CultureAndRegionInfo")>
Public Class RegisterCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	Protected Overrides Sub BeginProcessing()
		Dim builder As CultureAndRegionInfoBuilder = CultureAndRegionInfoDictionary(Name)

		builder.Register()
	End Sub
End Class
