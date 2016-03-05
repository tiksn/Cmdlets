<System.Management.Automation.Cmdlet("Get", "ChildCultureInfo")> _
Public Class GetChildCultureInfoCommand
    Inherits System.Management.Automation.Cmdlet

    <System.Management.Automation.Parameter(Mandatory:=False)> _
    Public Property ParentCultureName() As String

    <System.Management.Automation.Parameter()> _
    Public Property Tree() As System.Management.Automation.SwitchParameter

    Protected Overrides Sub BeginProcessing()

        Dim ParentName = Me.ParentCultureName

        If Me.ParentCultureName Is Nothing Then
            Me.WriteVerbose("Parent Name is not specified.")
            ParentName = String.Empty
        End If

        Dim ParentCultureInfo = New System.Globalization.CultureInfo(ParentName)
        Dim ChildCultures = GetChildCultures(ParentCultureInfo, Me.Tree.IsPresent)

        For Each C As System.Globalization.CultureInfo In ChildCultures
            Me.WriteObject(C)
        Next
    End Sub

    Private Shared Function GetChildCultures(ParentCulture As System.Globalization.CultureInfo, Tree As Boolean) As System.Collections.Generic.IEnumerable(Of System.Globalization.CultureInfo)

        Dim Result = New System.Collections.Generic.List(Of System.Globalization.CultureInfo)

        For Each C As System.Globalization.CultureInfo In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
            If C.Parent.Equals(ParentCulture) AndAlso Not C.Equals(System.Globalization.CultureInfo.InvariantCulture) Then
                Result.Add(C)

                If Tree Then
                    Result.AddRange(GetChildCultures(C, Tree))
                End If
            End If
        Next

        Return Result
    End Function
End Class
