Imports Inventor

Public Module SealSave
    Public Sub SaveAssemblyCopy(asm As AssemblyDocument, outputFolder As String, model As Input)
        If asm Is Nothing Then Throw New ArgumentNullException(NameOf(asm))
        If model Is Nothing Then Throw New ArgumentNullException(NameOf(model))
        If String.IsNullOrWhiteSpace(outputFolder) Then
            Throw New ArgumentException("Output folder is required.", NameOf(outputFolder))
        End If
        If Not System.IO.Directory.Exists(outputFolder) Then
            System.IO.Directory.CreateDirectory(outputFolder)
        End If

        Dim material As String = System.IO.Path.GetFileName(outputFolder.Substring(0, outputFolder.LastIndexOf(System.IO.Path.DirectorySeparatorChar)))
        Dim targetPath As String = System.IO.Path.Combine(outputFolder,
            "Seals_" & NumberHelper.SealKey(model, material) & ".iam")

        If System.IO.File.Exists(targetPath) Then
            Dim existingAsm As AssemblyDocument = Nothing
            Try
                existingAsm = CType(SealGlobals.ThisApp.Documents.Open(targetPath, False), AssemblyDocument)
                ApplyModelToAssembly(existingAsm, model)
                existingAsm.Update()
                existingAsm.Save()
                SealGlobals.LogInfo("Used existing assembly copy: " & targetPath)
            Catch ex As Exception When ex.HResult = &H80004007
                SealGlobals.LogInfo("Inventor save failed; skipping save to avoid corrupt state.")
            Finally
                If existingAsm IsNot Nothing Then
                    existingAsm.Close(True)
                End If
            End Try
            Return
        End If

        asm.SaveAs(targetPath, True)

        Dim copiedAsm As AssemblyDocument = Nothing
        Try
            copiedAsm = CType(SealGlobals.ThisApp.Documents.Open(targetPath, False), AssemblyDocument)
            ApplyModelToAssembly(copiedAsm, model)
            copiedAsm.Update()
            copiedAsm.Save()
            SealGlobals.LogInfo("Created and saved new assembly copy: " & targetPath)
        Finally
            If copiedAsm IsNot Nothing Then
                copiedAsm.Close(True)
            End If
        End Try
    End Sub

    Private Sub ApplyModelToAssembly(asmDoc As AssemblyDocument, model As Input)
        If asmDoc Is Nothing Then Return
        SetParameter(asmDoc, "MaatA", model.MaatA)
        SetParameter(asmDoc, "MaatB", model.MaatB)
        SetParameter(asmDoc, "PipeDiaMeter", model.PipeDiameter)
        SetParameter(asmDoc, "Thickness", model.SealThickness)
    End Sub

    Private Sub SetParameter(asmDoc As AssemblyDocument, parameterName As String, value As Double)
        If asmDoc Is Nothing Then Return
        Try
            Dim param As Parameter = asmDoc.ComponentDefinition.Parameters.Item(parameterName)
            If param IsNot Nothing Then
                param.Expression = NumberHelper.MmText(value)
            End If
        Catch
        End Try
    End Sub
End Module
