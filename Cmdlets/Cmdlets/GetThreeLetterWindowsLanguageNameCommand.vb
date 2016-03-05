<System.Management.Automation.Cmdlet("Get", "ThreeLetterWindowsLanguageName")> _
Public Class GetThreeLetterWindowsLanguageNameCommand
    Inherits System.Management.Automation.Cmdlet

    Protected Overrides Sub BeginProcessing()

        Dim Cultures As New System.Collections.Generic.List(Of System.Tuple(Of String, System.Globalization.CultureInfo))

        For Each CC In System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)
            Cultures.Add(New System.Tuple(Of String, System.Globalization.CultureInfo)(CC.ThreeLetterWindowsLanguageName, CC))
        Next

        Dim TLW = Cultures.ToLookup(Function(T) T.Item1, Function(T) T.Item2)

        Dim TLWLN As New System.Collections.Generic.List(Of ThreeLetterWindowsLanguageName)

        For Each Lang In TLW

            Dim TL As New ThreeLetterWindowsLanguageName

            TL.Name = Lang.Key

            For Each TC In Lang
                TL.Cultures.Add(TC)
            Next

            TLWLN.Add(TL)
        Next

        Me.WriteObject(TLWLN, True)
    End Sub
End Class
