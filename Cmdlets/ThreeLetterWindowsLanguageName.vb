Public Class ThreeLetterWindowsLanguageName

    Public Name As String

    Public ReadOnly Property Count() As Integer
        Get
            Return Me.Cultures.Count
        End Get
    End Property

    Public ReadOnly Property NeutralsCount() As Integer
        Get
            Return Me.Cultures.Where(Function(C) C.IsNeutralCulture).Count()
        End Get
    End Property

    Public ReadOnly Property RegionalsCount() As Integer
        Get
            Dim Specifics = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures)

            Return Me.Cultures.Where(Function(C) Specifics.Contains(C)).Count()
        End Get
    End Property

    Public Cultures As New System.Collections.Generic.List(Of System.Globalization.CultureInfo)

End Class
