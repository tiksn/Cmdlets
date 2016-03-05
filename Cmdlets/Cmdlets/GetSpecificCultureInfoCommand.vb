<System.Management.Automation.Cmdlet("Get", "SpecificCultureInfo")> _
Public Class GetSpecificCultureInfoCommand
    Inherits System.Management.Automation.Cmdlet

    <System.Management.Automation.Parameter()> _
    Public Property CultureName() As String

    <System.Management.Automation.Parameter()> _
    Public Property All() As System.Management.Automation.SwitchParameter

    Protected Overrides Sub BeginProcessing()

        If Me.All.IsPresent Then

            Dim CulturesAndSpecifics As New System.Collections.Generic.List(Of System.Tuple(Of System.Globalization.CultureInfo, System.Globalization.CultureInfo))

            For Each CC In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
                CulturesAndSpecifics.Add(New System.Tuple(Of System.Globalization.CultureInfo, System.Globalization.CultureInfo)(CC, System.Globalization.CultureInfo.CreateSpecificCulture(CC.Name)))
            Next

            Me.WriteObject(CulturesAndSpecifics, True)
        ElseIf Me.CultureName IsNot Nothing Then

            Me.WriteObject(System.Globalization.CultureInfo.CreateSpecificCulture(Me.CultureName))
        End If
    End Sub
End Class
