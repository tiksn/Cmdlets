Imports System.Management.Automation

<Cmdlet("Remove", "CultureAndRegionInfo")>
Public Class RemoveCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property Name() As String


	Protected Overrides Sub BeginProcessing()
		CultureAndRegionInfoDictionary.Remove(Name)
	End Sub
End Class
