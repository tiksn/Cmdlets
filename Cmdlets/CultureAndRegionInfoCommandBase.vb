Imports System.Collections.Generic
Imports System.Globalization
Imports System.Management.Automation

Public Class CultureAndRegionInfoCommandBase
	Inherits Cmdlet

	Protected Shared CultureAndRegionInfoDictionary As New Dictionary(Of String, CultureAndRegionInfoBuilder)
End Class
