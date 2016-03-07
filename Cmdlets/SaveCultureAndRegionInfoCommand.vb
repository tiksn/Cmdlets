Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Save", "CultureAndRegionInfo")>
Public Class SaveCultureAndRegionInfoCommand
	Inherits RegisterOrSaveCultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property FilePath() As String

	Protected Overrides Sub BeginProcessing()
		Dim builder As CultureAndRegionInfoBuilder = CreateBuilder()

		builder.Save(FilePath)
	End Sub
End Class
