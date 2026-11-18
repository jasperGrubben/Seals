Imports Inventor

Public Module SealMaterials
    Public Sub SetMaterial(partDoc As PartDocument, materialName As String)
        If partDoc Is Nothing OrElse String.IsNullOrWhiteSpace(materialName) Then Return
        Dim material As Inventor.Material = FindMaterial(partDoc, materialName)
        If material Is Nothing Then
            SealGlobals.LogError("Material not found: " & materialName)
            Return
        End If
        partDoc.ComponentDefinition.Material = material
    End Sub

    Private Function FindMaterial(partDoc As PartDocument, materialName As String) As Inventor.Material
        Try
            Return partDoc.Materials.Item(materialName)
        Catch
        End Try
        For Each library As MaterialLibrary In SealGlobals.ThisApp.MaterialLibraries
            Try
                Return library.Materials.Item(materialName)
            Catch
            End Try
        Next
        Return Nothing
    End Function
End Module
