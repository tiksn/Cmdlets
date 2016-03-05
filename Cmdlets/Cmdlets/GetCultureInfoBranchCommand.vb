<System.Management.Automation.Cmdlet("Get", "CultureInfoBranch")> _
Public Class GetCultureInfoBranchCommand
    Inherits System.Management.Automation.Cmdlet

    <System.Management.Automation.Parameter(Mandatory:=True)> _
    Public Property Name As String

    Protected Overrides Sub BeginProcessing()

        Dim cultureBranch As New System.Collections.Generic.List(Of System.Globalization.CultureInfo)

        Dim culture As New System.Globalization.CultureInfo(Me.Name)

        cultureBranch.Add(culture)

        AddParent(culture, cultureBranch)

        Me.WriteObject(cultureBranch, True)
    End Sub

    Private Sub AddParent(culture As System.Globalization.CultureInfo, cultureBranch As System.Collections.Generic.List(Of System.Globalization.CultureInfo))

        cultureBranch.Add(culture.Parent)

        If culture.Parent IsNot Nothing AndAlso Not culture.Parent.Equals(System.Globalization.CultureInfo.InvariantCulture) Then
            AddParent(culture.Parent, cultureBranch)
        End If
    End Sub

End Class
