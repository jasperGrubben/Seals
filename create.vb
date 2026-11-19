Imports Inventor

Public Module SealCreate
    Public Function ProcessTask(task As SealTask) As Boolean
        If String.IsNullOrWhiteSpace(task.TemplatePath) Then
            SealGlobals.Show("No template for part: " & task.PartName)
            Return False
        End If

        task.OutputPath = System.IO.Path.Combine(task.OutputFolder,
            task.PartName & "_" & NumberHelper.SealKey(task.Model) & ".ipt")

        If Not FindOccurrence(task) Then
            SealGlobals.Show("Occurrence not found: " & task.PartName)
            Return False
        End If

        Try
            CreateFile(task)
            ConfigurePart(task)
            Return True
        Catch ex As Exception
            SealGlobals.LogError("Error for " & task.PartName & ": " & ex.ToString())
            SealGlobals.Show("Error for " & task.PartName & ":" & vbCrLf & ex.Message)
            Return False
        End Try
    End Function

    Private Function FindOccurrence(task As SealTask) As Boolean
        For Each occ As ComponentOccurrence In task.Asm.ComponentDefinition.Occurrences
            If occ.Name = task.PartName OrElse occ.Name.StartsWith(task.PartName & ":") Then
                task.Occurrence = occ
                task.OccurrenceName = occ.Name
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub CreateFile(task As SealTask)
        If Not System.IO.File.Exists(task.OutputPath) Then
            System.IO.File.Copy(task.TemplatePath, task.OutputPath, False)
            SealGlobals.LogInfo("New IPT created: " & task.OutputPath)
        End If
        RemoveReadOnlyFlag(task.OutputPath)
    End Sub

    Private Sub ConfigurePart(task As SealTask)
        Dim partDoc As PartDocument = Nothing
        Try
            partDoc = CType(SealGlobals.ThisApp.Documents.Open(task.OutputPath, False), PartDocument)
            SetParametersIn(partDoc, task)
            SealMaterials.SetMaterial(partDoc, task.Material)
            partDoc.Update()
            partDoc.Save()
            SealGlobals.LogInfo("Saved: " & task.OutputPath)
            partDoc.Close(True)
        Catch
            If partDoc IsNot Nothing Then
                Try
                    partDoc.Close(False)
                Catch
                End Try
            End If
            Throw
        End Try
    End Sub

    'pipe diameter == name DN catalog
    Private Sub SetParametersIn(partDoc As PartDocument, task As SealTask)
        Dim parameters As Parameters = partDoc.ComponentDefinition.Parameters
        SetMm(parameters, New ParameterValue("BinnenDiaMeter", task.Model.MaatA))
        SetMm(parameters, New ParameterValue("BuitenDiaMeter", task.Model.MaatB))
        SetMm(parameters, New ParameterValue("PipeDiaMeter", task.Model.PipeDiameter))
    End Sub

    Private Sub SetMm(partParams As Parameters, pv As ParameterValue)
        partParams.Item(pv.Name).Expression = NumberHelper.MmText(pv.Value)
    End Sub

    Private Sub RemoveReadOnlyFlag(filePath As String)
        If Not System.IO.File.Exists(filePath) Then Return
        Dim attributes As System.IO.FileAttributes = System.IO.File.GetAttributes(filePath)
        If (attributes And System.IO.FileAttributes.ReadOnly) <> 0 Then
            System.IO.File.SetAttributes(filePath, attributes And Not System.IO.FileAttributes.ReadOnly)
        End If
    End Sub
End Module
