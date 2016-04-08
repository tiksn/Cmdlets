<System.Management.Automation.Cmdlet("Get", "RegionInfo")> _
Public Class GetRegionInfoCommand
	Inherits System.Management.Automation.Cmdlet

	<System.Management.Automation.Parameter(Mandatory:=False)>
	Public Property CultureOnly() As System.Management.Automation.SwitchParameter

	<System.Management.Automation.Parameter(Mandatory:=False)>
	Public Property Name As String

	<System.Management.Automation.Parameter()>
	Public Property All() As System.Management.Automation.SwitchParameter

	Protected Overrides Sub BeginProcessing()


		If Not String.IsNullOrEmpty(Me.Name) Then

			Dim Region = New System.Globalization.RegionInfo(Me.Name)

			Me.WriteObject(Region)
		ElseIf Me.All.IsPresent OrElse Me.CultureOnly.IsPresent Then

			Dim Regions = GetAllRegions(Me.CultureOnly.IsPresent)

			Me.WriteObject(Regions, True)
		Else

			Me.WriteObject(System.Globalization.RegionInfo.CurrentRegion)
		End If
	End Sub
End Class
