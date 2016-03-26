Imports System.Management.Automation

<Cmdlet("Get", "CultureAndRegionInfo")>
Public Class GetCultureAndRegionInfoCommand
	Inherits CultureAndRegionInfoCommandBase

	<Parameter()>
	Public Property Name() As String

	Protected Overrides Sub BeginProcessing()

		If String.IsNullOrEmpty(Name) Then
			WriteObject(CultureAndRegionInfoDictionary, True)
		Else
			WriteObject(CultureAndRegionInfoDictionary(Name))
		End If
	End Sub
End Class
