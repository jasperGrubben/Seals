Imports Inventor

Public Module SealMaterials
    Public Sub SetMaterial(partDoc As PartDocument, materialName As String)
        If partDoc Is Nothing OrElse String.IsNullOrWhiteSpace(materialName) Then Return

        Try
            Dim props As PropertySet = partDoc.PropertySets.Item("Inventor Summary Information")
            props.Item("Comments").Value = materialName
        Catch
            Try
                Dim props As PropertySet = partDoc.PropertySets.Item("Inventor Summary Information")
                props.Add(materialName, "Comments")
            Catch
            End Try
        End Try
    End Sub
End Module
