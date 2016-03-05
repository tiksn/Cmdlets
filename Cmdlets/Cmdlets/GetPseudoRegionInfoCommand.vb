<System.Management.Automation.Cmdlet("Get", "PseudoRegionInfo")> _
Public Class GetPseudoRegionInfoCommand
    Inherits System.Management.Automation.Cmdlet

    Protected Overrides Sub BeginProcessing()

        Me.WriteWarning("Multilingual App Toolkit must be installed. For more information visit http://go.microsoft.com/fwlink/?LinkID=262054")

        Me.WriteObject(New System.Globalization.RegionInfo("qps-ploc"))
    End Sub
End Class
