Imports System.Management.Automation

<Cmdlet("Export", "CultureAndRegionInfo")>
Public Class ExportCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property Name() As String

	<Parameter(Mandatory:=True)>
	Public Property FilePath() As String


	Protected Overrides Sub BeginProcessing()
		CultureAndRegionInfoDictionary(Name).Save(FilePath)
	End Sub
End Class
