Imports System.Globalization
Imports System.Management.Automation

<Cmdlet("Get", "CultureInfo")>
Public Class GetCultureInfoCommand
	Inherits Cmdlet

	<Parameter()>
	Public Property Name() As String

	<Parameter()>
	Public Property All() As SwitchParameter

	<Parameter()>
	Public Property CultureTypes() As CultureTypes = CultureTypes.AllCultures

	Protected Overrides Sub BeginProcessing()

		If Me.All.IsPresent Then

			Me.WriteObject(CultureInfo.GetCultures(Me.CultureTypes), True)
		ElseIf Me.Name IsNot Nothing Then

			Me.WriteObject(New CultureInfo(Me.Name))
		Else

			Dim CurrentCultures As New System.Collections.Generic.Dictionary(Of String, CultureInfo)

			CurrentCultures.Add("CurrentCulture", CultureInfo.CurrentCulture)
			CurrentCultures.Add("CurrentUICulture", CultureInfo.CurrentUICulture)

			Me.WriteObject(CurrentCultures, True)
		End If
	End Sub
End Class
