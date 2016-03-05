Public Class CurrencyRegions

    Private _Regions As System.Collections.Generic.List(Of System.Globalization.RegionInfo)

    Public Sub New()
        Me._Regions = New System.Collections.Generic.List(Of System.Globalization.RegionInfo)
    End Sub

    Public Property Currency() As TIKSN.Finance.CurrencyInfo

    Public ReadOnly Property Regions() As System.Collections.Generic.List(Of System.Globalization.RegionInfo)
        Get
            Return Me._Regions
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return Me.Regions.Count
        End Get
    End Property
End Class
