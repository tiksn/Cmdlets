<System.Management.Automation.Cmdlet("Get", "CultureInfo")> _
Public Class GetCultureInfoCommand
    Inherits System.Management.Automation.Cmdlet

    <System.Management.Automation.Parameter()> _
    Public Property CultureName() As String

    <System.Management.Automation.Parameter()> _
    Public Property All() As System.Management.Automation.SwitchParameter

    Protected Overrides Sub BeginProcessing()

        If Me.All.IsPresent Then

            Me.WriteObject(System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures), True)
        ElseIf Me.CultureName IsNot Nothing Then

            Me.WriteObject(New System.Globalization.CultureInfo(Me.CultureName))
        Else

            Dim CurrentCultures As New System.Collections.Generic.Dictionary(Of String, System.Globalization.CultureInfo)

            CurrentCultures.Add("CurrentCulture", System.Globalization.CultureInfo.CurrentCulture)
            CurrentCultures.Add("CurrentUICulture", System.Globalization.CultureInfo.CurrentUICulture)

            Me.WriteObject(CurrentCultures, True)
        End If
    End Sub
End Class
