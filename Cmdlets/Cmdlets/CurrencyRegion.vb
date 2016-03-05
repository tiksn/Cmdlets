Public Class CurrencyRegion

    Private _Currency As TIKSN.Finance.CurrencyInfo

    Private _Region As System.Globalization.RegionInfo

    Public Sub New(Region As System.Globalization.RegionInfo)

        Me._Region = Region
        Me._Currency = New TIKSN.Finance.CurrencyInfo(Region)
    End Sub

    Public ReadOnly Property Currency() As TIKSN.Finance.CurrencyInfo
        Get
            Return Me._Currency
        End Get
    End Property

    Public ReadOnly Property Region() As System.Globalization.RegionInfo
        Get
            Return Me._Region
        End Get
    End Property
End Class
