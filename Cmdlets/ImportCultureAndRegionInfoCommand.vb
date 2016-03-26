Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Import", "CultureAndRegionInfo")>
Public Class ImportCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter(Mandatory:=True)>
	Public Property FilePath() As String


	Protected Overrides Sub BeginProcessing()
		Dim builder As CultureAndRegionInfoBuilder = CultureAndRegionInfoBuilder.CreateFromLdml(FilePath)

		CultureAndRegionInfoDictionary.Add(builder.CultureName, builder)
	End Sub
End Class
