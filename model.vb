Imports Inventor

Public Class Input
    Public Property InputBinnenDia As Double

    Public ReadOnly Property IsValid As Boolean
        Get
            Return InputBinnenDia > 0 
        End Get
    End Property
End Class

Public Class SealTask
    Public Asm As AssemblyDocument
    Public Model as Input
    Public OutputFolder As String
    Public PartName As String
    Public TemplatePath As String
    Public OutputPath As String
    Public PartDiameter As Double

    Public Sub Start(name as String, template As String)
        PartName = name
        TemplatePath = template
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
End Module
