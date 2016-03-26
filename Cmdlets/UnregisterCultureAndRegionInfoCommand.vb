Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Unregister", "CultureAndRegionInfo")>
Public Class UnregisterCultureAndRegionInfoCommand
	Inherits Cmdlet

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	Protected Overrides Sub BeginProcessing()

		CultureAndRegionInfoBuilder.Unregister(Name)
	End Sub
End Class
