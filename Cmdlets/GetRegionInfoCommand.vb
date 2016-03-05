<System.Management.Automation.Cmdlet("Get", "RegionInfo")> _
Public Class GetRegionInfoCommand
    Inherits System.Management.Automation.Cmdlet

    Public Shared Function GetAllRegions(Optional CultureOnly As Boolean = False) As System.Collections.Generic.List(Of System.Globalization.RegionInfo)
        Dim RegionNames As New System.Collections.Generic.HashSet(Of String)

        For Each CI In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures)
            RegionNames.Add(CI.Name)
        Next

        Dim Regions As New System.Collections.Generic.List(Of System.Globalization.RegionInfo)

        For Each RegionName In RegionNames
            Regions.Add(New System.Globalization.RegionInfo(RegionName))
        Next

        If Not CultureOnly Then
            For Each Region In Regions
                RegionNames.Add(Region.TwoLetterISORegionName)
            Next

            Regions.Clear()

            For Each RegionName In RegionNames
                Regions.Add(New System.Globalization.RegionInfo(RegionName))
            Next
        End If

        Return Regions
    End Function

    <System.Management.Automation.Parameter(Mandatory:=False)> _
    Public Property CultureOnly() As System.Management.Automation.SwitchParameter

    <System.Management.Automation.Parameter(Mandatory:=False)> _
    Public Property Name As String

    <System.Management.Automation.Parameter()> _
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
