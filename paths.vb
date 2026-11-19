Public Class SealPaths

    Public ReadOnly InnerRing As String = "C:\Users\Gasteng5\Documents\ilogic2027\Seals\Parts\SealIn.ipt"
    Public ReadOnly OuterRing As String = "C:\Users\Gasteng5\Documents\ilogic2027\Seals\Parts\Klemband.ipt"
    Public ReadOnly TemplateIAM As String = "C:\Users\Gasteng5\Documents\ilogic2027\Seals\Parts\Seals.iam"
    Public ReadOnly OutputDir As String = "C:\Users\Gasteng5\Documents\ilogic2027\Seals\Outputs\een"

    Public ReadOnly PartNames() As String = {"SealIn", "Klemband"}

    Public Function TemplateFor(partName As String) As String
        Select Case partName
            Case "SealIn"
                Return InnerRing
            Case "Klemband"
                Return OuterRing
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function Validate() As Boolean
        If Not System.IO.File.Exists(InnerRing) Then
            SealGlobals.Show("Inner ring template is missing: " & InnerRing)
            Return False
        End If
        If Not System.IO.File.Exists(OuterRing) Then
            SealGlobals.Show("Klemband template is missing: " & OuterRing)
            Return False
        End If
        If Not System.IO.File.Exists(TemplateIAM) Then
            SealGlobals.Show("Assembly template is missing: " & TemplateIAM)
            Return False
        End If
        If Not System.IO.Directory.Exists(OutputDir) Then
            System.IO.Directory.CreateDirectory(OutputDir)
        End If
        Return True
    End Function
End Class
