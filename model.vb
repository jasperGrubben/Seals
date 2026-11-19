Imports Inventor

Public Class Input
    Public Property MaatA As Double
    Public Property MaatB As Double
    Public Property PipeDiameter As Double
    Public Property Thickness As Double

    Public ReadOnly Property SealThickness As Double
        Get
            Return 4.0 + Thickness
        End Get
    End Property

    Public ReadOnly Property IsValid As Boolean
        Get
            Return MaatA > 0 AndAlso MaatB > 0 AndAlso PipeDiameter > 0 AndAlso Thickness >= 0
        End Get
    End Property
End Class

Public Class SealTask
    Public Asm As AssemblyDocument
    Public Model As Input
    Public Material As String
    Public OutputFolder As String
    Public PartName As String
    Public TemplatePath As String
    Public Occurrence As ComponentOccurrence
    Public OccurrenceName As String
    Public OutputPath As String
End Class

Public Class ParameterValue
    Public Name As String
    Public Value As Double

    Public Sub New(name As String, value As Double)
        Me.Name = name
        Me.Value = value
    End Sub
End Class

'voor . uit bestandsnamen tehouden enzo
Public Module NumberHelper
    'Invariant culture: used for file names (dot as decimal separator)
    Public Function FileNumber(value As Double) As String
        Return value.ToString(System.Globalization.CultureInfo.InvariantCulture)
    End Function

    'Current culture: used for Inventor parameter expressions (NL = comma)
    Public Function MmText(value As Double) As String
        Return value.ToString(System.Globalization.CultureInfo.CurrentCulture) & " mm"
    End Function

    Public Function SealKey(model As Input, material As String) As String
        Return FileNumber(model.PipeDiameter) & "x" &
               FileNumber(model.SealThickness) & "x" & material
    End Function
End Module
